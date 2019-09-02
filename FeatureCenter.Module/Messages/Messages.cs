using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Demos;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using FeatureCenter.Module.Actions;
using FeatureCenter.Module.PropertyEditors;

namespace FeatureCenter.Module.Messages {
    [AutoCreatableObject]
    [NonPersistent]
    [ImageName("Action_Translate")]
    [NavigationItem(ActionsDemoStrings.NavBarGroupName)]
    [System.ComponentModel.DisplayName(ActionsDemoStrings.Messages)]
    [Hint(Hints.MessagesHint, ViewType.DetailView)]
    public class Messages : MessageOptions {
        [Size(-1), EditorAlias(FeatureCenterEditorAliases.CSCodePropertyEditor)]
        public string HowToDoIt { get; private set; }
        public Messages() {
            Message = "Click this message to execute some custom logic";
            Type = InformationType.Success;
            Web.Position = InformationPosition.Bottom;
            Duration = 2000;
            Win.Caption = "Message Caption";
            HowToDoIt = @"using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.SystemModule;

namespace FeatureCenter.Module.Messages {
    public class ShowMessagesController : ObjectViewController<DetailView, Messages>{
        public ShowMessagesController() {
            SimpleAction action = new SimpleAction(this, ""ShowMessage"", ""ShowMessageCategory"");
            action.Execute += action_Execute;
        }
        void action_Execute(object sender, SimpleActionExecuteEventArgs e) {
            MessageOptions options = new MessageOptions();
            options.Duration = 2000;
            options.Message = ""Message"";
            options.Web.Position = InformationPosition.Bottom;
            options.Type = InformationType.Success;
            options.Win.Caption = ""Caption"";
            options.CancelDelegate = CancelDelegate;
            options.OkDelegate = OkDelegate;            
            
            Application.ShowViewStrategy.ShowMessage(options);
        }
        private void OkDelegate() {
        }
        private void CancelDelegate() {
        }
    }
}
";
        }
    }
}
