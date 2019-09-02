using System;
using DevExpress.Persistent.BaseImpl;
using System.ComponentModel;
using DevExpress.Xpo;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.Filtering;
using DevExpress.ExpressApp.Demos;

namespace FeatureCenter.Module.Filtering
{
	[DefaultProperty("DefaultProperty")]
	public class FilterByTextAggregatedObject : BaseObject {
		private string defaultProperty;
		private string nonDefaultProperty;
		public FilterByTextAggregatedObject(Session session) : base(session) { }
		public string DefaultProperty {
			get { return defaultProperty; }
			set { SetPropertyValue("DefaultProperty", ref defaultProperty, value); }
		}
		public string NonDefaultProperty {
			get { return nonDefaultProperty; }
			set { SetPropertyValue("NonDefaultProperty", ref nonDefaultProperty, value); }
		}
	}

	[DefaultProperty("DefaultProperty")]
	public class FilterByTextReferencedObject : BaseObject {
		private string defaultProperty;
		private string nonDefaultProperty;
		public FilterByTextReferencedObject(Session session) : base(session) { }
		public string DefaultProperty {
			get { return defaultProperty; }
			set { SetPropertyValue("DefaultProperty", ref defaultProperty, value); }
		}
		public string NonDefaultProperty {
			get { return nonDefaultProperty; }
			set { SetPropertyValue("NonDefaultProperty", ref nonDefaultProperty, value); }
		}
	}

	[FriendlyKeyProperty("FriendlyKey")]
	[DefaultProperty("DefaultProperty")]
	[NavigationItem(Captions.FilteringGroup), System.ComponentModel.DisplayName(Captions.Filtering_FilterByText)]
	[Hint(Hints.FilterByTextRootObjectHint)]
	[ImageName(FilterByTextRootObject.FilterByTextImageName)]
	public class FilterByTextRootObject : BaseObject {
		private string friendlyKey;
		private string defaultProperty;
		private string nonDefaultProperty;
		private string nonPersistentProperty = "NonPersistentProperty";
		public const string FilterByTextImageName = "Filtering.Demo_Search_FilterByText";

		private FilterByTextAggregatedObject aggregatedObject;
		private FilterByTextReferencedObject referencedObject;

		public FilterByTextRootObject(Session session) : base(session) { }

		public override void AfterConstruction() {
			base.AfterConstruction();
			aggregatedObject = new FilterByTextAggregatedObject(Session);
		}

		public string FriendlyKey {
			get { return friendlyKey; }
			set { SetPropertyValue("FriendlyKey", ref friendlyKey, value); }
		}
		public string DefaultProperty {
			get { return defaultProperty; }
			set { SetPropertyValue("DefaultProperty", ref defaultProperty, value); }
		}
		public string NonDefaultProperty {
			get { return nonDefaultProperty; }
			set { SetPropertyValue("NonDefaultProperty", ref nonDefaultProperty, value); }
		}
		public string NonPersistentProperty {
			get { return nonPersistentProperty; }
		}
		[Aggregated]
		public FilterByTextAggregatedObject AggregatedObject {
			get { return aggregatedObject; }
			set { SetPropertyValue("AggregatedObject", ref aggregatedObject, value); }
		}
		public FilterByTextReferencedObject ReferencedObject {
			get { return referencedObject; }
			set { SetPropertyValue("ReferencedObject", ref referencedObject, value); }
		}
	}
}
