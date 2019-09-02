using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp;
using DevExpress.Xpo;
using DevExpress.Persistent.Validation;
using DevExpress.ExpressApp.Demos;

namespace FeatureCenter.Module.Validation {
    [NavigationItem(Captions.ValidationGroup), System.ComponentModel.DisplayName(Captions.Validation_RuleRequiredField)]
	[Hint(Hints.RuleRequiredFieldHint)]
    [ImageName("Validation.Demo_Rule_Required_Field")]
    public class RuleRequiredFieldObject : ValidationDemoBaseObject {
		private string requiredStringProperty;
		private DateTime? requiredDateTimeProperty;

		public RuleRequiredFieldObject(Session session) : base(session) { }

		[RuleRequiredField("RuleRequiredFieldObject.RequiredStringProperty_RuleRequiredField", "Save")]
		public string RequiredStringProperty {
			get { return requiredStringProperty; }
			set { SetPropertyValue("RequiredStringProperty", ref requiredStringProperty, value); }
		}
		[RuleRequiredField("RuleRequiredFieldObject.RequiredDateTimeProperty_RuleRequiredFieldObject", "Save")]
		public DateTime? RequiredDateTimeProperty {
			get { return requiredDateTimeProperty; }
			set { SetPropertyValue("RequiredDateTimeProperty", ref requiredDateTimeProperty, value); }
		}
	}
}
