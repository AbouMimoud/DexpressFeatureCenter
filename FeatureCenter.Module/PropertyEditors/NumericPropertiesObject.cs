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
	[NavigationItem(Captions.PropertyEditorsGroup), DefaultListViewOptions(true, NewItemRowPosition.Top)]
	[Hint(Hints.NumericPropertiesHint)]
	[ImageName("PropertyEditors.Demo_Numeric_Properties")]
    public class NumericProperties : NamedBaseObject {
		private long longProperty;
		private int integerProperty;
		// TODO: not supported private int? integerNullableProperty;
		private decimal decimalProperty;
		// TODO: not supported private decimal? decimalNullableProperty;
		private byte byteProperty;
		private float singleProperty;
		private double doubleProperty;

		public NumericProperties(Session session) : base(session) { }

		public double DoubleProperty {
			get { return doubleProperty; }
			set { SetPropertyValue("DoubleProperty", ref doubleProperty, value); }
		}
		public float SingleProperty {
			get { return singleProperty; }
			set { SetPropertyValue("SingleProperty", ref singleProperty, value); }
		}
		public long LongProperty {
			get { return longProperty; }
			set { SetPropertyValue("LongProperty", ref longProperty, value); }
		}
		public int IntegerProperty {
			get { return integerProperty; }
			set { SetPropertyValue("IntegerProperty", ref integerProperty, value); }
		}
		/* TODO: not supported public int? IntegerNullableProperty {
			get { return integerNullableProperty; }
			set { SetPropertyValue("IntegerNullableProperty", ref integerNullableProperty, value); }
		}*/
		public decimal DecimalProperty {
			get { return decimalProperty; }
			set { SetPropertyValue("DecimalProperty", ref decimalProperty, value); }
		}
		/* TODO: not supported public decimal? DecimalNullableProperty {
			get { return decimalNullableProperty; }
			set { SetPropertyValue("DecimalNullableProperty", ref decimalNullableProperty, value); }
		}*/
		public byte ByteProperty {
			get { return byteProperty; }
			set { SetPropertyValue("ByteProperty", ref byteProperty, value); }
		}
	}
}
