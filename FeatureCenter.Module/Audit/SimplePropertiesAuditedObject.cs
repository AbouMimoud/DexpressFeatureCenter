using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System.Drawing;
using DevExpress.Xpo.Metadata;
using FeatureCenter.Module.PropertyEditors;
using DevExpress.ExpressApp.Demos;

namespace FeatureCenter.Module.Audit {
    public class ReferencedAuditedObject : NamedBaseObject {
        public ReferencedAuditedObject(Session session) : base(session) {
        }
        public ReferencedAuditedObject(Session session, string name) : base(session) {
            this.Name = name;
        }
    }

	[NavigationItem(Captions.AuditGroup), System.ComponentModel.DisplayName(Captions.Audit_SimplePropertiesAudit)]
    [Hint(Hints.AuditSimpleProperties)]
    [ImageName("Audit.Demo_Simple_Properties_Audit")]
    public class SimplePropertiesAuditedObject : BaseAuditedObject {
        private int integerProperty;
        private decimal decimalProperty;
        private double doubleProperty;
        private bool booleanProperty;
        private string stringProperty;
        private DateTime dateTimeProperty;
        private SampleEnum enumProperty;
        private ReferencedAuditedObject objectProperty;
        public SimplePropertiesAuditedObject(Session session)
            : base(session) {
        }
        public int IntegerProperty {
            get { return integerProperty; }
            set { SetPropertyValue("IntegerProperty", ref integerProperty, value); }
        }
        public double DoubleProperty {
            get { return doubleProperty; }
            set { SetPropertyValue("DoubleProperty", ref doubleProperty, value); }
        }
        public decimal DecimalProperty {
            get { return decimalProperty; }
            set { SetPropertyValue("DecimalProperty", ref decimalProperty, value); }
        }
        public bool BooleanProperty {
            get { return booleanProperty; }
            set { SetPropertyValue("BooleanProperty", ref booleanProperty, value); }
        }
        public string StringProperty {
            get { return stringProperty; }
            set { SetPropertyValue("StringProperty", ref stringProperty, value); }
        }
        public DateTime DateTimeProperty {
            get { return dateTimeProperty; }
            set { SetPropertyValue("DateTimeProperty", ref dateTimeProperty, value); }
        }
        public SampleEnum EnumProperty {
            get { return enumProperty; }
            set { SetPropertyValue("EnumProperty", ref enumProperty, value); }
        }
        [DevExpress.Xpo.Size(SizeAttribute.Unlimited), ValueConverter(typeof(ImageValueConverter))]
        [VisibleInListViewAttribute(true)]
        public Image ImageProperty {
            get { return GetPropertyValue<Image>("ImageProperty"); }
            set { SetPropertyValue<Image>("ImageProperty", value); }
        }
        public ReferencedAuditedObject ObjectProperty {
            get { return objectProperty; }
            set { SetPropertyValue("ObjectProperty", ref objectProperty, value); }
        }
    }
}
