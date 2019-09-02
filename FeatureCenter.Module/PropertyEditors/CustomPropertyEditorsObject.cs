using System;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Demos;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace FeatureCenter.Module.PropertyEditors {
    [NavigationItem(Captions.PropertyEditorsGroup), DefaultListViewOptions(true, NewItemRowPosition.Top), System.ComponentModel.DisplayName(Captions.PropertyEditors_CustomPropertyEditors)]
    [Hint(Hints.CustomPropertyEditorsHint)]
    [ImageName("PropertyEditors.Demo_Custom_Property_Editors")]
    public class CustomPropertyEditorsObject : NamedBaseObject {
        public CustomPropertyEditorsObject(Session session) : base(session) { }

        [ModelDefault("DisplayFormat", "{0:MM.dd.yyyy hh:mm:ss}")]
        [ModelDefault("EditMask", "MM.dd.yyyy hh:mm:ss")]
        [EditorAlias(FeatureCenterEditorAliases.CustomDateTimeEditor)]
        public DateTime DateTimeProperty {
            get { return GetPropertyValue<DateTime>("DateTimeProperty"); }
            set { SetPropertyValue("DateTimeProperty", value); }
        }
        [EditorAlias(FeatureCenterEditorAliases.CustomIntegerEditor)]
        public int IntegerProperty {
            get { return GetPropertyValue<int>("IntegerProperty"); }
            set { SetPropertyValue("IntegerProperty", value); }
        }
        [EditorAlias(FeatureCenterEditorAliases.CustomStringEditor)]
        public string StringProperty {
            get { return GetPropertyValue<string>("StringProperty"); }
            set { SetPropertyValue("StringProperty", value); }
        }
    }
}
