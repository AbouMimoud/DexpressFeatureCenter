using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.ExpressApp;
using FeatureCenter.Module.Actions;

namespace FeatureCenter.Module.Win.Actions {
	public partial class WebDisableControllersForNonPersistentObjects : DisableControllersForNonPersistentObjects {
		public WebDisableControllersForNonPersistentObjects() {
			controllersToDeactivate.Add(typeof(DevExpress.ExpressApp.Web.SystemModule.ListViewController));
		}
	}
}
