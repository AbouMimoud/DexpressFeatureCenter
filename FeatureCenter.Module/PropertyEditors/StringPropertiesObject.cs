using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Demos;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;

namespace FeatureCenter.Module.PropertyEditors {

	[NavigationItem(Captions.PropertyEditorsGroup), DefaultListViewOptions(true, NewItemRowPosition.Top)]
	[Hint(Hints.StringPropertiesHint)]
	[ImageName("PropertyEditors.Demo_String_Properties")]
	public class StringProperties : NamedBaseObject {
		private string defaulSizeStringProperty;
		private XPDelayedProperty compressedUnlimitedStringProperty = new XPDelayedProperty();
		private string unlimitedSizeStringProperty;
		private string shortSizeStringProperty;
		private string stringWithPredefinedValuesProperty;
		public StringProperties(Session session) : base(session) { }

		public string DefaultSizeStringProperty {
			get { return defaulSizeStringProperty; }
			set { SetPropertyValue("DefaultSizeStringProperty", ref defaulSizeStringProperty, value); }
		}
		[Size(15)]
		public string ShortSizeStringProperty {
			get {
				return shortSizeStringProperty;
			}
			set { SetPropertyValue("ShortSizeStringProperty", ref shortSizeStringProperty, value); }
		}
		[Size(SizeAttribute.Unlimited), VisibleInListView(true)]
		public string UnlimitedSizeStringProperty {
			get {
				return unlimitedSizeStringProperty;
			}
			set { SetPropertyValue("UnlimitedSizeStringProperty", ref unlimitedSizeStringProperty, value); }
		}
		[Delayed("compressedUnlimitedStringProperty"), ValueConverter(typeof(StringCompressionConverter))]
		public string CompressedUnlimitedStringProperty {
			get { return (string)compressedUnlimitedStringProperty.Value; }
			set { 
				compressedUnlimitedStringProperty.Value = value;
				OnChanged("CompressedUnlimitedStringProperty");
			}
		}
        [ModelDefault("PredefinedValues", "Predefined Value 1;Predefined Value 2;Predefined Value 3;Predefined Value 4;Predefined Value 5")]
		public string StringWithPredefinedValuesProperty {
			get { return stringWithPredefinedValuesProperty; }
			set { stringWithPredefinedValuesProperty = value; }
		}
	}
}
