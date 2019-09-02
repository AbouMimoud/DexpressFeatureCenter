using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp;
using DevExpress.Xpo;
using DevExpress.Persistent.Validation;
using System.ComponentModel;
using DevExpress.ExpressApp.Demos;

namespace FeatureCenter.Module.Validation {
	[NavigationItem(Captions.ValidationGroup), System.ComponentModel.DisplayName(Captions.Validation_RuleFromBoolProperty)]
	[Hint(Hints.RuleFromBoolPropertyHint)]
	[ImageName("Validation.Demo_Rule_From_Bool_Property")]
	public class RuleFromBoolPropertyObject : ValidationDemoBaseObject  {
		private string containsValid = string.Empty;
		private string lengthMoreThan10 = string.Empty;
		private bool mustBeTrue;
		private string leftPart = string.Empty;
		private string middlePart = string.Empty;
		private string rightPart = string.Empty;
		private string fullString = string.Empty;

		public RuleFromBoolPropertyObject(Session session) : base(session) { }
		public override void AfterConstruction() {
			base.AfterConstruction();
			LeftPart = "LeftPart";
			MiddlePart = "MiddlePart";
			RightPart = "RightPart";
		}

		public string ContainsValid {
			get { return containsValid; }
			set { SetPropertyValue("ContainsValid", ref containsValid, value); }
		}
		public string LengthMoreThan10 {
			get { return lengthMoreThan10; }
			set { SetPropertyValue("LengthMoreThan10", ref lengthMoreThan10, value); }
		}
		public bool MustBeTrue {
			get { return mustBeTrue; }
			set { SetPropertyValue("MustBeTrue", ref mustBeTrue, value); }
		}
		[RuleFromBoolProperty(
			"RuleFromBoolPropertyObject.IsComplexExpressionValid_RuleFromBoolProperty",
			DefaultContexts.Save,
			"The MustBeTrue property must be set to true, the LengthMoreThan10 property's value length must be whose length is more than 10 and the ContainsValid property value must contain 'Valid'",
			UsedProperties = "ContainsValid,LengthMoreThan10,MustBeTrue", SkipNullOrEmptyValues = false)]
		[NonPersistent]
		public bool IsComplexExpressionValid {
			get {
				return containsValid.Contains("Valid")
					&& lengthMoreThan10.Length > 10
					&& mustBeTrue;
			}
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
		[RuleFromBoolProperty("RuleFromBoolPropertyObject.IsFullStringValid_RuleFromBoolProperty", DefaultContexts.Save, "The FullString property must represent a concatenation of the LeftPart, MiddlePart and RightPart property values.")]
		[NonPersistent]
		public bool IsFullStringValid {
			get {
				return fullString == string.Format("{0}{1}{2}", leftPart, middlePart, rightPart);
			}
		}
	}
}
