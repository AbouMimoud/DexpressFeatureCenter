using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.Xpo;
using DevExpress.Persistent.BaseImpl;

namespace FeatureCenter.Module.Audit {
    [NonPersistent]
    public abstract class BaseAuditedObject : NamedBaseObject {
        private XPCollection<AuditDataItemPersistent> auditTrail;

        public BaseAuditedObject(Session session)
            : base(session) {
        }
        public XPCollection<AuditDataItemPersistent> AuditTrail {
            get {
                if(auditTrail == null) {
                    auditTrail = AuditedObjectWeakReference.GetAuditTrail(Session, this);
                }
                return auditTrail;
            }
        }
    }
}
