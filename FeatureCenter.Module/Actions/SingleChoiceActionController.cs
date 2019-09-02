using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.Actions;
using DevExpress.Xpo;

namespace FeatureCenter.Module.Actions {
	public class SingleChoiceActionController : ActionBaseController {
		public SingleChoiceActionController() {
			SingleChoiceAction singleChoiceAction = new SingleChoiceAction(this, "SingleChoiceDemoAction", PredefinedCategory.Edit);
			singleChoiceAction.Execute += new SingleChoiceActionExecuteEventHandler(SingleChoiceActionRootObject.singleChoiceAction_Execute);
			singleChoiceAction.ImageName = ActionsDemoStrings.SingleChoiceActionImageName;
			singleChoiceAction.ToolTip = ActionsDemoStrings.SingleChoiceActionTooltip;
			singleChoiceAction.ItemType = SingleChoiceActionItemType.ItemIsOperation;
			SingleChoiceActionRootObject.CreateDefaultItems(singleChoiceAction);
		}
	}
}
