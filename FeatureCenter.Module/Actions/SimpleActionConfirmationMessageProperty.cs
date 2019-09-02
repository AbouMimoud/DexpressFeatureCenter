using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.ExpressApp.Actions;
using DevExpress.Persistent.Base;

namespace FeatureCenter.Module.Actions {
	public class SimpleActionConfirmationMessageIsEmptyController : ActionBaseController {
		public SimpleActionConfirmationMessageIsEmptyController() {
			targetProperty = "ConfirmationMessageIsEmpty";
			SimpleAction simpleAction = new SimpleAction(this, "SimpleAction" + targetProperty, PredefinedCategory.Edit);
			simpleAction.Execute += new SimpleActionExecuteEventHandler(SimpleActionRootObject.simpleAction_Execute);
			simpleAction.Caption = ActionsDemoStrings.ConfirmationMessageIsEmpty;
			simpleAction.ToolTip = ActionsDemoStrings.ConfirmationMessageIsEmptyTooltip;
		}
	}

	public class SimpleActionConfirmationMessageNotEmptyController : ActionBaseController {
		public SimpleActionConfirmationMessageNotEmptyController() {
			targetProperty = "ConfirmationMessageNotEmpty";
            SimpleAction simpleAction = new SimpleAction(this, "SimpleAction" + targetProperty, PredefinedCategory.Edit);
			simpleAction.ConfirmationMessage = ActionsDemoStrings.ConfirmationMessage;
			simpleAction.Execute += new SimpleActionExecuteEventHandler(SimpleActionRootObject.simpleAction_Execute);
			simpleAction.Caption = ActionsDemoStrings.ConfirmationMessageNotEmpty;
			simpleAction.ToolTip = ActionsDemoStrings.ConfirmationMessageNotEmptyTooltip;
		}
	}
}
