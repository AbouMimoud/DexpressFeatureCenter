using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using DevExpress.Persistent.Base.General;
using DevExpress.Persistent.Base;
using System.ComponentModel;
using DevExpress.ExpressApp.Demos;

namespace FeatureCenter.Module.Win.Printing {
	[NavigationItem(Captions.PrintingGroup), System.ComponentModel.DisplayName(Captions.Printing_TreeList)]
	[CreatableItem(false)]
	[DefaultProperty("Caption")]
	[Hint(Hints.TreeListDemoObjectHint)]
	public class TreeListDemoObject : TreeListBaseObject {
		public TreeListDemoObject(Session session) : base(session) { }
	}
}
