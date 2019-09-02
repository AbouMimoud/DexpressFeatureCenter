using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.Xpo.DB.Helpers;

using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using System.ComponentModel;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Demos;
using DevExpress.ExpressApp.Editors;

namespace FeatureCenter.Module.PropertyEditors {

	public class ReferencedObject : NamedBaseObject {
		private string description;
		public ReferencedObject(Session session) : base(session) { }
		public ReferencedObject(Session session, string name) : base(session) {
			this.Name = name;
		}
		public string Description {
			get { return description; }
			set { SetPropertyValue("Description", ref description, value); }
		}
	}

	[DefaultProperty("Name")]
	public class EmbeddedDetailViewObject : BaseObject {
		private string name;
		private string notes;
		public EmbeddedDetailViewObject(Session session) : base(session) { }
		[System.ComponentModel.DisplayName("EmbeddedDetailViewObject.Name")]
		public string Name {
			get { return name; }
			set { SetPropertyValue("Name", ref name, value); }
		}
		[System.ComponentModel.DisplayName("EmbeddedDetailViewObject.Notes")]
		[Size(SizeAttribute.Unlimited)]
		public string Notes {
			get { return notes; }
			set { SetPropertyValue("Notes", ref notes, value); }
		}
	}

	[DefaultProperty("Name")]
	public class PopupDetailViewObject : BaseObject {
		private string name;
		private string notes;
		public PopupDetailViewObject(Session session) : base(session) { }
		[System.ComponentModel.DisplayName("PopupDetailViewObject.Name")]
		public string Name {
			get { return name; }
			set { SetPropertyValue("Name", ref name, value); }
		}
		[System.ComponentModel.DisplayName("PopupDetailViewObject.Notes")]
		[Size(SizeAttribute.Unlimited)]
		public string Notes {
			get { return notes; }
			set { SetPropertyValue("Notes", ref notes, value); }
		}
	}

	[DefaultProperty("Name")]
	public class ExpandPropertiesObject : BaseObject {
		private string name;
		private string notes;
		public ExpandPropertiesObject(Session session) : base(session) { }
		[System.ComponentModel.DisplayName("ExpandPropertiesObject.Name")]
		public string Name {
			get { return name; }
			set { SetPropertyValue("Name", ref name, value); }
		}
		[System.ComponentModel.DisplayName("ExpandPropertiesObject.Notes")]
		[Size(SizeAttribute.Unlimited)]
		public string Notes {
			get { return notes; }
			set { SetPropertyValue("Notes", ref notes, value); }
		}
	}

	[NavigationItem(Captions.PropertyEditorsGroup), DefaultListViewOptions(true, NewItemRowPosition.Top)]
	[Hint(Hints.ReferencePropertiesHint)]
	[ImageName("PropertyEditors.Demo_Reference_Properties")]
    public class ReferenceProperties : NamedBaseObject {
		private ReferencedObject lookupReferencedObject;
        private ReferencedObject gridlookupReferencedObject;
        private ExpandPropertiesObject expandPropertiesObject;
		private EmbeddedDetailViewObject embeddedDetailViewObject;
		private PopupDetailViewObject popupDetailViewObject;

		public override void AfterConstruction() {
			base.AfterConstruction();
			embeddedDetailViewObject = new EmbeddedDetailViewObject(Session);
			embeddedDetailViewObject.Name = "Embedded Object";
			embeddedDetailViewObject.Notes = "Embedded Object's Notes";
			popupDetailViewObject = new PopupDetailViewObject(Session);
			popupDetailViewObject.Name = "Popup Detail View Object";
			popupDetailViewObject.Notes = "Popup Detail View Object's Notes";
			expandPropertiesObject = new ExpandPropertiesObject(Session);
			expandPropertiesObject.Name = "Expand Properties Object";
			expandPropertiesObject.Notes = "Expand Properties Object's Notes";
		}

		public ReferenceProperties(Session session) : base(session) { }

		public ReferencedObject LookupReferencedObject {
			get { return lookupReferencedObject; }
			set { SetPropertyValue("LookupReferencedObject", ref lookupReferencedObject, value); }
		}
        public ReferencedObject GridLookupReferencedObject {
            get { return gridlookupReferencedObject; }
            set { SetPropertyValue("GridLookupReferencedObject", ref gridlookupReferencedObject, value); }
        }        
        [Aggregated, ExpandObjectMembers(ExpandObjectMembers.Always)]
		public ExpandPropertiesObject ExpandPropertiesObject {
			get { return expandPropertiesObject; }
			set { SetPropertyValue("ExpandPropertiesObject", ref expandPropertiesObject, value); }
		}
        [Aggregated, EditorAlias(EditorAliases.DetailPropertyEditor), ExpandObjectMembers(ExpandObjectMembers.Never)]
		public EmbeddedDetailViewObject EmbeddedDetailViewObject {
			get { return embeddedDetailViewObject; }
			set { SetPropertyValue("EmbeddedDetailViewObject", ref embeddedDetailViewObject, value); }
		}
		[Aggregated, ExpandObjectMembers(ExpandObjectMembers.Never)]
		public PopupDetailViewObject PopupDetailViewObject {
			get { return popupDetailViewObject; }
			set { SetPropertyValue("PopupDetailViewObject", ref popupDetailViewObject, value); }
		}
	}
}
