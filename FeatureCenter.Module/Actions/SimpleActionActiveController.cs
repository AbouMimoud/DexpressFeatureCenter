using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.Actions;
using DevExpress.Xpo;
using DevExpress.ExpressApp;

namespace FeatureCenter.Module.Actions {
	public class SimpleActionController : ActionBaseController {
		public SimpleActionController() {
			SimpleAction simpleAction = new SimpleAction(this, "SimpleDemoAction", PredefinedCategory.Edit);
			simpleAction.Execute += new SimpleActionExecuteEventHandler(SimpleActionRootObject.simpleAction_Execute);
			simpleAction.ImageName = ActionsDemoStrings.SimpleActionImageName;
			simpleAction.ToolTip = ActionsDemoStrings.ToolTip;
		}
	}
}
