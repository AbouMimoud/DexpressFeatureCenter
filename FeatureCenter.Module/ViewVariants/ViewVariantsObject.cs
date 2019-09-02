using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.Persistent.BaseImpl;
using DevExpress.ExpressApp.Demos;
using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using FeatureCenter.Module.Navigation;
using DevExpress.Xpo;

namespace FeatureCenter.Module.ViewVariants {
    [NavigationItem(Captions.ViewVariantsGroup)]
    [ImageName("Navigation_Item_View")]
    [Hint(Hints.ViewVariantsObjectHint, ViewType.Any)]
    public class ViewVariantsObject : NamedBaseObject {
        private DateTime property1;
        private string property2;
        private float property3;
        public ViewVariantsObject(Session session) : base(session) { }
        public DateTime Property1 {
            get {
                return property1;
            }
            set {
                SetPropertyValue("Property1", ref property1, value);
            }
        }
        public string Property2 {
            get {
                return property2;
            }
            set {
                SetPropertyValue("Property2", ref property2, value);
            }
        }
        public float Property3 {
            get {
                return property3;
            }
            set {
                SetPropertyValue("Property3", ref property3, value);
            }
        }
    }
}
