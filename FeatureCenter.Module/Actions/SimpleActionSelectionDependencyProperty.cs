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
	public class SimpleActionSelectionDependencyController : ActionBaseController {
		public SimpleActionSelectionDependencyController() {
			TargetObjectType = typeof(DemoItem);
			targetProperty = "SelectionDependency";

            SimpleAction simpleAction = new SimpleAction(this, "SimpleActionIndependent", PredefinedCategory.Edit);
			simpleAction.Execute += new SimpleActionExecuteEventHandler(SimpleActionRootObject.simpleAction_Execute);
			simpleAction.SelectionDependencyType = SelectionDependencyType.Independent;
			simpleAction.Caption = simpleAction.SelectionDependencyType.ToString();
			simpleAction.ToolTip = ActionsDemoStrings.SelectionDependencyIndependentTooltip;

            simpleAction = new SimpleAction(this, "SimpleActionRequireMultipleObjects", PredefinedCategory.Edit);
			simpleAction.Execute += new SimpleActionExecuteEventHandler(SimpleActionRootObject.simpleAction_Execute);
			simpleAction.SelectionDependencyType = SelectionDependencyType.RequireMultipleObjects;
			simpleAction.Caption = simpleAction.SelectionDependencyType.ToString();
			simpleAction.ToolTip = ActionsDemoStrings.SelectionDependencyRequireMultipleObjectsTooltip;

            simpleAction = new SimpleAction(this, "SimpleActionRequireSingleObject", PredefinedCategory.Edit);
			simpleAction.Execute += new SimpleActionExecuteEventHandler(SimpleActionRootObject.simpleAction_Execute);
			simpleAction.SelectionDependencyType = SelectionDependencyType.RequireSingleObject;
			simpleAction.Caption = simpleAction.SelectionDependencyType.ToString();
			simpleAction.ToolTip = ActionsDemoStrings.SelectionDependencyRequireSingleObjectTooltip;
		}
	}
}
