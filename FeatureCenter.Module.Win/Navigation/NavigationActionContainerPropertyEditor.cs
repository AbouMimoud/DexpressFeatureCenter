using System;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Win.Templates.ActionContainers;
using FeatureCenter.Module.Navigation;
using FeatureCenter.Module.PropertyEditors;

namespace FeatureCenter.Module.Win.Navigation {
    [PropertyEditor(typeof(SingleChoiceAction), FeatureCenterEditorAliases.NavigationContainerEditor)]
    public class NavigationActionContainerPropertyEditor : PropertyEditor {
        private NavigationActionContainer NavigationActionContainer {
            get { return (NavigationActionContainer)Control; }
        }
        private NavigationObject NavigationObject {
            get { return (NavigationObject)CurrentObject; }
        }
        private void Control_ParentChanged(object sender, EventArgs e) {
            ReadValue();
        }
        protected override object CreateControlCore() {
            return new NavigationActionContainer();
        }
        protected override void OnControlCreated() {
            NavigationActionContainer.ParentChanged += new EventHandler(Control_ParentChanged);
            base.OnControlCreated();
        }
        protected override void ReadValueCore() {
            NavigationActionContainer.Register((SingleChoiceAction)PropertyValue, NavigationObject.NavigationStyle);
        }
        protected override object GetControlValueCore() {
            return null;
        }
        public NavigationActionContainerPropertyEditor(Type objectType, IModelMemberViewItem info) : base(objectType, info) { }
        public override void BreakLinksToControl(bool unwireEventsOnly) {
            if(NavigationActionContainer != null) {
                NavigationActionContainer.ParentChanged -= new EventHandler(Control_ParentChanged);
            }
            base.BreakLinksToControl(unwireEventsOnly);
        }
    }
}
