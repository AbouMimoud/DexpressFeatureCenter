using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.Xpo;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.Demos;

namespace FeatureCenter.Module.KeyProperty {
	[Persistent]
	[NavigationItem(Captions.KeyPropertyGroup), System.ComponentModel.DisplayName(Captions.KeyProperty_IntegerKey)]
	[ImageName("KeyProperties.Demo_KeyProperty_Integer")]
	[Hint(Hints.IntegerKeyObjectHint)]
	[FriendlyKeyProperty("Key")]
	public class IntegerKeyPropertyObject : NoKeyPropertyNamedBaseObject {
		private int key;
		public IntegerKeyPropertyObject(Session session) : base(session) { }
		[Key(true)]
		[VisibleInListView(true)]
		public int Key {
			get { return key; }
			set { SetPropertyValue("Key", ref key, value); }
		}
	}
}
