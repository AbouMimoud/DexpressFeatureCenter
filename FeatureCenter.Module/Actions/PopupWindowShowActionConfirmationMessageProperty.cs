using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.ExpressApp.Actions;
using DevExpress.Persistent.Base;

namespace FeatureCenter.Module.Actions {
	public class PopupWindowShowActionConfirmationMessageIsEmptyController : ActionBaseController {
		public PopupWindowShowActionConfirmationMessageIsEmptyController() {
			targetProperty = "ConfirmationMessageIsEmpty";
			PopupWindowShowAction popupWindowShowAction = new PopupWindowShowAction(this, "PopupWindowShowAction" + targetProperty, PredefinedCategory.Edit);
			popupWindowShowAction.CustomizePopupWindowParams += new CustomizePopupWindowParamsEventHandler(PopupWindowShowActionRootObject.popupWindowShowAction_CustomizePopupWindowParams);
			popupWindowShowAction.Execute += new PopupWindowShowActionExecuteEventHandler(PopupWindowShowActionRootObject.popupWindowShowAction_Execute);
			popupWindowShowAction.Caption = ActionsDemoStrings.ConfirmationMessageIsEmpty;
			popupWindowShowAction.ToolTip = ActionsDemoStrings.ConfirmationMessageIsEmptyTooltip;
		}
	}

	public class PopupWindowShowActionConfirmationMessageNotEmptyController : ActionBaseController {
		public PopupWindowShowActionConfirmationMessageNotEmptyController() {
			targetProperty = "ConfirmationMessageNotEmpty";
			PopupWindowShowAction popupWindowShowAction = new PopupWindowShowAction(this, "PopupWindowShowAction" + targetProperty, PredefinedCategory.Edit);
			popupWindowShowAction.CustomizePopupWindowParams += new CustomizePopupWindowParamsEventHandler(PopupWindowShowActionRootObject.popupWindowShowAction_CustomizePopupWindowParams);
			popupWindowShowAction.Execute += new PopupWindowShowActionExecuteEventHandler(PopupWindowShowActionRootObject.popupWindowShowAction_Execute);
			popupWindowShowAction.ConfirmationMessage = ActionsDemoStrings.ConfirmationMessage;
			popupWindowShowAction.Caption = ActionsDemoStrings.ConfirmationMessageNotEmpty;
			popupWindowShowAction.ToolTip = ActionsDemoStrings.ConfirmationMessageNotEmptyTooltip;
		}
	}
}
