using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Demos;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;

namespace FeatureCenter.Module.Actions {

	public class Message : Note {
		public Message(Session session) : base(session) { }
	}

	[NonPersistent]
	[ImageName(ActionsDemoStrings.PopupWindowShowActionImageName)]
	[NavigationItem(ActionsDemoStrings.NavBarGroupName)]
	[System.ComponentModel.DisplayName(ActionsDemoStrings.PopupWindowShowAction)]
	[Hint(Hints.PopupWindowShowActionHint, ViewType.DetailView)]
	public class PopupWindowShowActionRootObject : ActionBaseRootObject {
		private PopupWindowShowAction properties = new PopupWindowShowAction();
		public static void popupWindowShowAction_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e) {
			PopupWindowShowAction action = (PopupWindowShowAction)sender;
			IObjectSpace objectSpace = action.Application.CreateObjectSpace(typeof(Message));
			string detailViewId = action.Application.FindDetailViewId(typeof(Message));
			Message message = objectSpace.FindObject<Message>(null);
			if(message == null) {
				message = objectSpace.CreateObject<Message>();
				message.Text = ActionsDemoStrings.PopupWindowShowActionMessageText;
				//message.Text = ActionsDemoStrings.LogTraceHeader + e.Action.Caption + ActionsDemoStrings.LogTraceTail;
			}
			e.View = action.Application.CreateDetailView(objectSpace, message);
		}
		public static void popupWindowShowAction_Execute(object sender, PopupWindowShowActionExecuteEventArgs e) {
			if(((ActionBase)sender).Controller is ActionBaseController) {
				((ActionBaseController)((ActionBase)sender).Controller).LogTrace(e.Action);
			}
		}
        [ModelDefault("VisibleProperties", "Caption, ToolTip, ImageName, AcceptButtonCaption, CancelButtonCaption, IsSizeable")]
		public PopupWindowShowAction PopupWindowShowAction {
			get { return properties; }
		}
	}

}
