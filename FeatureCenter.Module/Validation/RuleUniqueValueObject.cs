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
    public class RuleUniqueValueCollectionObject : NamedBaseObject {
        private int itemUniqueValue;
        private RuleUniqueValueObject owner;
        public RuleUniqueValueCollectionObject(Session session) : base(session) { }
        public int ItemUniqueValue {
            get { return itemUniqueValue; }
            set { itemUniqueValue = value; }
        }
        [Association("RuleUniqueValueObject-RuleUniqueValueCollectionObjects")]
        public RuleUniqueValueObject Owner {
            get { return owner; }
            set { owner = value; }
        }
    }

	[NavigationItem(Captions.ValidationGroup), System.ComponentModel.DisplayName(Captions.Validation_RuleUniqueValue)]
	[Hint(Hints.RuleUniqueValueHint)]
    [ImageName("Validation.Demo_Rule_Unique_Value")]
    public class RuleUniqueValueObject : ValidationDemoBaseObject {
		private string uniqueValue;
		
		public RuleUniqueValueObject(Session session) : base(session) { }

        [RuleUniqueValue("RuleUniqueValueObject.UniqueValue_RuleUniqueValue", "Save", SkipNullOrEmptyValues = false)]
		public string UniqueValue {
			get { return uniqueValue; }
			set { SetPropertyValue("UniqueValue", ref uniqueValue, value); }
		}
        [RuleUniqueValue("UniqueValue1", DefaultContexts.Save, TargetPropertyName = "ItemUniqueValue")]
        [Association("RuleUniqueValueObject-RuleUniqueValueCollectionObjects"), Aggregated]
        public XPCollection<RuleUniqueValueCollectionObject> Collection {
            get { return GetCollection<RuleUniqueValueCollectionObject>("Collection"); }
        }
	}
}
