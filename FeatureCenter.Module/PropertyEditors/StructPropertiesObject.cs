using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.Xpo.DB.Helpers;

using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Demos;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;

namespace FeatureCenter.Module.PropertyEditors {

	public struct DetailDescription {
		private int id;
		private string name;
		[Persistent]
		public int Id {
			get { return id; }
			set { id = value; }
		}
		[Persistent]
		public string DetailName {
			get { return name; }
			set { name = value; }
		}
		public override string ToString() {
			return "Id: '" + Id + "', Name: '" + DetailName + "'";
		}
	}

	[NavigationItem(Captions.PropertyEditorsGroup), DefaultListViewOptions(true, NewItemRowPosition.Top)]
	[Hint(Hints.StructPropertiesHint, ViewType.Any)]
	[ImageName("PropertyEditors.Demo_Struct_Properties")]
    public class StructProperties : NamedBaseObject {
		public override void AfterConstruction() {
			base.AfterConstruction();
			Details.Id = DateTime.Now.Millisecond % 100;
			Details.DetailName = Details.Id.ToString() + " Generated Name";
		}
		public StructProperties(Session session) : base(session) { }
		[Persistent]
		public DetailDescription Details;
	}


}
