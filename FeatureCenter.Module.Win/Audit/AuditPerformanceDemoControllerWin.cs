using System;

using DevExpress.Xpo;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Persistent.AuditTrail;

namespace FeatureCenter.Module.Win.Audit {
    public class AuditPerformanceObjectCreationCustomizationController : ViewController {
        private CreateDemoObjectsPoolController createDemoObjectsController;

        private void AuditDataStore_CustomFindWeakReference(object sender, CustomFindWeakReferenceEventArgs e) {
            e.Handled = true;
        }
        private void CreateDemoObjectsController_UpdatingSessionCreated(object sender, ObjectSpaceEventArgs e) {
            AuditTrailService.Instance.AuditDataStore.CustomFindWeakReference += new EventHandler<CustomFindWeakReferenceEventArgs>(AuditDataStore_CustomFindWeakReference);
			if(e.ObjectSpace is XPObjectSpace) {
				BeginSessionAudit(((XPObjectSpace)e.ObjectSpace).Session);
			}
        }
        private void CreateDemoObjectsController_UpdatingSessionCommitted(object sender, ObjectSpaceEventArgs e) {
			if(e.ObjectSpace is XPObjectSpace) {
				AuditTrailService.Instance.SaveAuditData(((XPObjectSpace)e.ObjectSpace).Session);
				BeginSessionAudit(((XPObjectSpace)e.ObjectSpace).Session);
			}
        }
        private void CreateDemoObjectsController_UpdatingSessionDisposing(object sender, ObjectSpaceEventArgs e) {
            AuditTrailService.Instance.AuditDataStore.CustomFindWeakReference -= new EventHandler<CustomFindWeakReferenceEventArgs>(AuditDataStore_CustomFindWeakReference);
			if(e.ObjectSpace is XPObjectSpace) {
				AuditTrailService.Instance.EndSessionAudit(((XPObjectSpace)e.ObjectSpace).Session);
			}
        }
        private void BeginSessionAudit(Session session) {
            ObjectAuditingMode auditingMode = typeof(PartiallyAuditedBatchCreationObject).IsAssignableFrom(((ListView)View).ObjectTypeInfo.Type) ? ObjectAuditingMode.CreationOnly : ObjectAuditingMode.Full;
            AuditTrailService.Instance.BeginSessionAudit(session, AuditTrailStrategy.OnObjectChanged, auditingMode);
        }
        protected override void OnFrameAssigned() {
            base.OnFrameAssigned();
            createDemoObjectsController = Frame.GetController<CreateDemoObjectsPoolController>();
        }
        protected override void OnActivated() {
            base.OnActivated();
            createDemoObjectsController.UpdatingSessionCommitted += new EventHandler<ObjectSpaceEventArgs>(CreateDemoObjectsController_UpdatingSessionCommitted);
            createDemoObjectsController.UpdatingSessionCreated += new EventHandler<ObjectSpaceEventArgs>(CreateDemoObjectsController_UpdatingSessionCreated);
            createDemoObjectsController.UpdatingSessionDisposing += new EventHandler<ObjectSpaceEventArgs>(CreateDemoObjectsController_UpdatingSessionDisposing);
        }
		protected override void OnDeactivated() {
			base.OnDeactivated();
            createDemoObjectsController.UpdatingSessionCommitted -= new EventHandler<ObjectSpaceEventArgs>(CreateDemoObjectsController_UpdatingSessionCommitted);
            createDemoObjectsController.UpdatingSessionCreated -= new EventHandler<ObjectSpaceEventArgs>(CreateDemoObjectsController_UpdatingSessionCreated);
            createDemoObjectsController.UpdatingSessionDisposing -= new EventHandler<ObjectSpaceEventArgs>(CreateDemoObjectsController_UpdatingSessionDisposing);
        }
        public AuditPerformanceObjectCreationCustomizationController() {
            this.TargetObjectType = typeof(AuditPerformanceObject);
            this.TargetViewType = ViewType.ListView;
        }
    }
}
