
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.SystemModule;

namespace FeatureCenter.Module.Messages {
    public class ShowMessagesController : ObjectViewController<DetailView, Messages>{
        public ShowMessagesController() {
            SimpleAction action = new SimpleAction(this, "ShowMessage", "ShowMessageCategory");
            action.Execute += action_Execute;
        }
        protected override void OnActivated() {
            base.OnActivated();
            ModificationsController modificationsController = Frame.GetController<ModificationsController>();
            if(modificationsController != null) {
                modificationsController.Active[GetType().Name] = false;
            }
            RecordsNavigationController recordsNavigationController = Frame.GetController<RecordsNavigationController>();
            if(recordsNavigationController != null) {
                recordsNavigationController.Active[GetType().Name] = false;
            }
        }
        protected override void OnDeactivated() {
            ModificationsController modificationsController = Frame.GetController<ModificationsController>();
            if(modificationsController != null) {
                modificationsController.Active[GetType().Name] = true;
            }
            RecordsNavigationController recordsNavigationController = Frame.GetController<RecordsNavigationController>();
            if(recordsNavigationController != null) {
                recordsNavigationController.Active[GetType().Name] = true;
            }
            base.OnDeactivated();
        }
        void action_Execute(object sender, SimpleActionExecuteEventArgs e) {
            MessageOptions options = GetMessageOptions();
            options.OkDelegate = OkDelegate;
            Application.ShowViewStrategy.ShowMessage(options);
        }
        private void OkDelegate() {
            Application.ShowViewStrategy.ShowMessage(new MessageOptions() { Type = InformationType.Info, Message = "You have clicked the notification message!", Duration = 2000 });
        }
        private MessageOptions GetMessageOptions() {
            return ViewCurrentObject;
        }

    }
}
