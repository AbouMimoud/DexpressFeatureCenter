using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.Xpo;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.Demos;
using DevExpress.Persistent.BaseImpl;

namespace FeatureCenter.Module.KeyProperty {
	[Persistent]
	[NavigationItem(Captions.KeyPropertyGroup), System.ComponentModel.DisplayName(Captions.KeyProperty_GuidKey)]
	[ImageName("KeyProperties.Demo_KeyProperty_Guid")]
	[Hint(Hints.GuidKeyObjectHint)]
	[FriendlyKeyProperty("FriendlyKeyProperty")]
	public class GuidKeyPropertyObject : NoKeyPropertyNamedBaseObject {
		private string friendlyKeyProperty;
		private Guid key;
		public override void AfterConstruction() {
			base.AfterConstruction();
			friendlyKeyProperty = "FriendlyKey-" + DistributedIdGeneratorHelper.Generate(this.Session.DataLayer, this.GetType().FullName, string.Empty);
		}
		public GuidKeyPropertyObject(Session session) : base(session) { }
		[Key(true)]
		public Guid Key {
			get { return key; }
			set { SetPropertyValue("Key", ref key, value); }
		}
		public string FriendlyKeyProperty {
			get { return friendlyKeyProperty; }
			set { SetPropertyValue("FriendlyKeyProperty", ref friendlyKeyProperty, value); }
		}
	}
}
