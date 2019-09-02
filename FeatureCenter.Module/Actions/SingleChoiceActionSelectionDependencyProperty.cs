using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using DevExpress.Xpo;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Editors;
using DevExpress.Persistent.Base;

namespace FeatureCenter.Module.Actions {
	public class SingleChoiceActionSelectionDependencyController : ActionBaseController {
		public SingleChoiceActionSelectionDependencyController() {
			TargetObjectType = typeof(DemoItem);
			targetProperty = "SelectionDependency";

            SingleChoiceAction singleChoiceAction = new SingleChoiceAction(this, "SingleChoiceActionIndependent", PredefinedCategory.Edit);
			singleChoiceAction.Execute += new SingleChoiceActionExecuteEventHandler(SingleChoiceActionRootObject.singleChoiceAction_Execute);
			singleChoiceAction.SelectionDependencyType = SelectionDependencyType.Independent;
			singleChoiceAction.ItemType = SingleChoiceActionItemType.ItemIsOperation;
			singleChoiceAction.Caption = singleChoiceAction.SelectionDependencyType.ToString();
			singleChoiceAction.ToolTip = ActionsDemoStrings.SelectionDependencyIndependentTooltip;
			SingleChoiceActionRootObject.CreateDefaultItems(singleChoiceAction);

            singleChoiceAction = new SingleChoiceAction(this, "SingleChoiceActionRequireMultipleObjects", PredefinedCategory.Edit);
			singleChoiceAction.Execute += new SingleChoiceActionExecuteEventHandler(SingleChoiceActionRootObject.singleChoiceAction_Execute);
			singleChoiceAction.SelectionDependencyType = SelectionDependencyType.RequireMultipleObjects;
			singleChoiceAction.ItemType = SingleChoiceActionItemType.ItemIsOperation;
			singleChoiceAction.Caption = singleChoiceAction.SelectionDependencyType.ToString();
			singleChoiceAction.ToolTip = ActionsDemoStrings.SelectionDependencyRequireMultipleObjectsTooltip;
			SingleChoiceActionRootObject.CreateDefaultItems(singleChoiceAction);

            singleChoiceAction = new SingleChoiceAction(this, "SingleChoiceActionRequireSingleObject", PredefinedCategory.Edit);
			singleChoiceAction.Execute += new SingleChoiceActionExecuteEventHandler(SingleChoiceActionRootObject.singleChoiceAction_Execute);
			singleChoiceAction.SelectionDependencyType = SelectionDependencyType.RequireSingleObject;
			singleChoiceAction.ItemType = SingleChoiceActionItemType.ItemIsOperation;
			singleChoiceAction.Caption = singleChoiceAction.SelectionDependencyType.ToString();
			singleChoiceAction.ToolTip = ActionsDemoStrings.SelectionDependencyRequireSingleObjectTooltip;
			SingleChoiceActionRootObject.CreateDefaultItems(singleChoiceAction);
		}
	}
}
