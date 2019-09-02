using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.Xpo;
using DevExpress.Persistent.Base;
using System.Drawing;
using DevExpress.Xpo.Metadata;
using FeatureCenter.Module.Audit;
using DevExpress.ExpressApp.Demos;

namespace FeatureCenter.Module.Win.Audit {
    public abstract class AuditPerformanceObject : BaseAuditedObject, IObjectPropertiesInitializer {
        private static Random randomGenerator = new Random();
        private int index;
        private int integerProperty;
        private decimal decimalProperty;
        private double doubleProperty;
        private bool booleanProperty;
        private string stringProperty;
        private DateTime dateTimeProperty;
        private SampleEnum enumProperty;
        private ReferencedAuditedObject objectProperty;

        public AuditPerformanceObject(Session session) : base(session) { }
        public void InitializeObject(int index) {
            this.Index = index;
            this.IntegerProperty = randomGenerator.Next();
            this.Name = "AuditPerformanceObject" + index;
            if(this.ObjectProperty == null) {
                ReferencedAuditedObject referencedAuditedObject = new ReferencedAuditedObject(this.Session, string.Format("Referenced Audited Object referenced by {0}", this.Name));
                referencedAuditedObject.Name = "ReferencedAuditedObject " + index;
                this.ObjectProperty = referencedAuditedObject;
            }
            this.StringProperty = "Some string: " + randomGenerator.Next();
            this.BooleanProperty = (index % 2 == 0);
            this.DateTimeProperty = DateTime.Now.AddDays(index);
            this.DecimalProperty = (decimal)(index * 1.5);
            this.DoubleProperty = index * 3.14;
            this.EnumProperty = this.BooleanProperty ? SampleEnum.First : ((index % 3 == 0) ? SampleEnum.Second : SampleEnum.Third);
            this.Save();
        }
        public int Index {
            get { return index; }
            set { SetPropertyValue("Index", ref index, value); }
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

	[NavigationItem(Captions.AuditGroup), System.ComponentModel.DisplayName(Captions.Audit_PartiallyAuditedBatchCreation)]
    [Hint(Hints.AuditPartiallyDisabled)]
    [ImageName("Audit.Demo_Import_Data_With_Partial_Audit")]
    [BatchCreationOptions(2000, 100)]
    public class PartiallyAuditedBatchCreationObject : AuditPerformanceObject {
        public PartiallyAuditedBatchCreationObject(Session session) : base(session) { }
    }

	[NavigationItem(Captions.AuditGroup), System.ComponentModel.DisplayName(Captions.Audit_FullyAuditedBatchCreation)]
    [Hint(Hints.AuditFullyEnabled)]
    [ImageName("Audit.Demo_Audit_Performance")]
    [BatchCreationOptions(500, 50)]
    public class FullyAuditedBatchCreationObject : AuditPerformanceObject {
        public FullyAuditedBatchCreationObject(Session session) : base(session) { }
    }
}
