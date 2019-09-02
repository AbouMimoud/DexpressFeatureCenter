using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.Xpo.DB.Helpers;

using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using System.Drawing;
using DevExpress.Persistent.Validation;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Demos;

namespace FeatureCenter.Module.PropertyEditors {
	[NavigationItem(Captions.PropertyEditorsGroup), DefaultListViewOptions(true, NewItemRowPosition.Top)]
	[Hint(Hints.DateTimePropertiesHint)]
	[ImageName("PropertyEditors.Demo_DateTime_Properties")]
    public class DateTimeProperties : NamedBaseObject {
		private DateTime dateTimeProperty;
		private DateTime? dateTimeNullableProperty;
		private TimeSpan timeSpanProperty;
		/*
		 * TODO
		 * 
		 * private DateTime timeProperty;
		private DateTime? timeNullableProperty;
		private TimeSpan? timeSpanNullableProperty;
		*/

		public DateTimeProperties(Session session) : base(session) { }

		public DateTime DateTimeProperty {
			get { return dateTimeProperty; }
			set { SetPropertyValue("DateTimeProperty", ref dateTimeProperty, value); }
		}
		public DateTime? DateTimeNullableProperty {
			get { return dateTimeNullableProperty; }
			set { SetPropertyValue("DateTimeNullableProperty", ref dateTimeNullableProperty, value); }
		}
		public TimeSpan TimeSpanProperty {
			get { return timeSpanProperty; }
			set { SetPropertyValue("TimeSpanProperty", ref timeSpanProperty, value); }
		}

		/*
		 * TODO
		 * 
		 * public DateTime? TimeNullableProperty {
			get { return timeNullableProperty; }
			set { SetPropertyValue("TimeNullableProperty", ref timeNullableProperty, value); }
		}
		public DateTime TimeProperty {
			get { return timeProperty; }
			set { SetPropertyValue("TimeProperty", ref timeProperty, value); }
		}
		public TimeSpan? TimeSpanNullableProperty {
			get { return timeSpanNullableProperty; }
			set { SetPropertyValue("TimeSpanNullableProperty", ref timeSpanNullableProperty, value); }
		}*/
	}
}
