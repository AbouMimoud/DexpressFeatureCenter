using System;
using DevExpress.Xpo;
using DevExpress.Persistent.BaseImpl;

namespace FeatureCenter.Module {
	public abstract class NamedBaseObject : BaseObject {
		private string name;
		public NamedBaseObject(Session session) : base(session) { }
        public NamedBaseObject(Session session, string name)
            : this(session) {
            this.name = name;
        }
		public string Name {
			get { return name; }
			set { SetPropertyValue("Name", ref name, value); }
		}
	}
}
