using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.Actions;
using DevExpress.Xpo;

namespace FeatureCenter.Module.Actions {
	public class ParametrizedActionController : ActionBaseController {
		public ParametrizedActionController() {
			ParametrizedAction parametrizedAction = new ParametrizedAction(this, "ParametrizedDemoAction", PredefinedCategory.Edit, typeof(string));
			parametrizedAction.Execute += new ParametrizedActionExecuteEventHandler(ParametrizedActionRootObject.parametrizedAction_Execute);
			parametrizedAction.Value = ActionsDemoStrings.SimpleString;
			parametrizedAction.ImageName = ActionsDemoStrings.ParametrizedActionImageName;
			parametrizedAction.ToolTip = ActionsDemoStrings.ParametrizedActionTooltip;
		}
	}
}
