using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.Persistent.Base;
using DevExpress.XtraNavBar;
using System.Drawing;
using DevExpress.ExpressApp.Win.Templates.ActionContainers;

namespace FeatureCenter.Module.Win {
    public partial class CustomizeNavBarAppearanceController : WindowController {
		private NavigationActionContainer navigationActionContainer;
        private void window_TemplateChanged(object sender, EventArgs e) {
            if(Window.Template != null) {
				UnsubscribeFromContainerEvents();
				foreach(object actionContainer in Window.Template.GetContainers()) {
					navigationActionContainer = actionContainer as NavigationActionContainer;
					if(navigationActionContainer != null) {
						SubscribeToContainerEvents();
						SetupNavBar();
						break;
					}
                }
            }
        }
		private void SubscribeToContainerEvents() {
			if(navigationActionContainer != null) {
				navigationActionContainer.NavigationControlCreated += new EventHandler<EventArgs>(navigationActionContainer_NavigationControlCreated);
			}
		}
		private void UnsubscribeFromContainerEvents() {
			if(navigationActionContainer != null) {
				navigationActionContainer.NavigationControlCreated -= new EventHandler<EventArgs>(navigationActionContainer_NavigationControlCreated);
			}
		}
		private void navigationActionContainer_NavigationControlCreated(object sender, EventArgs e) {
			SetupNavBar();
		}
		private void SetupNavBar() {
			if(navigationActionContainer != null && navigationActionContainer.NavigationControl is NavBarNavigationControl) {
				NavBarNavigationControl navBarNavigationControl = navigationActionContainer.NavigationControl as NavBarNavigationControl;
				navBarNavigationControl.SkinExplorerBarViewScrollStyle = SkinExplorerBarViewScrollStyle.ScrollBar;
				//navBarNavigationControl.PaintStyleKind = NavBarViewKind.ExplorerBar; //B33005, Demos: FeatureCenter looks ugly with skins "Flat", "Ultra Flat" and "Windows Theme" (don't supported with "SkinExplorerBarView" by XtraNavBar)
				//navBarNavigationControl.GroupStyle = NavBarGroupStyle.SmallIconsList;
			}
		}
		protected override void OnActivated() {
            base.OnActivated();
            Window.TemplateChanged += new EventHandler(window_TemplateChanged);
        }
		protected override void OnDeactivated() {
            Window.TemplateChanged -= new EventHandler(window_TemplateChanged);
			UnsubscribeFromContainerEvents();
			navigationActionContainer = null;
			base.OnDeactivated();
        }
    }
}
