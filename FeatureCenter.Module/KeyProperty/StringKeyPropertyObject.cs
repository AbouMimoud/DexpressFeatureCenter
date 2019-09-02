using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.Xpo;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using System.ComponentModel;
using DevExpress.ExpressApp.Demos;
using DevExpress.Persistent.Validation;
using DevExpress.ExpressApp.Model;

namespace FeatureCenter.Module.KeyProperty {
	[Persistent]
	[NavigationItem(Captions.KeyPropertyGroup), System.ComponentModel.DisplayName(Captions.KeyProperty_StringKey)]
	[ImageName("KeyProperties.Demo_KeyProperty_String")]
	[Hint(Hints.StringKeyObjectHint)]
	[FriendlyKeyProperty("Key")]
	public class StringKeyPropertyObject : NoKeyPropertyNamedBaseObject {
		private StringKeyPropertyObject owner;
		private string key;
		public StringKeyPropertyObject(Session session) : base(session) { }
		public override void AfterConstruction() {
			base.AfterConstruction();
			key = "StringKey-" + DistributedIdGeneratorHelper.Generate(this.Session.DataLayer, this.GetType().FullName, string.Empty);
		}
		[Key(false)]
		[VisibleInListView(true)]
		[RuleUniqueValue("{514F2343-C0F0-4512-9C33-49EBA48E7F30}", DefaultContexts.Save)]
        [ModelDefault("AllowEdit", "false")]
		public string Key {
			get { return key; }
			set { SetPropertyValue("Key", ref key, value); }
		}
		[Aggregated, Association("StringKeyPropertyObject-StringKeyPropertyObject")]
		public XPCollection<StringKeyPropertyObject> Objects {
			get { return GetCollection<StringKeyPropertyObject>("Objects"); }
		}
		[Association("StringKeyPropertyObject-StringKeyPropertyObject")]
		[VisibleInListView(false)]
		public StringKeyPropertyObject Owner {
			get { return owner; }
			set { SetPropertyValue("Owner", ref owner, value); }
		}
	}
}
