using System;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using DevExpress.ExpressApp.Demos;
using DevExpress.Persistent.Base;

namespace FeatureCenter.Module.Skins {

    [Hint(Hints.SkinDemoObjectHint)]
    public class SkinDemoObject : BaseObject {
		private string name;
		
		public SkinDemoObject(Session session) : base(session) { }
		
		public string Name {
			get { return name; }
			set { SetPropertyValue("Name", ref name, value); }
		}
	}
}
