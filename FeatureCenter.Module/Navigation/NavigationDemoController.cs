using System;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model.Core;
using DevExpress.ExpressApp.SystemModule;
using FeatureCenter.Module.Actions;

namespace FeatureCenter.Module.Navigation {
    public class DisableControllersForNavigationObject : DisableControllersByConditionViewController {
        protected override string DisableReason { get { return "NavigationObject"; } }
        protected override bool GetIsDisabled() {
            return true;
        }
        public DisableControllersForNavigationObject() {
            TargetObjectType = typeof(NavigationObject);
        }
    }
    public class DisableControllersForNavigationItemObject : DisableControllersByConditionViewController {
        protected override bool GetIsDisabled() {
            return true;
        }
        public DisableControllersForNavigationItemObject() {
            TargetObjectType = typeof(NavigationItem);
        }
    }
    public class NavigationDemoWindowController : WindowController {
        private static ModelApplicationCreator modelCreatorInstance;
        private ShowNavigationItemController showNavigationItemController;
        private void SubscribeToEvents() {
            showNavigationItemController.CustomShowNavigationItem += new EventHandler<CustomShowNavigationItemEventArgs>(showNavigationItemController_CustomShowNavigationItem);
        }
        private void UnsubscribeFromEvents() {
            showNavigationItemController.CustomShowNavigationItem -= new EventHandler<CustomShowNavigationItemEventArgs>(showNavigationItemController_CustomShowNavigationItem);
        }
        private void showNavigationItemController_CustomShowNavigationItem(object sender, CustomShowNavigationItemEventArgs e) {
            ViewShortcut viewShortcut = e.ActionArguments.SelectedChoiceActionItem.Data as ViewShortcut;
            string listViewId = Application.FindListViewId(typeof(NavigationObject));
            if(viewShortcut != null) {
                if(viewShortcut.ViewId == listViewId) {
                    IObjectSpace objectSpace = Application.CreateObjectSpace(typeof(NavigationObject));
                    DetailView detailView = Application.CreateDetailView(objectSpace, objectSpace.FindObject(typeof(NavigationObject), null));
                    detailView.ViewEditMode = DevExpress.ExpressApp.Editors.ViewEditMode.Edit;
                    e.ActionArguments.ShowViewParameters.CreatedView = detailView;
                    e.ActionArguments.ShowViewParameters.TargetWindow = TargetWindow.Current;
                    e.Handled = true;
                }
            }
        }
        protected override void OnFrameAssigned() {
            base.OnFrameAssigned();
            ModelCreatorInstance = ((ModelNode)Application.Model).CreatorInstance;
            showNavigationItemController = Frame.GetController<ShowNavigationItemController>();
            if(showNavigationItemController != null) {
                UnsubscribeFromEvents();
                SubscribeToEvents();
            }
        }
        protected override void Dispose(bool disposing) {
            if(showNavigationItemController != null) {
                UnsubscribeFromEvents();
                showNavigationItemController = null;
            }
            base.Dispose(disposing);
        }
        public NavigationDemoWindowController() {
            TargetWindowType = WindowType.Main;
        }
        internal static ModelApplicationCreator ModelCreatorInstance {
            get { return modelCreatorInstance; }
            set { modelCreatorInstance = value; }
        }
    }
    public class NavigationObjectDetailViewController : ViewController<DetailView> {
        private void ObjectSpace_ObjectChanged(object sender, ObjectChangedEventArgs e) {
            if(!string.IsNullOrEmpty(e.PropertyName) && e.PropertyName != "Log") {
                NavigationObject navigationObject = (NavigationObject)View.CurrentObject;
                navigationObject.BuildAction();
                RefreshNavigationActionContainer();
            }
        }
        private void RefreshNavigationActionContainer() {
            ViewItem actionViewItem = View.FindItem("Action");
            if(actionViewItem != null && actionViewItem.Control != null) {
                actionViewItem.Refresh();
            }
        }
        protected override void OnActivated() {
            base.OnActivated();
            View.ObjectSpace.ObjectChanged += new EventHandler<ObjectChangedEventArgs>(ObjectSpace_ObjectChanged);
        }
        protected override void OnDeactivated() {
            ObjectSpace.CommitChanges();
            View.ObjectSpace.ObjectChanged -= new EventHandler<ObjectChangedEventArgs>(ObjectSpace_ObjectChanged);
            base.OnDeactivated();
        }
        public NavigationObjectDetailViewController() {
            TargetObjectType = typeof(NavigationObject);
        }
    }
}
