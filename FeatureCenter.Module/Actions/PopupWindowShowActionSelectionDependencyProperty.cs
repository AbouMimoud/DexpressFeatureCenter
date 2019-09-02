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
	public class PopupWindowShowActionSelectionDependencyController : ActionBaseController {
		public PopupWindowShowActionSelectionDependencyController() {
			TargetObjectType = typeof(DemoItem);
			targetProperty = "SelectionDependency";

			PopupWindowShowAction popupWindowShowAction = new PopupWindowShowAction(this, "PopupWindowShowActionIndependent", PredefinedCategory.Edit);
			popupWindowShowAction.CustomizePopupWindowParams += new CustomizePopupWindowParamsEventHandler(PopupWindowShowActionRootObject.popupWindowShowAction_CustomizePopupWindowParams);
			popupWindowShowAction.Execute += new PopupWindowShowActionExecuteEventHandler(PopupWindowShowActionRootObject.popupWindowShowAction_Execute);
			popupWindowShowAction.SelectionDependencyType = SelectionDependencyType.Independent;
			popupWindowShowAction.Caption = popupWindowShowAction.SelectionDependencyType.ToString();
			popupWindowShowAction.ToolTip = ActionsDemoStrings.SelectionDependencyIndependentTooltip;

			popupWindowShowAction = new PopupWindowShowAction(this, "PopupWindowShowActionRequireMultipleObjects", PredefinedCategory.Edit);
			popupWindowShowAction.CustomizePopupWindowParams += new CustomizePopupWindowParamsEventHandler(PopupWindowShowActionRootObject.popupWindowShowAction_CustomizePopupWindowParams);
			popupWindowShowAction.Execute += new PopupWindowShowActionExecuteEventHandler(PopupWindowShowActionRootObject.popupWindowShowAction_Execute);
			popupWindowShowAction.SelectionDependencyType = SelectionDependencyType.RequireMultipleObjects;
			popupWindowShowAction.Caption = popupWindowShowAction.SelectionDependencyType.ToString();
			popupWindowShowAction.ToolTip = ActionsDemoStrings.SelectionDependencyRequireMultipleObjectsTooltip;

			popupWindowShowAction = new PopupWindowShowAction(this, "PopupWindowShowActionRequireSingleObject", PredefinedCategory.Edit);
			popupWindowShowAction.CustomizePopupWindowParams += new CustomizePopupWindowParamsEventHandler(PopupWindowShowActionRootObject.popupWindowShowAction_CustomizePopupWindowParams);
			popupWindowShowAction.Execute += new PopupWindowShowActionExecuteEventHandler(PopupWindowShowActionRootObject.popupWindowShowAction_Execute);
			popupWindowShowAction.SelectionDependencyType = SelectionDependencyType.RequireSingleObject;
			popupWindowShowAction.Caption = popupWindowShowAction.SelectionDependencyType.ToString();
			popupWindowShowAction.ToolTip = ActionsDemoStrings.SelectionDependencyRequireSingleObjectTooltip;
		}
	}
}
