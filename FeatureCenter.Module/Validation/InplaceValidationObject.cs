using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;

namespace FeatureCenter.Module.Validation {
    [NavigationItem(Captions.ValidationGroup), System.ComponentModel.DisplayName(Captions.Validation_InplaceValidation)]
    [ImageName("Validation.Demo_Client_Side_Validation")]
    public class InplaceValidationObject : ValidationDemoBaseObject {
        public InplaceValidationObject(Session session) : base(session) { }
        private string requiredStringProperty;
        private int greaterThanZero;
        private string startsWithAbc;
        private string email;
        private DateTime during2008;
        private InplaceValidationObject requiredReferencedProperty;

        [RuleRequiredField("ClientSide.RuleRequiredFieldObject.RequiredStringProperty_RuleRequiredField", "Save")]
        public string RequiredStringProperty {
            get { return requiredStringProperty; }
            set { SetPropertyValue("RequiredStringProperty", ref requiredStringProperty, value); }
        }
        [RuleValueComparison("ClientSide.RuleValueComparisonObject.GreaterThanZero_RuleValueComparisonObject", DefaultContexts.Save, ValueComparisonType.GreaterThan, 0)]
        public int GreaterThanZero {
            get { return greaterThanZero; }
            set { SetPropertyValue<int>("GreaterThanZero", ref greaterThanZero, value); }
        }
        [RuleStringComparison("ClientSide.RuleStringComparisonObject.EndsWithXyz_RuleStringComparisonObject", "Save", StringComparisonType.StartsWith, "Abc", IgnoreCase = false, SkipNullOrEmptyValues = false)]
        public string StartsWithAbc {
            get { return startsWithAbc; }
            set { SetPropertyValue("StartsWithAbc", ref startsWithAbc, value); }
        }
        [RuleRegularExpression("ClientSide.RuleRegularExpressionObject.Email_RuleRegularExpression", DefaultContexts.Save, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")]
        public string Email {
            get { return email; }
            set { SetPropertyValue<string>("Email", ref email, value); }
        }
        [RuleRange("ClientSide.RuleRangeObject.During2008_RuleRange", "Save", "1 Jan 2008", "31 Dec 2008")]
        public DateTime During2008 {
            get { return during2008; }
            set { SetPropertyValue<DateTime>("During2008", ref during2008, value); }
        }
        [RuleRequiredField]
        public InplaceValidationObject RequiredReferencedProperty {
            get { return requiredReferencedProperty; }
            set { SetPropertyValue<InplaceValidationObject>("RequiredReferencedProperty", ref requiredReferencedProperty, value); }
        }
    }
}
