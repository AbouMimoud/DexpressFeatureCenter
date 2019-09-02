using System;
using System.Drawing;
using System.Web;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Win.Templates.ActionContainers;
using DevExpress.XtraNavBar;

namespace FeatureCenter.Module.Win.Actions {
    public class WinCustomizeNavigationActionControlController : WindowController {
        protected override void OnActivated() {
            base.OnActivated();
            Frame.GetController<ShowNavigationItemController>().ShowNavigationItemAction.CustomizeControl += ShowNavigationItemAction_CustomizeControl;
        }
        protected override void OnDeactivated() {
            Frame.GetController<ShowNavigationItemController>().ShowNavigationItemAction.CustomizeControl -= ShowNavigationItemAction_CustomizeControl;
            base.OnDeactivated();
        }
        private void ShowNavigationItemAction_CustomizeControl(object sender, DevExpress.ExpressApp.Actions.CustomizeControlEventArgs e) {
            NavBarNavigationControl navBar = e.Control as NavBarNavigationControl;
            if(navBar != null) {
                // Customize NavBar
                navBar.SkinExplorerBarViewScrollStyle = SkinExplorerBarViewScrollStyle.ScrollBar;
                navBar.PaintStyleKind = NavBarViewKind.ExplorerBar;
            }
            else {
                TreeListNavigationControl treeList = e.Control as TreeListNavigationControl;
                if(treeList != null) {
                    // Customize TreeList
                }
            }
        }
    }
}
