using System;
using System.Windows.Forms;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Demos;
using DevExpress.ExpressApp.Win.Core;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using DevExpress.Xpo.DB.Helpers;

namespace FeatureCenter.Module.Win {
    public class ObjectSpaceEventArgs : EventArgs {
		private IObjectSpace objectSpace;
		public ObjectSpaceEventArgs(IObjectSpace objectSpace) {
			this.objectSpace = objectSpace;
        }
		public IObjectSpace ObjectSpace {
			get { return objectSpace; }
        }
    }

    public class ObjectIndexEventArgs : EventArgs {
        private int index = 0;
        public int Index {
            get { return index; }
            set { index = value; }
        }
    }

    public class ObjectPoolCreationOptionsEventArgs : EventArgs {
        private int demoObjectsCount;
        private int demoObjectsCommitInterval;
        public ObjectPoolCreationOptionsEventArgs(int demoObjectsCount, int demoObjectsCommitInterval) {
            this.demoObjectsCount = demoObjectsCount;
            this.demoObjectsCommitInterval = demoObjectsCommitInterval;
        }
        public int DemoObjectsCount {
            get { return demoObjectsCount; }
            set { demoObjectsCount = value; }
        }
        public int DemoObjectsCommitInterval {
            get { return demoObjectsCommitInterval; }
            set { demoObjectsCommitInterval = value; }
        }
    }

    public class CreateDemoObjectsPoolController : LongOperationController {
        private const int defaultDemoObjectsCount = 2000;
        private const int defaultDemoObjectsCommitInterval = 50;
        private SimpleAction createDemoObjectsPoolAction;
        protected const string progressCaption = "Demo objects pool is being created...";
        protected const string progressMessageTemplate = "{0} objects are created of the {1} objects.";

        private IObjectSpace CreateUpdatingSession() {
			IObjectSpace result = Application.CreateObjectSpace(((ObjectView)View).ObjectTypeInfo.Type);
            //UnitOfWork session = new UnitOfWork(((XPObjectSpace)ObjectSpace).Session.ObjectLayer);
			OnUpdatingSessionCreated(result);
			return result;
        }
		private void CommitUpdatingSession(IObjectSpace objectSpace) {
            objectSpace.CommitChanges();
            OnUpdatingSessionCommitted(objectSpace);
        }
		private void DisposeUpdatingSession(IObjectSpace objectSpace) {
            OnUpdatingSessionDisposing(objectSpace);
            objectSpace.Dispose();
        }
        private int GetInitialIndex() {
            if(GetInitialObjectIndex != null) {
                ObjectIndexEventArgs args = new ObjectIndexEventArgs();
                GetInitialObjectIndex(this, args);
                return args.Index;
            }
            return 0;
        }
        private void UpdateActionState(bool inProgress) {
            createDemoObjectsPoolAction.Enabled.SetItemValue("Creating objects", !inProgress);
        }
        private void CreateDemoObjectsPoolAction_Execute(object sender, SimpleActionExecuteEventArgs e) {
            StartLongOperation();
        }

