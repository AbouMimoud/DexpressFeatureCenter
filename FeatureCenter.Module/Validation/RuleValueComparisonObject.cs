using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using DevExpress.Persistent.Validation;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Demos;
using DevExpress.Data.Filtering;

namespace FeatureCenter.Module.Validation {
    public class RuleValueComparisonCollectionObject : NamedBaseObject {
        private decimal sumIsGreaterThan100;
        private RuleValueComparisonObject owner;
        public RuleValueComparisonCollectionObject(Session session) : base(session) { }
        public decimal SumIsGreaterThan100 {
            get { return sumIsGreaterThan100; }
            set { sumIsGreaterThan100 = value; }
        }
        [Association("RuleValueComparisonObject-RuleValueComparisonCollectionObjects")]
        public RuleValueComparisonObject Owner {
            get { return owner; }
            set { owner = value; }
        }
    }

	[NavigationItem(Captions.ValidationGroup), System.ComponentModel.DisplayName(Captions.Validation_RuleValueComparison)]
	[Hint(Hints.RuleValueComparisonHint)]
    [ImageName("Validation.Demo_Rule_Value_Comparison")]
    public class RuleValueComparisonObject : ValidationDemoBaseObject {
		private int greaterThanZero;
		private DateTime beforeFebruary2008;
		private double notMoreThan10;
		private int equals100;
		private int notLessThanOne;
		private int notEquals1000;
		private DateTime beforeToday;

		public RuleValueComparisonObject(Session session) : base(session) { }

		[RuleValueComparison("RuleValueComparisonObject.GreaterThanZero_RuleValueComparisonObject", DefaultContexts.Save, ValueComparisonType.GreaterThan, 0)]
		public int GreaterThanZero {
			get { return greaterThanZero; }
			set { SetPropertyValue("GreaterThanZero", ref greaterThanZero, value); }
		}
		[RuleValueComparison("RuleValueComparisonObject.Equals100_RuleValueComparisonObject", DefaultContexts.Save, ValueComparisonType.Equals, 100)]
		public int Equals100 {
			get { return equals100; }
			set { SetPropertyValue("Equals100", ref equals100, value); }
		}
		[RuleValueComparison("RuleValueComparisonObject.NotLessThanOne_RuleValueComparisonObject", DefaultContexts.Save, ValueComparisonType.GreaterThanOrEqual, 1)]
		public int NotLessThanOne {
			get { return notLessThanOne; }
			set { SetPropertyValue("NotLessThanOne", ref notLessThanOne, value); }
		}
		[RuleValueComparison("RuleValueComparisonObject.NotEquals1000_RuleValueComparisonObject", DefaultContexts.Save, ValueComparisonType.NotEquals, 1000)]
		public int NotEquals1000 {
			get { return notEquals1000; }
			set { SetPropertyValue("NotEquals1000", ref notEquals1000, value); }
		}
		[RuleValueComparison("RuleValueComparisonObject.BeforeFebruary2008_RuleValueComparisonObject", DefaultContexts.Save, ValueComparisonType.LessThan, "Feb 1, 2008")]
		public DateTime BeforeFebruary2008 {
			get { return beforeFebruary2008; }
			set { SetPropertyValue("BeforeFebruary2008", ref beforeFebruary2008, value); }
		}
		[RuleValueComparison("RuleValueComparisonObject.NotMoreThan10_RuleValueComparisonObject", DefaultContexts.Save, ValueComparisonType.LessThanOrEqual, 10)]
		public double NotMoreThan10 {
			get { return notMoreThan10; }
			set { SetPropertyValue("NotMoreThan10", ref notMoreThan10, value); }
		}
        [RuleValueComparison("RuleValueComparisonObject.BeforeToday_RuleValueComparisonObject", DefaultContexts.Save, ValueComparisonType.LessThan, "LocalDateTimeToday()", ParametersMode.Expression)]
		public DateTime BeforeToday {
			get { return beforeToday; }
			set { SetPropertyValue("BeforeToday", ref beforeToday, value); }
		}
        [RuleValueComparison("RuleValueComparisonObject.Collection.RuleValueComparison1", DefaultContexts.Save, ValueComparisonType.GreaterThan, 100, TargetPropertyName = "SumIsGreaterThan100", TargetCollectionAggregate = Aggregate.Sum, CustomMessageTemplate = @"The sum of the ""{TargetPropertyName}"" values must be greater than ""{RightOperand}"". The current value is ""{AggregatedTargetValue}"".")]
        [RuleValueComparison("RuleValueComparisonObject.Collection.RuleValueComparison2", DefaultContexts.Save, ValueComparisonType.Equals, 3, TargetCollectionAggregate = Aggregate.Count, CustomMessageTemplate = @"The ""{TargetCollectionOwnerType}.{TargetCollectionPropertyName}"" collection must contain {RightOperand} elements. Currently, it contains {AggregatedTargetValue} elements.")]
        [Association("RuleValueComparisonObject-RuleValueComparisonCollectionObjects"), Aggregated]
        public XPCollection<RuleValueComparisonCollectionObject> Collection {
            get { return GetCollection<RuleValueComparisonCollectionObject>("Collection"); }
        }
    }
}
