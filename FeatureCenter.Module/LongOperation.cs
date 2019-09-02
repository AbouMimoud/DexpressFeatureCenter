using System;
using System.Text;
using System.Threading;
using DevExpress.ExpressApp.Utils;

namespace FeatureCenter.Module {
    public enum LongOperationStatus { NotStarted, InProgress, Completed, Error, Cancelling, CancellingError, Cancelled, Terminating, TerminatingError, Terminated }

    public class LongOperationCompletedEventArgs : EventArgs {
        private LongOperationResult operationResult;
        public LongOperationCompletedEventArgs(LongOperationResult operationResult) {
            this.operationResult = operationResult;
        }
        public LongOperationResult OperationResult {
            get { return operationResult; }
        }
    }

    public class LongOperationProgressChangedEventArgs : EventArgs {
        private int progressPercentage;
        private string message;
        private object data;
        public LongOperationProgressChangedEventArgs(int progressPercentage, string message, object data) {
            this.progressPercentage = progressPercentage;
            this.message = message;
            this.data = data;
        }
        public int ProgressPercentage {
            get { return progressPercentage; }
        }
        public string Message {
            get { return message; }
        }
        public object Data {
            get { return data; }
        }
    }

    public enum LongOperationResult { NotCompleted, Completed, Error, Cancelled, Terminated }

    public delegate void LongOperationParametrizedDelegate(LongOperation longOperation, object argument);
    public delegate void LongOperationDelegate(LongOperation longOperation);

    public class LongOperation : IDisposable {
        private const string unknownThreadName = "          ";
        private const string workingThreadName = "working   ";
        private const string cancellingThreadName = "cancelling";
        private const string mainThreadName = "main      ";

        private StringBuilder history = new StringBuilder();
        private Thread worker;
        private Thread cancellingWorker;
        private int cancellingTimeoutMilliSeconds = 5000;
        private int cancellingSleepPeriodMilliSeconds = 10;
        private bool isConfirmTerminateQueried = false;
        private LongOperationStatus status;
        private LongOperationResult result;
        private LongOperationDelegate longOperationDelegate;
        private LongOperationParametrizedDelegate longOperationParametrizedDelegate;
        private Exception lastException;

