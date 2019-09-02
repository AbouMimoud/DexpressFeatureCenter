using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.Xpo;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.AuditTrail;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Demos;

namespace FeatureCenter.Module.Audit {
    [NavigationItem(Captions.AuditGroup), System.ComponentModel.DisplayName(Captions.Audit_Settings)]
    [Hint(Hints.AuditSettings)]
    [ImageName("Audit.Demo_Audit_Settings")]
    public class AuditSettingsObject : BaseAuditedObject {
        private string auditedProperty;
        private string nonAuditedProperty;
        public AuditSettingsObject(Session session)
            : base(session) {
        }
        public string AuditedProperty {
            get { return auditedProperty; }
            set { SetPropertyValue("AuditedProperty", ref auditedProperty, value); }
        }
        public string NonAuditedProperty {
            get { return nonAuditedProperty; }
            set { SetPropertyValue("NonAuditedProperty", ref nonAuditedProperty, value); }
        }
    }
}
