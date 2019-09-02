using System;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Web;
using DevExpress.ExpressApp.Web.Layout;
using DevExpress.ExpressApp.Web.Templates;
using FeatureCenter.Module.Actions;

namespace FeatureCenter.Module.Web.Layout {
    public class DisableControllersForItemTemplatesObject : DisableControllersByConditionViewController {
        protected override bool GetIsDisabled() {
            return true;
        }
        public DisableControllersForItemTemplatesObject() {
            TargetObjectType = typeof(ItemTemplates);
            controllersToDeactivate.Remove(typeof(ListViewProcessCurrentObjectController));
            controllersToDeactivate.Remove(typeof(ModificationsController));
        }
    }
    public class WebLayoutDemoController : ViewController<DetailView> {
        private void ObjectSpace_ObjectChanged(object sender, ObjectChangedEventArgs e) {
            if(e.Object == View.CurrentObject) {
                ICallbackManagerHolder holder = WebWindow.CurrentRequestPage as ICallbackManagerHolder;
                if(holder != null) {
                    string refreshScript = holder.CallbackManager.GetScript();
                    WebWindow.CurrentRequestWindow.RegisterStartupScript("RefreshScript", refreshScript);
                }
            }
        }
        private void View_ControlsCreating(object sender, EventArgs e) {
            UpdateLayoutManagerTemplates();
        }
        private void UpdateLayoutManagerTemplates() {
            ItemTemplates obj = (ItemTemplates)View.CurrentObject;
            WebLayoutManager layoutManager = (WebLayoutManager)View.LayoutManager;
            layoutManager.LayoutItemTemplate = obj.LayoutItemTemplate == LayoutItemTemplateType.Default ? new LayoutItemTemplate() : new CustomLayoutItemTemplate();
            layoutManager.LayoutGroupTemplate = obj.LayoutGroupTemplate == LayoutItemTemplateType.Default ? new LayoutGroupTemplate() : new CustomLayoutGroupTemplate();
            layoutManager.TabbedGroupTemplate = obj.TabbedGroupTemplate == LayoutItemTemplateType.Default ? new TabbedGroupTemplate() : new CustomLayoutTabbedGroupTemplate();
        }
        protected override void OnActivated() {
            base.OnActivated();
            View.ControlsCreating += new EventHandler(View_ControlsCreating);
            ObjectSpace.ObjectChanged += new EventHandler<ObjectChangedEventArgs>(ObjectSpace_ObjectChanged);
        }
        protected override void OnDeactivated() {
            View.ControlsCreating -= new EventHandler(View_ControlsCreating);
            ObjectSpace.ObjectChanged -= new EventHandler<ObjectChangedEventArgs>(ObjectSpace_ObjectChanged);
            base.OnDeactivated();
        }
        public WebLayoutDemoController() {
            TargetObjectType = typeof(ItemTemplates);
        }
    }
}