        private void worker_DoWork(object argument) {
            RegisterThreadName(workingThreadName);
            AppendHistoryLine("worker_DoWork", ">");
            if(status != LongOperationStatus.NotStarted) {
                AppendHistoryLine("worker_DoWork", "status=" + status);
                return;
            }
            SetStatus(LongOperationStatus.InProgress);
            try {
                if(longOperationParametrizedDelegate != null) {
                    longOperationParametrizedDelegate(this, argument);
                }
                else {
                    longOperationDelegate(this);
                }
                if(status == LongOperationStatus.Cancelling) {
                    SetStatus(LongOperationStatus.Cancelled);
                    RaiseCompleted(LongOperationResult.Cancelled);
                }
                else if(status == LongOperationStatus.InProgress) {
                    SetStatus(LongOperationStatus.Completed);
                    RaiseCompleted(LongOperationResult.Completed);
                }
                AppendHistoryLine("worker_DoWork", "<");
            }
            catch(ThreadAbortException) {
                AppendHistoryLine("worker_DoWork", "ThreadAbortException");
                Thread.ResetAbort();
            }
            catch(Exception ex) {
                if(Status == LongOperationStatus.InProgress) {
                    SetStatus(LongOperationStatus.Error);
                    lastException = ex;
                    RaiseCompleted(LongOperationResult.Error);
                }
            }
        }
        private LightDictionary<ExecutionContext, string> threadNames = new LightDictionary<ExecutionContext, string>();
        private void RegisterThreadName(string threadName) {
            threadNames[Thread.CurrentThread.ExecutionContext] = threadName;
        }
        private void AppendHistoryLine(string method, string message) {
            string threadName = threadNames[Thread.CurrentThread.ExecutionContext];
            if(string.IsNullOrEmpty(threadName)) {
                threadName = unknownThreadName;
            }
            threadName = Thread.CurrentThread.ExecutionContext.GetHashCode() + " (" + threadName + ")";
            history.AppendLine(threadName + " " + method + "(" + message + ")");
        }
        private void cancellingWorker_DoWork() {
            AppendHistoryLine("cancellingWorker_DoWork", ">");
            RegisterThreadName(cancellingThreadName);
            try {
                int elapsedMilliSeconds = 0;
                while(true) {
                    if(status != LongOperationStatus.Cancelling && status != LongOperationStatus.Terminating) {
                        AppendHistoryLine("cancellingWorker_DoWork", "status=" + status);
                        break;
                    }
                    if(ExecutePendingTerminating()) {
                        break;
                    }

                    while(elapsedMilliSeconds < (cancellingTimeoutMilliSeconds)) {
                        Thread.Sleep(cancellingSleepPeriodMilliSeconds);
                        elapsedMilliSeconds += cancellingSleepPeriodMilliSeconds;
                        if(ExecutePendingTerminating()) {
                            break;
                        }
                        if(status != LongOperationStatus.Cancelling && status != LongOperationStatus.Terminating) {
                            AppendHistoryLine("cancellingWorker_DoWork", "status=" + status);
                            break;
                        }
                        RaiseProgressChanged((int)((elapsedMilliSeconds * 100) / cancellingTimeoutMilliSeconds), "Cancelling");
                    }
                    if(!isConfirmTerminateQueried) {
                        if(ExecutePendingTerminating()) {
                            break;
                        }
                        if(status != LongOperationStatus.Cancelling && status != LongOperationStatus.Terminating) {
                            AppendHistoryLine("cancellingWorker_DoWork", "status=" + status);
                            break;
                        }
                        AppendHistoryLine("cancellingWorker_DoWork", "elapsedMilliSeconds=" + elapsedMilliSeconds);
                        RaiseCancellingTimeoutExpired();
                        isConfirmTerminateQueried = true;
                    }
                }
                if(Status == LongOperationStatus.Cancelling) {
                    RaiseCompleted(LongOperationResult.Cancelled);
                }
            }
            catch(ThreadAbortException) {
                AppendHistoryLine("cancellingWorker_DoWork", "ThreadAbortException");
            }
            catch(Exception ex) {
                lastException = ex;
                AppendHistoryLine("cancellingWorker_DoWork", "Exception " + ex.Message);
                SetStatus(LongOperationStatus.CancellingError);
            }
            AppendHistoryLine("cancellingWorker_DoWork", "<");
        }
        private bool ExecutePendingTerminating() {
            if(Status == LongOperationStatus.Terminating) {
                history.AppendLine("workingThread.Abort");
                try {
                    //
                    // When this exception is raised, the runtime executes all the finally blocks before ending the thread. 
                    // Since the thread can do an unbounded computation in the finally blocks, or call Thread..::.ResetAbort 
                    // to cancel the abort, there is no guarantee that the thread will ever end.
                    // If you want to wait until the aborted thread has ended, you can call the Thread..::.Join method. 
                    // Join is a blocking call that does not return until the thread actually stops executing.
                    // for more details, see http://msdn.microsoft.com/en-us/library/system.threading.threadabortexception.aspx
                    //
                    // Thus, it seems that we need to call the "Abort" method in a separate thread with a fixed timeout.
                    //
                    // Thanks, Dan.
                    //
                    worker.Abort();

                    SetStatus(LongOperationStatus.Terminated);
                    RaiseCompleted(LongOperationResult.Terminated);
                }
                catch(Exception ex) {
                    lastException = ex;
                }
                return true;
            }
            return false;
        }
        public void RaiseProgressChanged(int progressPercentage, string message) {
            RaiseProgressChanged(progressPercentage, message, null);
        }
        public void RaiseProgressChanged(int progressPercentage, string message, object data) {
            AppendHistoryLine("RaiseProgressChanged", ">");
            AppendHistoryLine("RaiseProgressChanged", message);
            if(ProgressChanged != null) {
                ProgressChanged(this, new LongOperationProgressChangedEventArgs(progressPercentage, message, data));
            }
            AppendHistoryLine("RaiseProgressChanged", "<");
        }
        private void RaiseCancellingTimeoutExpired() {
            AppendHistoryLine("RaiseCancellingTimeoutExpired", ">");
            AppendHistoryLine("RaiseCancellingTimeoutExpired", "cancellingTimeoutMilliSeconds=" + cancellingTimeoutMilliSeconds);

            if(CancellingTimeoutExpired != null) {
                CancellingTimeoutExpired(this, EventArgs.Empty);
            }
            //TODO Constant
			//TerminateAsync();

            AppendHistoryLine("RaiseCancellingTimeoutExpired", "<");
        }
        private void RaiseCompleted(LongOperationResult result) {
            AppendHistoryLine("RaiseCompleted", ">");
            AppendHistoryLine("RaiseCompleted", "Status: " + Status);
            this.result = result;
            if(Completed != null) {
                Completed(this, new LongOperationCompletedEventArgs(result));
            }
            AppendHistoryLine("RaiseCompleted", "<");
        }
        private void SetStatus(LongOperationStatus newStatus) {
            AppendHistoryLine("SetStatus", ">");
            AppendHistoryLine("SetStatus", "newStatus=" + newStatus);
            this.status = newStatus;
            AppendHistoryLine("SetStatus", "<");
        }

