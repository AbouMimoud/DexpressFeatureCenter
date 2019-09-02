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
using System.Collections.ObjectModel;
using System.Collections;
using DevExpress.ExpressApp.Demos;
using System.ComponentModel;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp.SystemModule;
using System.Drawing;

namespace FeatureCenter.Module.Layout {
    [AutoCreatableObject]
	[NavigationItem(Captions.LayoutGroup)]
	[ImageName("Layout.Demo_Layout_DefaultFocusedItem")]
	[Hint(Hints.LayoutDemoDefaultFocusedItemHint)]
	public class DefaultFocusedItem : NamedBaseObject {
		private string firstItem;
		private string focusedItem;
		public DefaultFocusedItem(Session session) : base(session) { }
		public string FirstItem {
			get { return firstItem; }
			set {
				SetPropertyValue("FirstItem", ref firstItem, value);
			}
		}		
		public string FocusedItem {
			get { return focusedItem; }
			set {
				SetPropertyValue("FocusedItem", ref focusedItem, value);
			}
		}		        
	}
}
