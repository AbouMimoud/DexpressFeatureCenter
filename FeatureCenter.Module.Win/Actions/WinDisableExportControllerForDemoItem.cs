using System;
using System.Data;
using FeatureCenter.Module.Actions;

namespace FeatureCenter.Module.Win.Actions {
	public class WinDisableControllersForNonPersistentObjects : DisableControllersForNonPersistentObjects {
	}
	public class WinDisableExportControllerForDemoItem : DisableControllersForNonPersistentObjects {
		public WinDisableExportControllerForDemoItem() {
			TargetObjectType = typeof(DemoItem);
			controllersToDeactivate.Add(typeof(DevExpress.ExpressApp.Win.SystemModule.WinExportController));
		}
	}
}
