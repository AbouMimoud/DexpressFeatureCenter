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
	public class ParametrizedActionSelectionDependencyController : ActionBaseController {
		public ParametrizedActionSelectionDependencyController() {
			TargetObjectType = typeof(DemoItem);
			targetProperty = "SelectionDependency";

			ParametrizedAction parametrizedAction = new ParametrizedAction(this, "ParametrizedActionIndependent", PredefinedCategory.Edit, typeof(string));
			parametrizedAction.Execute += new ParametrizedActionExecuteEventHandler(ParametrizedActionRootObject.parametrizedAction_Execute);
			parametrizedAction.SelectionDependencyType = SelectionDependencyType.Independent;
			parametrizedAction.Caption = parametrizedAction.SelectionDependencyType.ToString();
			parametrizedAction.ToolTip = ActionsDemoStrings.SelectionDependencyIndependentTooltip;

			parametrizedAction = new ParametrizedAction(this, "ParametrizedActionRequireMultipleObjects", PredefinedCategory.Edit, typeof(string));
			parametrizedAction.Execute += new ParametrizedActionExecuteEventHandler(ParametrizedActionRootObject.parametrizedAction_Execute);
			parametrizedAction.SelectionDependencyType = SelectionDependencyType.RequireMultipleObjects;
			parametrizedAction.Caption = parametrizedAction.SelectionDependencyType.ToString();
			parametrizedAction.ToolTip = ActionsDemoStrings.SelectionDependencyRequireMultipleObjectsTooltip;

			parametrizedAction = new ParametrizedAction(this, "ParametrizedActionRequireSingleObject", PredefinedCategory.Edit, typeof(string));
			parametrizedAction.Execute += new ParametrizedActionExecuteEventHandler(ParametrizedActionRootObject.parametrizedAction_Execute);
			parametrizedAction.SelectionDependencyType = SelectionDependencyType.RequireSingleObject;
			parametrizedAction.Caption = parametrizedAction.SelectionDependencyType.ToString();
			parametrizedAction.ToolTip = ActionsDemoStrings.SelectionDependencyRequireSingleObjectTooltip;
		}
	}
}
