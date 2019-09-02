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

namespace FeatureCenter.Module.PropertyEditors {
	[NavigationItem(Captions.PropertyEditorsGroup), DefaultListViewOptions(true, NewItemRowPosition.Top), System.ComponentModel.DisplayName(Captions.PropertyEditors_BooleanProperties)]
	[Hint(Hints.BooleanPropertiesDescription)]
	[ImageName("PropertyEditors.Demo_Boolean_Properties")]
    public class BooleanProperties : NamedBaseObject {
		private bool booleanProperty;
		private bool booleanWithCaptions;
		private bool booleanWithImages;

		public BooleanProperties(Session session) : base(session) { }

		public bool BooleanProperty {
			get { return booleanProperty; }
			set { SetPropertyValue("BooleanProperty", ref booleanProperty, value); }
		}
		[CaptionsForBoolValues("True Caption", "False Caption")]
		public bool BooleanWithCaptions {
			get { return booleanWithCaptions; }
			set { SetPropertyValue("BooleanWithCaptions", ref booleanWithCaptions, value); }
		}
		[ImagesForBoolValues("BooleanPropertiesObject_BooleanWithImages_True", "BooleanPropertiesObject_BooleanWithImages_False")]
		[CaptionsForBoolValues("True Caption", "False Caption")]
		public bool BooleanWithImages {
			get { return booleanWithImages; }
			set { SetPropertyValue("BooleanWithImages", ref booleanWithImages, value); }
		}
	}
}
