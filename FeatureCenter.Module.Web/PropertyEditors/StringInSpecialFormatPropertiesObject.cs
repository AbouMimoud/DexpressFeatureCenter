using System;
using System.Collections.Generic;
using System.Text;
using FeatureCenter.Module.PropertyEditors;
using DevExpress.Xpo;
using FeatureCenter.Module.Navigation;
using DevExpress.ExpressApp.Demos;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp;

namespace FeatureCenter.Module.Web.PropertyEditors {
	[NavigationItem(Captions.PropertyEditorsGroup), DefaultListViewOptions(true, NewItemRowPosition.Top)]
	[Hint(Hints.StringInSpecialFormatPropertiesHint)]
	[ImageName("PropertyEditors.Demo_String_InSpecialFormat_Properties")]
	[System.ComponentModel.DisplayName(Captions.PropertyEditors_StringInSpecialFormatProperties)]
	public class WebStringInSpecialFormatPropertiesObject : StringInSpecialFormatProperties {
		public WebStringInSpecialFormatPropertiesObject(Session session) : base(session) { }
	}
}
