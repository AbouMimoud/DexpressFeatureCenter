using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using DevExpress.Persistent.Base;

namespace FeatureCenter.Module.StateMachine {
    [NavigationItem]
    [ImageName("BO_Person")]
    public class Employee : BaseObject {
        public Employee(DevExpress.Xpo.Session session)
            : base(session) { }

        public string FullName {
            get { return FirstName + " " + LastName; }
        }
        public string FirstName {
            get { return GetPropertyValue<string>("FirstName"); }
            set { SetPropertyValue<string>("FirstName", value); }
        }
        public string LastName {
            get { return GetPropertyValue<string>("LastName"); }
            set { SetPropertyValue<string>("LastName", value); }
        }
    }
}
