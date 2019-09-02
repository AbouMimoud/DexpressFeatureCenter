using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System.ComponentModel;
using DevExpress.ExpressApp.Demos;

namespace FeatureCenter.Module.Audit {
    public class AssociatedAuditedObject : NamedBaseObject {
        private CollectionPropertiesAuditedObject owner;
        public AssociatedAuditedObject(Session session) : base(session) { }
        public AssociatedAuditedObject(Session session, string name)
            : base(session) {
            this.Name = name;
        }
        [Association("CollectionPropertiesAuditedObject-AssociatedAuditedObject"), Browsable(false)]
        public CollectionPropertiesAuditedObject Owner {
            get { return owner; }
            set { SetPropertyValue("Owner", ref owner, value); }
        }
    }
    public class AggregatedAuditedObject : NamedBaseObject {
        private CollectionPropertiesAuditedObject owner;
        public AggregatedAuditedObject(Session session) : base(session) { }
        public AggregatedAuditedObject(Session session, string name)
            : base(session) {
            this.Name = name;
        }
        [Association("CollectionPropertiesAuditedObject-AggregatedAuditedObject"), Browsable(false)]
        public CollectionPropertiesAuditedObject Owner {
            get { return owner; }
            set { SetPropertyValue("Owner", ref owner, value); }
        }
    }

    [NavigationItem(Captions.AuditGroup), System.ComponentModel.DisplayName(Captions.Audit_CollectionPropertiesAudit)]
    [Hint(Hints.AuditCollectionProperties)]
    [ImageName("Audit.Demo_Collection_Properties_Audit")]
    public class CollectionPropertiesAuditedObject : BaseAuditedObject {
        public CollectionPropertiesAuditedObject(Session session)
            : base(session) {
        }
        [Association("CollectionPropertiesAuditedObject-AssociatedAuditedObject")]
        public XPCollection<AssociatedAuditedObject> NonAggregatedCollection {
            get { return GetCollection<AssociatedAuditedObject>("NonAggregatedCollection"); }
        }
        [Association("CollectionPropertiesAuditedObject-AggregatedAuditedObject"), Aggregated]
        public XPCollection<AggregatedAuditedObject> AggregatedCollection {
            get { return GetCollection<AggregatedAuditedObject>("AggregatedCollection"); }
        }
    }
}
