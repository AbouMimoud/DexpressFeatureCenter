using System;
using System.Collections.Generic;
using System.Web.UI;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Web.Templates;
using DevExpress.ExpressApp.Web.Templates.ActionContainers;
using DevExpress.ExpressApp.Web.TestScripts;
using FeatureCenter.Module.Navigation;
using FeatureCenter.Module.PropertyEditors;

namespace FeatureCenter.Module.Web.Navigation {
    [PropertyEditor(typeof(SingleChoiceAction), FeatureCenterEditorAliases.NavigationContainerEditor)]
    public class NavigationActionContainerPropertyEditor : PropertyEditor, ITestableEx, ISupportAdditionalParametersTestControl {
        private NavigationActionContainer NavigationActionContainer {
            get { return (NavigationActionContainer)Control; }
        }
        private NavigationObject NavigationObject {
            get { return (NavigationObject)CurrentObject; }
        }
        private void NavigationActionContainer_Init(object sender, EventArgs e) {
            NavigationActionContainer navigationActionContainer = (NavigationActionContainer)sender;
            navigationActionContainer.Init -= new EventHandler(NavigationActionContainer_Init);
            ReadValue();
        }
        private void NavigationActionContainer_Load(object sender, EventArgs e) {
            NavigationActionContainer navigationActionContainer = (NavigationActionContainer)sender;
            navigationActionContainer.Load -= new EventHandler(NavigationActionContainer_Load);
            ICallbackManagerHolder holder = navigationActionContainer.Page as ICallbackManagerHolder;
            if(holder != null) {
                holder.CallbackManager.RegisterHandler(NavigationActionContainer.XafNavigationHandlerId, navigationActionContainer);
            }
        }
        private void NavigationActionContainer_Unload(object sender, EventArgs e) {
            NavigationActionContainer navigationActionContainer = (NavigationActionContainer)sender;
            navigationActionContainer.Unload -= new EventHandler(NavigationActionContainer_Unload);
            OnControlInitialized(navigationActionContainer);
        }
        protected override object CreateControlCore() {
            NavigationActionContainer navigationActionContainer = new NavigationActionContainer();
            navigationActionContainer.DisableDelayedCreation();
            navigationActionContainer.RecoverViewStateOnNavigationCallback = true;
            navigationActionContainer.ContainerId = "TestNavigation";
            navigationActionContainer.Init += new EventHandler(NavigationActionContainer_Init);
            navigationActionContainer.Load += new EventHandler(NavigationActionContainer_Load);
            navigationActionContainer.Unload += new EventHandler(NavigationActionContainer_Unload);
            return navigationActionContainer;
        }
        protected override void ReadValueCore() {
            NavigationActionContainer.Register((SingleChoiceAction)PropertyValue, NavigationObject.NavigationStyle);
        }
        protected override object GetControlValueCore() {
            return null;
        }
        public NavigationActionContainerPropertyEditor(Type objectType, IModelMemberViewItem info) : base(objectType, info) { }

        #region ITestable Members
        protected void OnControlInitialized(Control control) {
            if(ControlInitialized != null) {
                ControlInitialized(this, new ControlInitializedEventArgs(control));
            }
        }
        string ITestable.ClientId { get { return ((ITestable)NavigationActionContainer).ClientId; } }
        string ITestable.TestCaption { get { return this.Caption; } }
        IJScriptTestControl ITestable.TestControl { get { return ((ITestable)NavigationActionContainer).TestControl; } }
        public event EventHandler<ControlInitializedEventArgs> ControlInitialized;
        TestControlType ITestable.TestControlType { get { return TestControlType.Field; } }
        #endregion
        #region ITestableEx Members
        public Type RegisterControlType {
            get { return NavigationActionContainer.GetType(); }
        }
        #endregion
        #region ISupportAdditionalParametersTestControl Members
        public ICollection<string> GetAdditionalParameters(object control) {
            ISupportAdditionalParametersTestControl testControl = this.NavigationActionContainer as ISupportAdditionalParametersTestControl;
            if(testControl != null) {
                return testControl.GetAdditionalParameters(testControl);
            }
            return new string[0];
        }
        #endregion
    }
}
