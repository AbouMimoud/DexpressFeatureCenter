using DevExpress.ExpressApp.Web.SystemModule;
using FeatureCenter.Module.Navigation;

namespace FeatureCenter.Module.Web.Navigation {
    public class WebNavigationObjectDetailViewController : NavigationObjectDetailViewController {
        protected override void OnActivated() {
            base.OnActivated();
            WebConfirmUnsavedChangesDetailViewController confController = Frame.GetController<WebConfirmUnsavedChangesDetailViewController>();
            confController.Active.SetItemValue("DisableForNavigationObject", false);
        }

        protected override void OnDeactivated() {
            base.OnDeactivated();
            WebConfirmUnsavedChangesDetailViewController confController = Frame.GetController<WebConfirmUnsavedChangesDetailViewController>();
            confController.Active.SetItemValue("DisableForNavigationObject", true);
        }
    }
}
