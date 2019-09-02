using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.Persistent.Validation;
using DevExpress.ExpressApp.Demos;
using FeatureCenter.Module.Navigation;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace FeatureCenter.Module.Validation {
    [NavigationItem(Captions.ValidationGroup), System.ComponentModel.DisplayName(Captions.Validation_RuleCombinationOfPropertiesIsUnique)]
    [Hint(Hints.RuleCombinationOfPropertiesIsUniqueHint)]
    [RuleCombinationOfPropertiesIsUnique("RuleCombinationOfPropertiesIsUniqueObject_RuleCombinationOfPropertiesIsUnique", DefaultContexts.Save, "Description,Type", SkipNullOrEmptyValues = false)]
    [ImageName("Validation.Demo_Rule_Combination_Of_Properties_Is_Unique")]
    public class RuleCombinationOfPropertiesIsUniqueObject : ValidationDemoBaseObject {
        private SampleEnum type;
        private string description;

        public RuleCombinationOfPropertiesIsUniqueObject(Session session) : base(session) { }

        public SampleEnum Type {
            get { return type; }
            set { SetPropertyValue("Type", ref type, value); }
        }
        public string Description {
            get { return description; }
            set { SetPropertyValue("Description", ref description, value); }
        }
    }
}
