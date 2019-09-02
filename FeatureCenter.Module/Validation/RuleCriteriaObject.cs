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
    public class RuleCriteriaCollectionObject : NamedBaseObject {
        private int lessSum;
        private int biggerSum;
        private RuleCriteriaObject owner;
        public RuleCriteriaCollectionObject(Session session) : base(session) { }
        public int LessSum {
            get { return lessSum; }
            set { lessSum = value; }
        }
        public int BiggerSum {
            get { return biggerSum; }
            set { biggerSum = value; }
        }
        [Association("RuleCriteriaObject-RuleCriteriaCollectionObjects")]
        public RuleCriteriaObject Owner {
            get { return owner; }
            set { owner = value; }
        }
    }

	[NavigationItem(Captions.ValidationGroup), System.ComponentModel.DisplayName(Captions.Validation_RuleCriteria)]
	[Hint(Hints.RuleCriteriaHint)]
    [RuleCriteria("RuleCriteriaObject_RuleCriteria", DefaultContexts.Save, @"RequiredField != '' AND StartsWith(StartsWithA, 'A') AND GreaterThanTen > 10", SkipNullOrEmptyValues = false)]
    [RuleCriteria("RuleCriteriaObject_RuleCriteria2", DefaultContexts.Save, @"[Today] = LocalDateTimeToday()", SkipNullOrEmptyValues = false)]
    [RuleCriteria("RuleCriteriaObject_RuleCriteria3", DefaultContexts.Save, @"MaxValue >= MinValue")]
	[ImageName("Validation.Demo_Rule_Criteria")]
    public class RuleCriteriaObject : ValidationDemoBaseObject {
		private string requiredField;
		private string startsWithA;
		private int greaterThanTen;
		private DateTime today;
        private int minValue;
        private int maxValue;

		public RuleCriteriaObject(Session session) : base(session) { }
		
		public string RequiredField {
			get { return requiredField; }
			set { SetPropertyValue("RequiredField", ref requiredField, value); }
		}
		public string StartsWithA {
			get { return startsWithA; }
			set { SetPropertyValue("StartsWithA", ref startsWithA, value); }
		}
		public int GreaterThanTen {
			get { return greaterThanTen; }
			set { SetPropertyValue("GreaterThanTen", ref greaterThanTen, value); }
		}
		public DateTime Today {
			get { return today; }
			set { SetPropertyValue("Today", ref today, value); }
		}
        public int MinValue {
            get { return minValue; }
			set { SetPropertyValue("MinValue", ref minValue, value); }
        }
        public int MaxValue {
            get { return maxValue; }
			set { SetPropertyValue("MaxValue", ref maxValue, value); }
        }
        [RuleCriteria("RuleCriteriaObject_Collection_RuleCriteria", DefaultContexts.Save, @"Owner.Collection.Sum(BiggerSum) > Owner.Collection.Sum(LessSum)")]
        [Association("RuleCriteriaObject-RuleCriteriaCollectionObjects"), Aggregated]
        public XPCollection<RuleCriteriaCollectionObject> Collection {
            get { return GetCollection<RuleCriteriaCollectionObject>("Collection"); }
        }
	}
}
