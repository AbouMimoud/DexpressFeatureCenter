using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.Xpo;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.Demos;

namespace FeatureCenter.Module.Win.Printing {
	[NavigationItem(Captions.PrintingGroup), System.ComponentModel.DisplayName(Captions.Printing_Layout)]
	[CreatableItem(false)]
	[Hint(Hints.LayoutDemoObjectHint, DevExpress.ExpressApp.ViewType.DetailView)]
	[ImageName("ListEditors.Demo_Layout")]
	[AutoCreatableObject]
	public class LayoutDemoObject : XPBaseObject {
		private int key;
		private string name;
		private int intProperty;
		private float floatProperty;
		private decimal decProperty;
		private bool boolProperty;
		private string stringProperty;
		public LayoutDemoObject(Session session) : base(session) { }
		[Key(false)]
		[System.ComponentModel.Browsable(false)]
		public int Key {
			get { return key; }
			set { SetPropertyValue("Name", ref key, value); }
		}
		[Index(1)]
		public string Name {
			get { return name; }
			set { SetPropertyValue("Name", ref name, value); }
		}
		[Index(2)]
		public int IntegerProperty {
			get { return intProperty; }
			set { SetPropertyValue("IntegerProperty", ref intProperty, value); }
		}
		[Index(3)]
		public float FloatProperty {
			get { return floatProperty; }
			set { SetPropertyValue("FloatProperty", ref floatProperty, value); }
		}
		[Index(4)]
		public decimal DecimalProperty {
			get { return decProperty; }
			set { SetPropertyValue("DecimalProperty", ref decProperty, value); }
		}
		[Index(5)]
		public bool BooleanProperty {
			get { return boolProperty; }
			set { SetPropertyValue("BooleanProperty", ref boolProperty, value); }
		}
		[Index(6)]
		public string StringProperty {
			get { return stringProperty; }
			set { SetPropertyValue("StringProperty", ref stringProperty, value); }
		}
		[DisplayName(Captions.Printing_Layout_NestedObjectWithIntegerProperty)]
		[Association("LayoutDemoObject-NestedObjectWithIntegerProperty")]
		public XPCollection<NestedObject1> NestedObjectWithIntegerProperty {
			get { return GetCollection<NestedObject1>("NestedObjectWithIntegerProperty"); }
		}
		[Association("LayoutDemoObject-NestedObjectWithBooleanProperty")]
		[DisplayName(Captions.Printing_Layout_NestedObjectWithBooleanProperty)]
		public XPCollection<NestedObject2> NestedObjectWithBooleanProperty {
			get { return GetCollection<NestedObject2>("NestedObjectWithBooleanProperty"); }
		}
	}
	[NavigationItem(false)]
	[CreatableItem(false)]
	public class NestedObject1 : NamedBaseObject {
		private int intProperty;
		private LayoutDemoObject parent;
		public NestedObject1(Session session) : base(session) { }
		[System.ComponentModel.Browsable(false)]
		[Association("LayoutDemoObject-NestedObjectWithIntegerProperty")]
		public LayoutDemoObject Parent {
			get { return parent; }
			set { SetPropertyValue<LayoutDemoObject>("Parent", ref parent, value); }
		}
		public int IntegerProperty {
			get { return intProperty; }
			set { SetPropertyValue("IntegerProperty", ref intProperty, value); }
		}
	}
	[NavigationItem(false)]
	[CreatableItem(false)]
	public class NestedObject2 : NamedBaseObject {
		private bool boolProperty;
		private LayoutDemoObject parent;
		public NestedObject2(Session session) : base(session) { }
		[System.ComponentModel.Browsable(false)]
		[Association("LayoutDemoObject-NestedObjectWithBooleanProperty")]
		public LayoutDemoObject Parent {
			get { return parent; }
			set { SetPropertyValue<LayoutDemoObject>("Parent", ref parent, value); }
		}
		public bool BooleanProperty {
			get { return boolProperty; }
			set { SetPropertyValue("BooleanProperty", ref boolProperty, value); }
		}
	}
}