		protected virtual void OnUpdatingSessionCommitted(IObjectSpace objectSpace) {
            if(UpdatingSessionCommitted != null) {
				UpdatingSessionCommitted(this, new ObjectSpaceEventArgs(objectSpace));
            }
        }
		protected virtual void OnUpdatingSessionCreated(IObjectSpace objectSpace) {
            if(UpdatingSessionCreated != null) {
				UpdatingSessionCreated(this, new ObjectSpaceEventArgs(objectSpace));
            }
        }
		protected virtual void OnUpdatingSessionDisposing(IObjectSpace objectSpace) {
            if(UpdatingSessionDisposing != null) {
				UpdatingSessionDisposing(this, new ObjectSpaceEventArgs(objectSpace));
            }
        }
        protected override IProgressControl CreateProgressControl() {
            return new ProgressForm(progressCaption, 0, 100);
        }
        protected override void DoWorkCore(LongOperation longOperation) {
            int initialIndex = GetInitialIndex();
            ObjectPoolCreationOptionsEventArgs args = new ObjectPoolCreationOptionsEventArgs(defaultDemoObjectsCount, defaultDemoObjectsCommitInterval);
            BatchCreationOptionsAttribute creationOptionsAttribute = ((DevExpress.ExpressApp.ListView)View).ObjectTypeInfo.FindAttribute<BatchCreationOptionsAttribute>();
            if(creationOptionsAttribute != null) {
                if(creationOptionsAttribute.ObjectsCount.HasValue) {
                    args.DemoObjectsCount = creationOptionsAttribute.ObjectsCount.Value;
                }
                if(creationOptionsAttribute.CommitInterval.HasValue) {
                    args.DemoObjectsCommitInterval = creationOptionsAttribute.CommitInterval.Value;
                }
            }
            if(CustomizeObjectPoolCreationOptions != null) {
                CustomizeObjectPoolCreationOptions(this, args);
            }
			IObjectSpace objectSpace = CreateUpdatingSession();
            try {
                Type objectType = ((DevExpress.ExpressApp.ListView)View).ObjectTypeInfo.Type;
                for(int index = 0; index < args.DemoObjectsCount; index++) {
                    try {
                        if(index % args.DemoObjectsCommitInterval == 0) {
                            CommitUpdatingSession(objectSpace);
                        }

						IObjectPropertiesInitializer newObject = objectSpace.CreateObject(objectType) as IObjectPropertiesInitializer;
                        newObject.InitializeObject(index + initialIndex);

                        if(longOperation.Status == LongOperationStatus.InProgress) {
                            longOperation.RaiseProgressChanged((int)((index * 100) / args.DemoObjectsCount), string.Format(progressMessageTemplate, index + 1, args.DemoObjectsCount));
                        }
                        if(longOperation.Status == LongOperationStatus.Cancelling) {
                            return;
                        }
                    }
                    catch(LongOperationTerminateException) {
                        longOperation.CancelAsync();
                        break;
                    }
                }
            }
            finally {
                CommitUpdatingSession(objectSpace);
                DisposeUpdatingSession(objectSpace);
            }
        }
        protected override void OnOperationStarted() {
            UpdateActionState(true);
            base.OnOperationStarted();
        }
        protected override void OnOperationCompleted() {
            UpdateActionState(false);
            base.OnOperationCompleted();
        }
        protected override void OnActivated() {
            base.OnActivated();
            Application.ViewShown += new EventHandler<ViewShownEventArgs>(Application_ViewShown);
        }
		protected override void OnDeactivated() {
			base.OnDeactivated();
            Application.ViewShown -= new EventHandler<ViewShownEventArgs>(Application_ViewShown);
        }
        protected void Application_ViewShown(object sender, ViewShownEventArgs e) {
            if(!Application.ConnectionString.Contains("XpoProvider")) {
                return;
            }

            ConnectionStringParser parser = new ConnectionStringParser(Application.ConnectionString);
            string provider = parser.GetPartByName("XpoProvider");

            if(provider == "XmlDataSet") {
                ShowPerformanceWarning();
            }
        }
        protected void ShowPerformanceWarning() {
            Messaging.DefaultMessaging.Show(Hints.PerformanceWarningText, "Performance warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public CreateDemoObjectsPoolController() {
            this.TargetObjectType = typeof(IObjectPropertiesInitializer);
            this.TargetViewType = ViewType.ListView;
            string actionID = string.Format("{0}.CreateDemoObjectsPool", this.GetType().Name);
            this.createDemoObjectsPoolAction = new SimpleAction(this, actionID, PredefinedCategory.Edit);
            this.createDemoObjectsPoolAction.Caption = "Create Demo Objects";
            this.createDemoObjectsPoolAction.Execute += new SimpleActionExecuteEventHandler(CreateDemoObjectsPoolAction_Execute);
            this.createDemoObjectsPoolAction.ConfirmationMessage = "You are about to generate a lot of objects. Do you want to continue?";
            UpdateActionState(false);
        }
        public string ActionCaption {
            get { return createDemoObjectsPoolAction.Caption; }
            set { createDemoObjectsPoolAction.Caption = value; }
        }
        public event EventHandler<ObjectSpaceEventArgs> UpdatingSessionCreated;
        public event EventHandler<ObjectSpaceEventArgs> UpdatingSessionCommitted;
        public event EventHandler<ObjectSpaceEventArgs> UpdatingSessionDisposing;
        public event EventHandler<ObjectIndexEventArgs> GetInitialObjectIndex;
        public event EventHandler<ObjectPoolCreationOptionsEventArgs> CustomizeObjectPoolCreationOptions;
    }
}
