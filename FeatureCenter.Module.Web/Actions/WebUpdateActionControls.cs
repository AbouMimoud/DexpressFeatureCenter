using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.ExpressApp;
using FeatureCenter.Module.Actions;
using DevExpress.ExpressApp.Utils;
using System.ComponentModel;
using System.Web;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Web;
using DevExpress.ExpressApp.Web.Templates;

namespace FeatureCenter.Module.Web.Actions {
	public class WebUpdateSingleChoiceActionControlController : ViewController {
		private void View_CurrentObjectChanged(object sender, EventArgs e) {
			if(View.CurrentObject != null) {
				((SingleChoiceAction)(View.CurrentObject)).ItemTypeChanged += new EventHandler(SingleChoiceAction_ItemTypeChanged);
			}
		}
		private void View_QueryCanChangeCurrentObject(object sender, CancelEventArgs e) {
			if(View.CurrentObject != null) {
				((SingleChoiceAction)(View.CurrentObject)).ItemTypeChanged -= new EventHandler(SingleChoiceAction_ItemTypeChanged);
			}
		}
		private void SingleChoiceAction_ItemTypeChanged(object sender, EventArgs e) {
            ICallbackManagerHolder holder = WebWindow.CurrentRequestPage as ICallbackManagerHolder;
            if(holder != null) {
                string redirectScript = holder.CallbackManager.GetScript();
                WebWindow.CurrentRequestWindow.RegisterStartupScript("RedirectScript", redirectScript);
            }
		}
		protected override void OnActivated() {
			base.OnActivated();
			View.QueryCanChangeCurrentObject += new EventHandler<CancelEventArgs>(View_QueryCanChangeCurrentObject);
			View.CurrentObjectChanged += new EventHandler(View_CurrentObjectChanged);
		}
		protected override void OnDeactivated() {
			View.QueryCanChangeCurrentObject -= new EventHandler<CancelEventArgs>(View_QueryCanChangeCurrentObject);
			View.CurrentObjectChanged -= new EventHandler(View_CurrentObjectChanged);
			base.OnDeactivated();
		}
		public WebUpdateSingleChoiceActionControlController()
			: base() {
			TargetObjectType = typeof(SingleChoiceAction);
			TargetViewType = ViewType.DetailView;
		}
	}
}
