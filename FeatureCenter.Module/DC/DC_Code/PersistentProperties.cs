using System;
using System.Collections.Generic;
using DevExpress.ExpressApp.DC;
using DevExpress.Xpo;

namespace FeatureCenter.Module.DC {
    [DomainComponent]
    public interface IContact {
        // value type properties
        string Name { get; set; }
        DateTime Birthday { get; set; }
        // reference to a persistent object
        Organization Organization { get; set; }
        // reference to an entity instance
        IContact Spouse { get; set; }
        // collection property
        IList<IPhone> Phones { get; }
    }

    [DomainComponent]
    public interface IPhone {
        string Number { get; set; }
    }

    public class Organization : XPObject {
        private string name;
        public Organization(Session session) : base(session) { }
        public string Name {
            get { return name; }
            set { SetPropertyValue<string>("Name", ref name, value); }
        }
    }
}
