using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.Demos;

namespace FeatureCenter.Module.Win.Printing {
	[NavigationItem(Captions.PrintingGroup), System.ComponentModel.DisplayName(Captions.Printing_Grid)]
	[CreatableItem(false)]
	[Hint(Hints.GridDemoObjectHint)]
	public class GridDemoObject : GridBaseObject {
		public GridDemoObject(Session session) : base(session) { }
	}
}
