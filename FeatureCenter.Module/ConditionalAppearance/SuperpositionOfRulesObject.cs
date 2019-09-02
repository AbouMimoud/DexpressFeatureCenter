using System;
using DevExpress.Xpo;
using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.Demos;

namespace FeatureCenter.Module.ConditionalAppearance {
	[ImageName("ConditionalAppearance.ConditionalAppearance")]
	[NavigationItem(Captions.ConditionalAppearanceGroup)]
	[System.ComponentModel.DisplayName(Captions.ConditionalAppearance_SuperpositionOfRules)]
	//[Hint(Hints.ConditionalAppearance_SuperpositionOfRulesbjectHint, ViewType.Any)]
    [Appearance("SuperpositionOfRulesProperty1", TargetItems = "*;Property1;AllPropertiesDisabledExcept", Criteria = "AllPropertiesDisabledExcept == 'Property1'", Enabled = false)]
    [Appearance("SuperpositionOfRulesProperty2", TargetItems = "*;Property2;AllPropertiesDisabledExcept", Criteria = "AllPropertiesDisabledExcept == 'Property2'", Enabled = false)]
    [Hint(Hints.ConditionalAppearance_SuperpositionOfRulesbjectHint, ViewType.Any)]
	public class ConditionalAppearanceSuperpositionOfRulesObject : NamedBaseObject {
		public ConditionalAppearanceSuperpositionOfRulesObject(Session session) : base(session) { }
		public ConditionalAppearanceSuperpositionOfRulesObject(Session session, string name)
			: base(session, name) {
			if(!session.IsObjectsLoading)
				Name = name;
		}
		private string _Property1;
		public string Property1 {
			get { return _Property1; }
			set { SetPropertyValue("Property1", ref _Property1, value); }
		}
		private string _Property2;
		public string Property2 {
			get { return _Property2; }
			set { SetPropertyValue("Property2", ref _Property2, value); }
		}
		private string _Property3;
		public string Property3 {
			get { return _Property3; }
			set { SetPropertyValue("Property3", ref _Property3, value); }
		}
		private ConditionalAppearanceSuperpositionOfRulesAllPropertiesDisabledExcept _AllPropertiesDisabledExcept;
		[ImmediatePostData]
		public ConditionalAppearanceSuperpositionOfRulesAllPropertiesDisabledExcept AllPropertiesDisabledExcept {
			get { return _AllPropertiesDisabledExcept; }
			set { SetPropertyValue("AllPropertiesDisabledExcept", ref _AllPropertiesDisabledExcept, value); }
		}
	}
	public enum ConditionalAppearanceSuperpositionOfRulesAllPropertiesDisabledExcept {
		Property1,
		Property2,
        EnableAll
	}
}
