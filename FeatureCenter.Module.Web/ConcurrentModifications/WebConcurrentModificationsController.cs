using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.Persistent.Base;
using FeatureCenter.Module.ConcurrentModifications;

namespace FeatureCenter.Module.Web.ConcurrentModifications {
    public class WebConcurrentModificationsController : ConcurrentModificationsController {
        public WebConcurrentModificationsController() {
            SimpleAction concurrentModificationsSaveAction = new SimpleAction(this, "ConcurrentModificationsSave", PredefinedCategory.ObjectsCreation);
            concurrentModificationsSaveAction.Caption = "Save";
            concurrentModificationsSaveAction.ImageName = "Action_Save";
            concurrentModificationsSaveAction.PaintStyle = DevExpress.ExpressApp.Templates.ActionItemPaintStyle.CaptionAndImage;
            concurrentModificationsSaveAction.Execute += ConcurrentModificationsSaveAction_Execute;
        }
        private void ConcurrentModificationsSaveAction_Execute(object sender, SimpleActionExecuteEventArgs e) {
            Frame.GetController<ModificationsController>().SaveAction.DoExecute();
        }
        protected override void OnActivated() {
            base.OnActivated();
            View.ViewEditMode = DevExpress.ExpressApp.Editors.ViewEditMode.Edit;
        }
    }
}
