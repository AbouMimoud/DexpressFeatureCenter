using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using FeatureCenter.Module.Audit;
using System.ComponentModel;

namespace FeatureCenter.Module {
	[NavigationItem(false)]
	[DefaultProperty("Name")]
	[ImageName("ListEditors.Demo_ListEditors_Grid")]
	public class GridBaseObject : NamedBaseObject {
		private int intProperty;
		private bool booleanProperty;
		private SampleEnum enumProperty;
		public GridBaseObject(Session session) : base(session) { }
		[VisibleInListView(true)]
		public int IntegerProperty {
			get { return intProperty; }
			set { SetPropertyValue<int>("IntegerProperty", ref intProperty, value); }
		}
		[VisibleInListView(true)]
		public bool BooleanProperty {
			get { return booleanProperty; }
			set { SetPropertyValue("BooleanProperty", ref booleanProperty, value); }
		}
		[VisibleInListView(true)]
		public SampleEnum EnumProperty {
			get { return enumProperty; }
			set { SetPropertyValue("EnumProperty", ref enumProperty, value); }
		}
	}
}