        protected internal string GetHistoryInternal() {
            return history.ToString();
        }
        protected internal int CancellingSleepPeriodMilliSecondsInternal {
            get { return cancellingSleepPeriodMilliSeconds; }
            set { cancellingSleepPeriodMilliSeconds = value; }
        }

        public LongOperation(LongOperationDelegate longOperationDelegate) {
            RegisterThreadName(mainThreadName);
            this.longOperationDelegate = longOperationDelegate;
        }
        public LongOperation(LongOperationParametrizedDelegate longOperationParametrizedDelegate) {
            RegisterThreadName(mainThreadName);
            this.longOperationParametrizedDelegate = longOperationParametrizedDelegate;
        }
        public void StartAsync() {
            StartAsync(null);
        }
        public void StartAsync(object argument) {
            AppendHistoryLine("StartAsync", ">");
            worker = new Thread(worker_DoWork);
            worker.Start(argument);
            AppendHistoryLine("StartAsync", "<");
        }
        public void CancelAsync() {
            AppendHistoryLine("CancelAsync", ">");
            if(cancellingWorker == null) {
                SetStatus(LongOperationStatus.Cancelling);
                RaiseProgressChanged(0, "Cancelling"/*, "Cancelling the operation..."*/);
                cancellingWorker = new Thread(cancellingWorker_DoWork);
                AppendHistoryLine("CancelAsync", "cancellingWorker.Start");
                cancellingWorker.Start();
            }
            AppendHistoryLine("CancelAsync", "<");
        }
        public void TerminateAsync() {
            AppendHistoryLine("TerminateAsync", ">");
            if(Status == LongOperationStatus.Cancelled || Status == LongOperationStatus.Completed || Status == LongOperationStatus.Error
                || Status == LongOperationStatus.Terminated) {
                return;
            }
            if(Status != LongOperationStatus.Terminating) {
                SetStatus(LongOperationStatus.Terminating);
            }
            AppendHistoryLine("TerminateAsync", "<");
        }
        public void Dispose() {
            AppendHistoryLine("Dispose", ">");
            if(worker != null) {
                worker = null;
            }
            if(cancellingWorker != null) {
                try {
                    cancellingWorker.Abort();
                }
                catch { }
                cancellingWorker = null;
            }
            AppendHistoryLine("Dispose", "<");
        }
        public LongOperationStatus Status {
            get { return status; }
        }
        public LongOperationResult Result {
            get { return result; }
        }
        public int CancellingTimeoutMilliSeconds {
            get { return cancellingTimeoutMilliSeconds; }
            set { cancellingTimeoutMilliSeconds = value; }
        }
        public Exception LastException {
            get { return lastException; }
        }
        public event EventHandler<LongOperationProgressChangedEventArgs> ProgressChanged;
        public event EventHandler<LongOperationCompletedEventArgs> Completed;
        public event EventHandler CancellingTimeoutExpired;
    }
}
