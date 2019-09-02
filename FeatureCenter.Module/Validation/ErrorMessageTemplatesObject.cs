using System;
using DevExpress.ExpressApp.Demos;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;

namespace FeatureCenter.Module.Validation {
	public class DateAndPrice : BaseObject {
		private decimal price;
		private DateTime date;

		public DateAndPrice(Session session) : base(session) { }

        [ModelDefault("DisplayFormat", "{0:C}")]
        [ModelDefault("EditMask", "C")] 
		public decimal Price {
			get { return price; }
			set { SetPropertyValue("Price", ref price, value); }
		}
        [ModelDefault("DisplayFormat", "{0:D}")]
        [ModelDefault("EditMask", "D")] 
		public DateTime Date {
			get { return date; }
			set { SetPropertyValue("Date", ref date, value); } 
		}
	}

	[NavigationItem(Captions.ValidationGroup), System.ComponentModel.DisplayName(Captions.Validation_ValidationMessageTemplates)]
	[Hint(Hints.ValidationMessageTemplatesHint)]
	[RuleCriteria("ValidationTemplatesObject.DateAndPrice.Price_RuleCriteria", "Save", "DateAndPrice.Price > 0",
		"Price must be positive, but the current value is '{TargetObject.DateAndPrice.Price:C}'.")]
    [RuleCriteria("ValidationTemplatesObject.DateAndPrice.Date_RuleCriteria", "Save", "DateAndPrice.Date > LocalDateTimeToday()",
        "Date must be greater than LocalDateTimeToday(). Currently, it is set to {TargetObject.DateAndPrice.Date:d}, which is {TargetObject.DateAndPrice.Date.DayOfWeek}, the {TargetObject.DateAndPrice.Date.DayOfYear} day of the year.")]
	[ImageName("Validation.Demo_Validation_Message_Templates")]
    public class ValidationTemplatesObject : ValidationDemoBaseObject {
		private string containsAbc;
		private int greaterThanZero;
		private string leftPart = string.Empty;
		private string middlePart = string.Empty;
		private string rightPart = string.Empty;
		private string fullString = string.Empty;
		private DateAndPrice dateAndPrice;

		public ValidationTemplatesObject(Session session) : base(session) {	}
		
		[RuleStringComparison("ValidationTemplatesObject.ContainsAbc_RuleStringComparison", "Save", StringComparisonType.Contains, "Abc", "The '{TargetPropertyName}' property value should contain '{OperandValue}'. The current value is '{TargetValue}'")]
		public string ContainsAbc {
			get { return containsAbc; }
			set { SetPropertyValue("ContainsAbc", ref containsAbc, value); }
		}
		[RuleValueComparison("ValidationTemplatesObject.GreaterThanZero_RuleValueComparison", "Save", ValueComparisonType.GreaterThan, 0, "The '{TargetPropertyName}' property has the '{TargetValue}' value. It should be greater than '{RightOperand}'.")]
		public int GreaterThanZero {
			get { return greaterThanZero; }
			set { SetPropertyValue("GreaterThanZero", ref greaterThanZero, value); }
		}
		public string LeftPart {
			get { return leftPart; }
			set { SetPropertyValue("LeftPart", ref leftPart, value); }
		}
		public string RightPart {
			get { return rightPart; }
			set { SetPropertyValue("RightPart", ref rightPart, value); }
		}
		public string MiddlePart {
			get { return middlePart; }
			set { SetPropertyValue("MiddlePart", ref middlePart, value); }
		}
		public string FullString {
			get { return fullString; }
			set { SetPropertyValue("FullString", ref fullString, value); }
		}
		[RuleFromBoolProperty("ValidationTemplatesObject.IsFullStringValid_RuleFromBoolProperty", DefaultContexts.Save, "The FullString property must represent a concatenation of the LeftPart, MiddlePart and RightPart property values. Now, it has the '{FullString}' value; LeftPart = '{LeftPart}', MiddlePart = '{MiddlePart}', RightPart = '{RightPart}'")]
		[NonPersistent]
		public bool IsFullStringValid {
			get {
				return fullString == string.Format("{0}{1}{2}", leftPart, middlePart, rightPart);
			}
		}
		[Aggregated]
		[ExpandObjectMembers(ExpandObjectMembers.Always)]
		public DateAndPrice DateAndPrice {
			get { return dateAndPrice; }
			set { SetPropertyValue("DateAndPrice", ref dateAndPrice, value); }
		}
	}
}
