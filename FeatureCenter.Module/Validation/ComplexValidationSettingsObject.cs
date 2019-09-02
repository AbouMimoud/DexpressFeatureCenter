using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using DevExpress.ExpressApp;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using DevExpress.ExpressApp.Demos;

namespace FeatureCenter.Module.Validation {
	[NavigationItem(Captions.ValidationGroup), System.ComponentModel.DisplayName(Captions.Validation_ComplexValidationSettings)]
	[Hint(Hints.ComplexValidationSettingsHint)]
    [RuleObjectExists("ComplexValidationSettingsObject_RuleObjectExists", DefaultContexts.Save, "FirstName = '@FirstName' AND LastName = '@LastName'", MessageTemplateMustExist = "Objects with the same combination of the 'FirstName' and 'LastName' properties must not exist.", InvertResult = true, SkipNullOrEmptyValues = true, FoundObjectMessageFormat = "'{0}'", FoundObjectMessagesSeparator = ";")]
	[RuleIsReferenced("ComplexValidationSettingsObject_RuleIsReferenced", DefaultContexts.Delete, typeof(ComplexValidationSettingsObject), "ReferencedObject", MessageTemplateMustBeReferenced = "To delete the '{TargetObject}' object, you must be sure that it is not referenced anywhere.", InvertResult = true, FoundObjectMessageFormat = "'{0}'", FoundObjectMessagesSeparator = ";")]
	[ImageName("Validation.Demo_Complex_Validation_Settings")]
	public class ComplexValidationSettingsObject : ValidationDemoBaseObject {
		private string firstName;
		private string lastName;
		private ComplexValidationSettingsObject referencedObject;
		
		public ComplexValidationSettingsObject(Session session) : base(session) { }
		
		public string FirstName {
			get { return firstName; }
			set { SetPropertyValue("FirstName", ref firstName, value); }
		}
		public string LastName {
			get { return lastName; }
			set { SetPropertyValue("LastName", ref lastName, value); }
		}
		public ComplexValidationSettingsObject ReferencedObject {
			get { return referencedObject; }
			set { SetPropertyValue("ReferencedObject", ref referencedObject, value); }
		}
	}
}
