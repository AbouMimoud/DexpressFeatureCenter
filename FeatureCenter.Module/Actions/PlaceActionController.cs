using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.Persistent.Base;

namespace FeatureCenter.Module.Actions {
	public class PlaceActionController : ViewController {
		public virtual void RemoveActions() { }
		public virtual void PlaceAction(string actionContainerName, ActionBase action) {
			RegisterActions(action);
			UpdateActionActivity(action);
		}
	}
}
