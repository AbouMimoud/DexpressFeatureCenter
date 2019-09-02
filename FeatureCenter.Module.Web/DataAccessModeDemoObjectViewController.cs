using System;

using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Web.SystemModule;
using FeatureCenter.Module.ListEditors;

namespace FeatureCenter.Module.Web {
	public class DataAccessModeDemoObjectViewController : ViewController {
		private const String key = "Web";

		protected override void OnActivated() {
			base.OnActivated();
			View.AllowNew[key] = false;
			View.AllowEdit[key] = false;
			View.AllowDelete[key] = false;
			Frame.GetController<ListViewController>().Active[key] = false;
		}
		protected override void OnDeactivated() {
			base.OnDeactivated();
			Frame.GetController<ListViewController>().Active.RemoveItem(key);
		}

		public DataAccessModeDemoObjectViewController()
			: base() {
			TypeOfView = typeof(ObjectView);
			TargetObjectType = typeof(DataAccessModeDemoObject);
			TargetViewNesting = Nesting.Any;
		}
	}
}
