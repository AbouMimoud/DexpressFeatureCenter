using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.Demos;
using DevExpress.Xpo;
using System.ComponentModel;
using DevExpress.ExpressApp.Actions;

namespace FeatureCenter.Module.CustomFields {
    [NavigationItem(Captions.CustomFields), DefaultListViewOptions(true, NewItemRowPosition.Top), XafDisplayName(Captions.CustomFields)]
    [Hint(Hints.CustomFieldsDescription)]
    [ImageName("CustomFields.Demo_CustomFields")]
    public class CustomFieldsObject : NamedBaseObject {
        public CustomFieldsObject(Session session) : base(session) { }
        [Association, Browsable(false)]
        public CustomFieldsObject Master {
            get { return GetPropertyValue<CustomFieldsObject>("Master"); }
            set { SetPropertyValue("Master", value); }
        }
        [Association, DevExpress.Xpo.Aggregated]
        public XPCollection<CustomFieldsObject> RelatedDetails {
            get { return GetCollection<CustomFieldsObject>("RelatedDetails"); }
        }
    }

    public class CustomFieldsObjectController : ViewController {
        private SimpleAction incrementAction;
        private void IncrementAction_Execute(object sender, SimpleActionExecuteEventArgs e) {
            int currentValue = Convert.ToInt32(((XPBaseObject)View.CurrentObject).GetMemberValue("SimpleCustomField"));
            ((XPBaseObject)View.CurrentObject).SetMemberValue("SimpleCustomField", currentValue + 1);
        }
        public CustomFieldsObjectController() {
            TargetObjectType = typeof(CustomFieldsObject);
            incrementAction = new SimpleAction(this, "Increment", PredefinedCategory.Edit);
            incrementAction.SelectionDependencyType = SelectionDependencyType.RequireSingleObject;
            incrementAction.ToolTip = "Increments the SimpleCustomField editor value and thus causes a dependent SimpleCalculatedField to be updated.";
            incrementAction.Execute += IncrementAction_Execute;
        }
    }
}
