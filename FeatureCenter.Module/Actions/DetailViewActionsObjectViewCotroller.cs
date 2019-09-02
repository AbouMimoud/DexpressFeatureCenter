using System;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using FeatureCenter.Module.PropertyEditors;

namespace FeatureCenter.Module.Actions {
    public class DetailViewActionsObjectViewCotroller : ViewController {
        private DetailViewActionsObject currentObject;
        protected override void OnViewControlsCreated() {
            base.OnViewControlsCreated();
            currentObject = (DetailViewActionsObject)View.CurrentObject;
        }
        public DetailViewActionsObjectViewCotroller() {
            TargetViewType = ViewType.DetailView;
            TargetObjectType = typeof(DetailViewActionsObject);

            SimpleAction simpleAction = new SimpleAction(this, "SimpleAction", "DetailViewActions");
            simpleAction.ImageName = ActionsDemoStrings.SimpleActionImageName;
            simpleAction.SelectionDependencyType = SelectionDependencyType.RequireSingleObject;
            simpleAction.Execute += new SimpleActionExecuteEventHandler(simpleAction_Execute);
            SingleChoiceAction singleChoiceAction = new SingleChoiceAction(this, "SingleChoiceAction", "DetailViewActions");
            singleChoiceAction.ImageName = ActionsDemoStrings.SingleChoiceActionImageName;
            singleChoiceAction.SelectionDependencyType = SelectionDependencyType.RequireSingleObject;
            singleChoiceAction.Execute += new SingleChoiceActionExecuteEventHandler(singleChoiceAction_Execute);
			singleChoiceAction.ItemType = SingleChoiceActionItemType.ItemIsOperation;
            ChoiceActionItem item1 = new ChoiceActionItem("Item1", null);
            ChoiceActionItem item2 = new ChoiceActionItem("Item2", null);
            ChoiceActionItem item21 = new ChoiceActionItem("Item2.1", null);
            item2.Items.Add(item21);
            singleChoiceAction.Items.Add(item1);
            singleChoiceAction.Items.Add(item2);
            ParametrizedAction parametrizedAction = new ParametrizedAction(this, "ParametrizedAction", "DetailViewActions", typeof(int));
            parametrizedAction.ShortCaption = "GO";
            parametrizedAction.ImageName = ActionsDemoStrings.ParametrizedActionImageName;
            parametrizedAction.SelectionDependencyType = SelectionDependencyType.RequireSingleObject;
            parametrizedAction.Execute += new ParametrizedActionExecuteEventHandler(parametrizedAction_Execute);
            PopupWindowShowAction popupWindowShowAction = new PopupWindowShowAction(this, "PopupWindowShowAction", "DetailViewActions");
            popupWindowShowAction.ImageName = ActionsDemoStrings.PopupWindowShowActionImageName;
            popupWindowShowAction.SelectionDependencyType = SelectionDependencyType.RequireSingleObject;
            popupWindowShowAction.CustomizePopupWindowParams += new CustomizePopupWindowParamsEventHandler(popupWindowShowAction_CustomizePopupWindowParams);
            popupWindowShowAction.Execute += new PopupWindowShowActionExecuteEventHandler(popupWindowShowAction_Execute);
        }
        private void LogTrace(string message) {   
            currentObject.Log = message + "\r\n" + currentObject.Log;
        }
        void singleChoiceAction_Execute(object sender, SingleChoiceActionExecuteEventArgs e) {
            LogTrace(string.Format("The 'SingleChoiceAction' is executed with parameter '{0}' for the '{1}' object.", e.SelectedChoiceActionItem.Caption, currentObject.Name));
        }
        void popupWindowShowAction_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e) {
			IObjectSpace objectSpace = Application.CreateObjectSpace(typeof(BooleanProperties));
            e.View = Application.CreateListView(objectSpace, typeof(BooleanProperties), true);
        }
        void popupWindowShowAction_Execute(object sender, PopupWindowShowActionExecuteEventArgs e) {
            string parameters = "";
            foreach(BooleanProperties obj in e.PopupWindow.View.SelectedObjects) {
                parameters += obj.Name + " ; ";
            }
            parameters = parameters.Trim().TrimEnd(';');
            LogTrace(string.Format("The 'PopupWindowShowAction' is executed with {0} parameter(s) for the '{1}' object. {2}", e.PopupWindow.View.SelectedObjects.Count, currentObject.Name, string.IsNullOrEmpty(parameters) ? "" : "\r\n\t\t" + parameters));
        }
        private void simpleAction_Execute(object sender, SimpleActionExecuteEventArgs e) {
            LogTrace(string.Format("The 'SimpleAction' is executed for the '{0}' object.", currentObject.Name));
        }
        private void parametrizedAction_Execute(object sender, ParametrizedActionExecuteEventArgs e) {
            LogTrace(string.Format("The 'ParametrizedAction' is executed with parameter '{0}' for the '{1}' object.", e.ParameterCurrentValue == null ? "Null" : e.ParameterCurrentValue.ToString(), currentObject.Name));
        }
    }
}
