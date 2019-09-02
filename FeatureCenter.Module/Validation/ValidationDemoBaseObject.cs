using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;

namespace FeatureCenter.Module.Validation {
    public abstract class ValidationDemoBaseObject : BaseObject {
        private string name;
        public ValidationDemoBaseObject(Session session) : base(session) { }
        public string Name {
            get {
                if(string.IsNullOrEmpty(name)) {
                    name = GetType().Name;
                }
                return name;
            }
            set { SetPropertyValue("Name", ref name, value); }
        }
    }
}
