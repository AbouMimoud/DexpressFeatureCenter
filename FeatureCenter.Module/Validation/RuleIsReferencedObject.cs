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
	[NavigationItem(Captions.ValidationGroup), System.ComponentModel.DisplayName(Captions.Validation_RuleIsReferenced)]
	[Hint(Hints.RuleIsReferencedHint)]
    [RuleIsReferenced("RuleIsReferencedObject_RuleIsReferenced", DefaultContexts.Delete, typeof(RuleIsReferencedObject), "ReferencedObject", InvertResult = true, MessageTemplateMustBeReferenced = "If you want to delete this object, you must be sure it is not referenced in any other object.")]
	[ImageName("Validation.Demo_Rule_IsReferenced")]
    public class RuleIsReferencedObject : ValidationDemoBaseObject {
		private RuleIsReferencedObject referencedObject;
		
		public RuleIsReferencedObject(Session session) : base(session) { }

		public RuleIsReferencedObject ReferencedObject {
			get { return referencedObject; }
			set { SetPropertyValue("ReferencedObject", ref referencedObject, value); }
		}
    }
}
