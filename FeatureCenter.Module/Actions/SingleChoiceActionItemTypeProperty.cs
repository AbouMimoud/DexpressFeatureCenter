using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.ExpressApp.Actions;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace FeatureCenter.Module.Actions {
	public class ItemTypeModeController : ActionBaseController {
		public ItemTypeModeController() {
			SingleChoiceAction singleChoiceAction = new SingleChoiceAction(this, "ItemIsMode", PredefinedCategory.Edit);
			singleChoiceAction.Execute += new SingleChoiceActionExecuteEventHandler(SingleChoiceActionRootObject.singleChoiceAction_Execute);
            SingleChoiceActionRootObject.CreateDefaultItems(singleChoiceAction, false);
			singleChoiceAction.ItemType = SingleChoiceActionItemType.ItemIsMode;
			singleChoiceAction.ToolTip = ActionsDemoStrings.SingleChoiceActionItemIsModeTooltip;
		}
	}

	public class ItemTypeOperationController : ActionBaseController {
		public ItemTypeOperationController() {
            SingleChoiceAction singleChoiceAction = new SingleChoiceAction(this, "ItemIsOperation", PredefinedCategory.Edit);
			singleChoiceAction.Execute += new SingleChoiceActionExecuteEventHandler(SingleChoiceActionRootObject.singleChoiceAction_Execute);
            SingleChoiceActionRootObject.CreateDefaultItems(singleChoiceAction, true);
			singleChoiceAction.ItemType = SingleChoiceActionItemType.ItemIsOperation;
			singleChoiceAction.ToolTip = ActionsDemoStrings.SingleChoiceActionItemIsOperationTooltip;
		}
	}

}
