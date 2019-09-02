using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.Xpo;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp;
using DevExpress.Persistent.Validation;
using DevExpress.ExpressApp.Demos;

namespace FeatureCenter.Module.Validation {
	[NavigationItem(Captions.ValidationGroup), System.ComponentModel.DisplayName(Captions.Validation_SimpleValidationSettings)]
	[Hint(Hints.SimpleValidationSettingsHint)]
	[ImageName("Validation.Demo_Simple_Validation_Settings")]
    public class SimpleValidationSettingsObject : ValidationDemoBaseObject {
		private int notFromZeroToTen;
		private string doesNotContainABC;
		private string requiredField;

		public SimpleValidationSettingsObject(Session session) : base(session) { }

		[RuleRange("SimpleValidationSettingsObject.NotFromZeroToTen_RuleRange", "Save", 0, 10, @"The ""{TargetPropertyName}"" property must be set to a value out of the ""(0,10)"" range.", InvertResult = true)]
		public int NotFromZeroToTen {
			get { return notFromZeroToTen; }
			set { SetPropertyValue("NotFromZeroToTen", ref notFromZeroToTen, value); }
		}
		[RuleStringComparison("SimpleValidationSettingsObject.DoesNotContainABC_RuleStringComparison", "Save", StringComparisonType.Contains, "ABC", @"The ""{TargetPropertyName}"" property must not contain the ""{OperandValue}"" value. However, it can be empty.", IgnoreCase = true, SkipNullOrEmptyValues = true, InvertResult = true)]
		public string DoesNotContainABC {
			get { return doesNotContainABC; }
			set { SetPropertyValue("DoesNotContainsABC", ref doesNotContainABC, value); }
		}
        [RuleRequiredField("SimpleValidationSettingsObject.SimpleValidationSettingsObject_RuleRequiredField", "Save", @"This field is required if only the ""Does Not Contain ABC"" property value contains ""XYZ"" and the ""Not From Zero To Ten"" property value is greater than ""5"".", TargetCriteria = "Contains(DoesNotContainABC, 'XYZ') AND NotFromZeroToTen > 5")]
		public string RequiredField {
			get { return requiredField; }
			set { SetPropertyValue("RequiredField", ref requiredField, value); }
		}
	}
}
