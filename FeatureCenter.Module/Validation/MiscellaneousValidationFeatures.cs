using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.Xpo;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.Demos;
using DevExpress.Persistent.Validation;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;

namespace FeatureCenter.Module.Validation {
    public class CustomContextValidationController : ViewController {
        SimpleAction validateInCustomContextAction;
        private void validateInCustomContextAction_Execute(object sender, SimpleActionExecuteEventArgs e) {
            Validator.RuleSet.Validate(ObjectSpace, View.CurrentObject, "IsAllowedToExecuteAction");
        }

        public CustomContextValidationController() {
            this.TargetObjectType = typeof(MiscellaneousValidationFeaturesObject);
            this.TargetViewType = ViewType.DetailView;

            this.validateInCustomContextAction = new SimpleAction(this, "ValidateInCustomContext", PredefinedCategory.Edit);
            this.validateInCustomContextAction.Caption = "Validate In Custom Context";
            this.validateInCustomContextAction.Execute += new SimpleActionExecuteEventHandler(validateInCustomContextAction_Execute);
        }
    }

	[NavigationItem(Captions.ValidationGroup), System.ComponentModel.DisplayName(Captions.Validation_MiscellaneousValidationFeatures)]
    [Hint(Hints.MiscellaneousValidationFeaturesHint)]
	[ImageName("Validation.Demo_Miscellaneous_Validation_Features")]
    public class MiscellaneousValidationFeaturesObject : ValidationDemoBaseObject {
        private string propertyWithDisplayNameAttribute;
        private int propertyWithLocalizedCaption;

        public MiscellaneousValidationFeaturesObject(Session session) : base(session) { }

        [RuleStringComparison("RuleStringComparison_SaveContext_SkippedByNullOrEmptyValue", DefaultContexts.Save, StringComparisonType.Contains, "is allowed", SkipNullOrEmptyValues = true)]
        [RuleStringComparison("RuleStringComparison_CustomContext", "IsAllowedToExecuteAction", StringComparisonType.Equals, "Action execution is allowed", SkipNullOrEmptyValues = false)]
		[DisplayName(Captions.Validation_MiscellaneousValidationFeatures_PropertyWithDisplayNameAttribute)]
        public string PropertyWithDisplayNameAttribute {
            get { return propertyWithDisplayNameAttribute; }
			set { SetPropertyValue("PropertyWithDisplayNameAttribute", ref propertyWithDisplayNameAttribute, value); }
        }
        [RuleRange("RuleRange_CustomContext", "IsAllowedToExecuteAction", 5, 15)]
        [RuleRange("RuleRange_SaveContext", DefaultContexts.Save, 10, 15)]
        [RuleValueComparison("RuleValueComparison_SaveContext_SkippedByTargetCriteria", DefaultContexts.Save, ValueComparisonType.Equals, 10, TargetCriteria = "PropertyWithDisplayNameAttribute = 'Action execution is allowed'")]
        public int PropertyWithLocalizedCaption {
            get { return propertyWithLocalizedCaption; }
			set { SetPropertyValue("PropertyWithLocalizedCaption", ref propertyWithLocalizedCaption, value); }
        }
    }

}
