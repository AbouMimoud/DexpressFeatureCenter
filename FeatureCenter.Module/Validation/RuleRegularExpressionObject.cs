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
	[NavigationItem(Captions.ValidationGroup), System.ComponentModel.DisplayName(Captions.Validation_RuleRegularExpression)]
	[Hint(Hints.RuleRegularExpressionHint)]
    [ImageName("Validation.Demo_Rule_Regular_Expression")]
    public class RuleRegularExpressionObject : ValidationDemoBaseObject {
		private string email;

		public RuleRegularExpressionObject(Session session) : base(session) { }

		[RuleRegularExpression("RuleRegularExpressionObject.Email_RuleRegularExpression", DefaultContexts.Save, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")]
		public string Email {
			get { return email; }
			set { SetPropertyValue("Email", ref email, value); }
		}
	}
}
