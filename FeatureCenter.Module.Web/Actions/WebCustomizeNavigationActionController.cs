using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Web.Templates.ActionContainers;
using DevExpress.Web;

namespace FeatureCenter.Module.Web.Actions {

    public class WebCustomizeNavigationActionController : WindowController {
        public WebCustomizeNavigationActionController() {
            TargetWindowType = WindowType.Main;
        }
        protected override void OnActivated() {
            base.OnActivated();
            Frame.GetController<ShowNavigationItemController>().ShowNavigationItemAction.CustomizeControl += ShowNavigationItemAction_CustomizeControl;
        }
        protected override void OnDeactivated() {
            Frame.GetController<ShowNavigationItemController>().ShowNavigationItemAction.CustomizeControl -= ShowNavigationItemAction_CustomizeControl;
            base.OnDeactivated();
        }
        private void ShowNavigationItemAction_CustomizeControl(object sender, DevExpress.ExpressApp.Actions.CustomizeControlEventArgs e) {
            ASPxNavBar navBar = e.Control as ASPxNavBar;
            if(navBar != null) {
                // Customize the main ASPxNavBar control. 
                navBar.EnableAnimation = true;
                foreach(NavBarGroup group in navBar.Groups) {
                    foreach(NavBarItem item in group.Items) {
                        if(item is NavBarTreeViewItem) {
                            ASPxTreeView innerTreeView = ((NavBarTreeViewItem)item).TreeViewNavigationControl.Control;
                            // Customize the inner ASPxTreeView control inside the navigation group.   
                            innerTreeView.ShowExpandButtons = false;
                        }
                    }
                }
            }
            else {
                ASPxTreeView mainTreeView = e.Control as ASPxTreeView;
                if(mainTreeView != null) {
                    // Customize the main ASPxTreeView control. 
                    mainTreeView.ShowExpandButtons = false;
                }
            }
        }
    }
}
