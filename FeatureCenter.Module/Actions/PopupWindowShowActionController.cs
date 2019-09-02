using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.Actions;
using DevExpress.Xpo;

namespace FeatureCenter.Module.Actions {
	public class PopupWindowShowActionController : ActionBaseController {
		public PopupWindowShowActionController() {
			PopupWindowShowAction popupWindowShowAction = new PopupWindowShowAction(this, "PopupWindowShowDemoAction", PredefinedCategory.Edit);
			popupWindowShowAction.CustomizePopupWindowParams += new CustomizePopupWindowParamsEventHandler(PopupWindowShowActionRootObject.popupWindowShowAction_CustomizePopupWindowParams);
			popupWindowShowAction.Execute += new PopupWindowShowActionExecuteEventHandler(PopupWindowShowActionRootObject.popupWindowShowAction_Execute);
			popupWindowShowAction.ImageName = ActionsDemoStrings.PopupWindowShowActionImageName;
			popupWindowShowAction.ToolTip = ActionsDemoStrings.PopupWindowShowActionTooltip;
		}
	}
}
