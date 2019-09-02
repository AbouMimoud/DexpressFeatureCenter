using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.ExpressApp.Actions;
using DevExpress.Persistent.Base;

namespace FeatureCenter.Module.Actions {
	public class SingleChoiceActionConfirmationMessageIsEmptyController : ActionBaseController {
		public SingleChoiceActionConfirmationMessageIsEmptyController() {
			targetProperty = "ConfirmationMessageIsEmpty";
            SingleChoiceAction singleChoiceAction = new SingleChoiceAction(this, "SingleChoiceAction" + targetProperty, PredefinedCategory.Edit);
			singleChoiceAction.Execute += new SingleChoiceActionExecuteEventHandler(SingleChoiceActionRootObject.singleChoiceAction_Execute);
			SingleChoiceActionRootObject.CreateDefaultItems(singleChoiceAction);
			singleChoiceAction.ItemType = SingleChoiceActionItemType.ItemIsOperation;
			singleChoiceAction.Caption = ActionsDemoStrings.ConfirmationMessageIsEmpty;
			singleChoiceAction.ToolTip = ActionsDemoStrings.ConfirmationMessageIsEmptyTooltip;
		}
	}

	public class SingleChoiceActionConfirmationMessageNotEmptyController : ActionBaseController {
		public SingleChoiceActionConfirmationMessageNotEmptyController() {
			targetProperty = "ConfirmationMessageNotEmpty";
            SingleChoiceAction singleChoiceAction = new SingleChoiceAction(this, "SingleChoiceAction" + targetProperty, PredefinedCategory.Edit);
			singleChoiceAction.Execute += new SingleChoiceActionExecuteEventHandler(SingleChoiceActionRootObject.singleChoiceAction_Execute);
			SingleChoiceActionRootObject.CreateDefaultItems(singleChoiceAction);
			singleChoiceAction.ItemType = SingleChoiceActionItemType.ItemIsOperation;
			singleChoiceAction.ConfirmationMessage = ActionsDemoStrings.ConfirmationMessage;
			singleChoiceAction.Caption = ActionsDemoStrings.ConfirmationMessageNotEmpty;
			singleChoiceAction.ToolTip = ActionsDemoStrings.ConfirmationMessageNotEmptyTooltip;
		}
	}
}
