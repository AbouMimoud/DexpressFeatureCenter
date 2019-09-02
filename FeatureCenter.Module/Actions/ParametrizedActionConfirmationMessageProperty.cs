using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.ExpressApp.Actions;
using DevExpress.Persistent.Base;

namespace FeatureCenter.Module.Actions {
	public class ParametrizedActionConfirmationMessageIsEmptyController : ActionBaseController {
		public ParametrizedActionConfirmationMessageIsEmptyController() {
			targetProperty = "ConfirmationMessageIsEmpty";
			ParametrizedAction parametrizedAction = new ParametrizedAction(this, "ParametrizedAction" + targetProperty, PredefinedCategory.Edit, typeof(string));
			parametrizedAction.Execute += new ParametrizedActionExecuteEventHandler(ParametrizedActionRootObject.parametrizedAction_Execute);
			parametrizedAction.Caption = ActionsDemoStrings.ConfirmationMessageIsEmpty;
			parametrizedAction.ToolTip = ActionsDemoStrings.ConfirmationMessageIsEmptyTooltip;
		}
	}

	public class ParametrizedActionConfirmationMessageNotEmptyController : ActionBaseController {
		public ParametrizedActionConfirmationMessageNotEmptyController() {
			targetProperty = "ConfirmationMessageNotEmpty";
			ParametrizedAction parametrizedAction = new ParametrizedAction(this, "ParametrizedAction" + targetProperty, PredefinedCategory.Edit, typeof(string));
			parametrizedAction.Execute += new ParametrizedActionExecuteEventHandler(ParametrizedActionRootObject.parametrizedAction_Execute);
			parametrizedAction.ConfirmationMessage = ActionsDemoStrings.ConfirmationMessage;
			parametrizedAction.Caption = ActionsDemoStrings.ConfirmationMessageNotEmpty;
			parametrizedAction.ToolTip = ActionsDemoStrings.ConfirmationMessageNotEmptyTooltip;
		}
	}
}
