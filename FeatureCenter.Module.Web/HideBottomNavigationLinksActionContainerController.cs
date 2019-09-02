using System;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Web.Templates.ActionContainers;

namespace FeatureCenter.Module.Web {
	public class HideBottomNavigationLinksActionContainerController : WindowController {
		private void Window_TemplateChanged(object sender, EventArgs e) {
			if(Window.Template != null) {
				foreach(object container in Window.Template.GetContainers()) {
					if(container is QuickAccessNavigationActionContainer) {
						((QuickAccessNavigationActionContainer)container).Visible = false;
					}
				}
			}
		}
		protected override void OnFrameAssigned() {
			base.OnFrameAssigned();
		}
		protected override void OnActivated() {
			base.OnActivated();
			Window.TemplateChanged += new EventHandler(Window_TemplateChanged);
		}
		protected override void OnDeactivated() {
			Window.TemplateChanged -= new EventHandler(Window_TemplateChanged);
			base.OnDeactivated();
		}
		public HideBottomNavigationLinksActionContainerController()
			: base() {
			TargetWindowType = WindowType.Main;
		}
	}
}
