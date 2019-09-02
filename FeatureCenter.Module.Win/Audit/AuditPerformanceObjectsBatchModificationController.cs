using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using DevExpress.ExpressApp.Demos;
using DevExpress.ExpressApp;
using FeatureCenter.Module.Audit;

namespace FeatureCenter.Module.Win.Audit {
    public class AuditPerformanceObjectsBatchModificationController : LongOperationController {
        CreateDemoObjectsPoolController creationController;
        protected override void DoWorkCore(LongOperation longOperation) {
            Random random = new Random();
			IObjectSpace updatingObjectSpace = Application.CreateObjectSpace(typeof(FullyAuditedBatchCreationObject));
            IList<FullyAuditedBatchCreationObject> collection = updatingObjectSpace.GetObjects<FullyAuditedBatchCreationObject>();
            int index = 0;
            try {
                foreach(object currentObject in collection) {
                    ((FullyAuditedBatchCreationObject)currentObject).InitializeObject(collection.Count - index);
                    ((FullyAuditedBatchCreationObject)currentObject).Save();
                    if(index % 50 == 0) {
                        updatingObjectSpace.CommitChanges();
                    }
                    if(longOperation.Status == LongOperationStatus.InProgress) {
                        longOperation.RaiseProgressChanged((int)((++index * 100) / collection.Count), "Modifying objects...");
                    }
                    if(longOperation.Status == LongOperationStatus.Cancelling) {
                        return;
                    }
                }
            }
            catch(LongOperationTerminateException) {
                longOperation.CancelAsync();
            }
            updatingObjectSpace.CommitChanges();
        }
        private void CreationController_ObjectCreationCompleted(object sender, EventArgs e) {
            StartLongOperation();
        }
        protected override IProgressControl CreateProgressControl() {
            return new ProgressForm("Modifying created objects", 0, 100);
        }
        protected override void OnFrameAssigned() {
            base.OnFrameAssigned();
            creationController = Frame.GetController<CreateDemoObjectsPoolController>();
        }
        protected override void OnActivated() {
            base.OnActivated();
            creationController.OperationCompleted += new EventHandler(CreationController_ObjectCreationCompleted);
        }
		protected override void OnDeactivated() {
			base.OnDeactivated();
            creationController.OperationCompleted -= new EventHandler(CreationController_ObjectCreationCompleted);
        }
        public AuditPerformanceObjectsBatchModificationController() {
            this.TargetObjectType = typeof(FullyAuditedBatchCreationObject);
            this.TargetViewType = ViewType.ListView;
        }
    }
}
