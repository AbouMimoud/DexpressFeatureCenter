using System;
using DevExpress.ExpressApp.Demos;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;

namespace FeatureCenter.Module.Localization {
	public enum SimpleEnumeration { First, Second, Third, Fourth, Fifth }

	[Hint(Hints.LocalizationHint)]
	[System.ComponentModel.DefaultProperty("EnumerationProperty")]
	[ImageName("BO_Localization")]
	public class LocalizationObject : BaseObject {
		private decimal decimalProperty;
		private decimal currencyProperty;
		private SimpleEnumeration enumerationProperty;
		private DateTime dateTimeProperty;

		public LocalizationObject(Session session) : base(session) { }

        [ModelDefault("DisplayFormat", "{0:N}")]
        [ModelDefault("EditMask", "N")] 
		public decimal DecimalProperty {
			get { return decimalProperty; }
			set { SetPropertyValue("DecimalProperty", ref decimalProperty, value); }
		}
        [ModelDefault("DisplayFormat", "{0:C}")]
        [ModelDefault("EditMask", "C")] 
		public decimal CurrencyProperty {
			get { return currencyProperty; }
			set { SetPropertyValue("CurrencyProperty", ref currencyProperty, value); }
		}
		public SimpleEnumeration EnumerationProperty {
			get { return enumerationProperty; }
			set { SetPropertyValue("EnumerationProperty", ref enumerationProperty, value); }
		}
        [ModelDefault("DisplayFormat", "{0:D}")]
        [ModelDefault("EditMask", "D")] 
		public DateTime DateTimeProperty {
			get { return dateTimeProperty; }
			set { SetPropertyValue("DateTimeProperty", ref dateTimeProperty, value); }
		}
	}
}
