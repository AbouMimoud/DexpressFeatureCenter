using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using DevExpress.Persistent.Validation;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Demos;

namespace FeatureCenter.Module.Validation {
	[NavigationItem(Captions.ValidationGroup), System.ComponentModel.DisplayName(Captions.Validation_RuleStringComparison)]
	[Hint(Hints.RuleStringComparisonHint)]
    [ImageName("Validation.Demo_Rule_String_Comparison")]
    public class RuleStringComparisonObject : ValidationDemoBaseObject {
		private string startsWithAbc;
		private string endsWithXyz;
		private string containsXXX;
		private string equalsValid;
		private string doesNotEqualInvalid;

		public RuleStringComparisonObject(Session session) : base(session) { }

		[RuleStringComparison("RuleStringComparisonObject.StartsWithAbc_RuleStringComparisonObject", "Save", StringComparisonType.StartsWith, "Abc", IgnoreCase = false)]
		public string StartsWithAbc {
			get { return startsWithAbc; }
			set { SetPropertyValue("StartsWithAbc", ref startsWithAbc, value); }
		}
		[RuleStringComparison("RuleStringComparisonObject.EndsWithXyz_RuleStringComparisonObject", "Save", StringComparisonType.EndsWith, "Xyz", IgnoreCase = false)]
		public string EndsWithXyz {
			get { return endsWithXyz; }
			set { SetPropertyValue("EndsWithXyz", ref endsWithXyz, value); }
		}
		[RuleStringComparison("RuleStringComparisonObject.ContainsXXX_RuleStringComparisonObject", "Save", StringComparisonType.Contains, "XXX", IgnoreCase = true)]
		public string ContainsXXX {
			get { return containsXXX; }
			set { SetPropertyValue("ContainsXXX", ref containsXXX, value); }
		}
		[RuleStringComparison("RuleStringComparisonObject.EqualsValid_RuleStringComparisonObject", "Save", StringComparisonType.Equals, "Valid", IgnoreCase = true)]
		public string EqualsValid {
			get { return equalsValid; }
			set { SetPropertyValue("EqualsValid", ref equalsValid, value); }
		}
		[RuleStringComparison("RuleStringComparisonObject.DoesNotEqualInvalid_RuleStringComparisonObject", "Save", StringComparisonType.NotEquals, "Invalid", IgnoreCase = true)]
		public string DoesNotEqualInvalid {
			get { return doesNotEqualInvalid; }
			set { SetPropertyValue("DoesNotEqualInvalid", ref doesNotEqualInvalid, value); }
		}
    }
}
