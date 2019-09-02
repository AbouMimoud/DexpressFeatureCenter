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

	public enum TextOnlyEnum { Minor, Moderate, Severe }
	public enum TextAndImageEnum {
		[ImageName("State_Priority_Low")]
		Low,
		[ImageName("State_Priority_Normal")]
		Normal,
		[ImageName("State_Priority_High")]
		High 
	}

	[NavigationItem(Captions.PropertyEditorsGroup), DefaultListViewOptions(true, NewItemRowPosition.Top)]
	[Hint(Hints.EnumPropertiesHint)]
	[ImageName("PropertyEditors.Demo_Enum_Properties")]
    public class EnumProperties : NamedBaseObject {
		private TextOnlyEnum textOnlyEnumProperty;
		private TextAndImageEnum textAndImageEnumProperty;

		public EnumProperties(Session session) : base(session) { }

		public TextOnlyEnum TextOnlyEnumProperty {
			get { return textOnlyEnumProperty; }
			set { SetPropertyValue("TextOnlyEnumProperty", ref textOnlyEnumProperty, value); }
		}
		public TextAndImageEnum TextAndImageEnumProperty {
			get { return textAndImageEnumProperty; }
			set { SetPropertyValue("TextAndImageEnumProperty", ref textAndImageEnumProperty, value); }
		}
	}
}
