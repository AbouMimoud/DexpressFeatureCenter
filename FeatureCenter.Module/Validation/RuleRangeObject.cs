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
    public class RuleRangeCollectionObject : NamedBaseObject {
        private decimal sumBetween0And50;
        private DateTime atLeastOneValueWithinFirstWeekOf2009;
        private RuleRangeObject owner;
        public RuleRangeCollectionObject(Session session) : base(session) { }
        public decimal SumBetween0And50 {
            get { return sumBetween0And50; }
            set { sumBetween0And50 = value; }
        }
        public DateTime AtLeastOneValueWithinFirstWeekOf2009 {
            get { return atLeastOneValueWithinFirstWeekOf2009; }
            set { atLeastOneValueWithinFirstWeekOf2009 = value; }
        } 
        [Association("RuleRangeObject-RuleRangeCollectionObjects")]
        public RuleRangeObject Owner {
            get { return owner; }
            set { SetPropertyValue("Owner", ref owner, value); }
        }
    }

	[NavigationItem(Captions.ValidationGroup), System.ComponentModel.DisplayName(Captions.Validation_RuleRange)]
	[Hint(Hints.RuleRangeHint)]
    [ImageName("Validation.Demo_Rule_Range")]
    public class RuleRangeObject : ValidationDemoBaseObject {
		private int fromOneToFive;
		private DateTime during2008;
		private DateTime lastSevenDays;
		
		public RuleRangeObject(Session session) : base(session) { }
		
		[RuleRange("RuleRangeObject.FromOneToFive_RuleRange", "Save", 1, 5)]
		public int FromOneToFive {
			get { return fromOneToFive; }
			set { SetPropertyValue("FromOneToFive", ref fromOneToFive, value); }
		}
		[RuleRange("RuleRangeObject.During2008_RuleRange", "Save", "1 Jan 2008", "31 Dec 2008")]
		public DateTime During2008 {
			get { return during2008; }
			set { SetPropertyValue("During2008", ref during2008, value); }
		}
        [RuleRange("RuleRangeObject.LastSevenDays_RuleRange", "Save", "AddDays(LocalDateTimeToday(), -7)", "LocalDateTimeToday()", ParametersMode.Expression)]
		public DateTime LastSevenDays {
			get { return lastSevenDays; }
			set { SetPropertyValue("LastSevenDays", ref lastSevenDays, value); }
		}
        [RuleRange("RuleRangeObject.Collection_RuleRange1", DefaultContexts.Save, "1 Jan 2009", "7 Jan 2009", TargetPropertyName = "AtLeastOneValueWithinFirstWeekOf2009", TargetCollectionAggregate = Aggregate.Exists, CustomMessageTemplate = @"There must be at least one object which ""{TargetPropertyName}"" value is within ""{MinimumValue}"" and ""{MaximumValue}"" range.")]
        [RuleRange("RuleRangeObject.Collection_RuleRange2", DefaultContexts.Save, 0, 50, TargetPropertyName = "SumBetween0And50", TargetCollectionAggregate = Aggregate.Sum, CustomMessageTemplate = @"The sum of the ""{TargetPropertyName}"" values must be within ""{MinimumValue}"" and ""{MaximumValue}"" range. The current value is ""{AggregatedTargetValue}""")]
        [Association("RuleRangeObject-RuleRangeCollectionObjects"), Aggregated]
        public XPCollection<RuleRangeCollectionObject> Collection {
            get { return GetCollection<RuleRangeCollectionObject>("Collection"); }
        }
	}
}
