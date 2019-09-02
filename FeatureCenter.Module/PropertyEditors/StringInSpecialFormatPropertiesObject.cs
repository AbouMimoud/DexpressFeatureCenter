using System;
using DevExpress.Xpo;
using DevExpress.Persistent.Base;
using System.Collections.Generic;

namespace FeatureCenter.Module.PropertyEditors {
	[NavigationItem(false)]
	[ImageName("PropertyEditors.Demo_String_InSpecialFormat_Properties")]
	public class StringInSpecialFormatProperties : NamedBaseObject {
        private string htmlStringProperty;

		public StringInSpecialFormatProperties(Session session) : base(session) { }

		[Size(SizeAttribute.Unlimited)]
        [VisibleInListView(true)]
		public string HtmlStringProperty {
			get { return htmlStringProperty; }
			set { SetPropertyValue("HtmlStringProperty", ref htmlStringProperty, value); }
		}
	}
}
