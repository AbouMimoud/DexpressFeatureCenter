using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using DevExpress.Persistent.Base.General;
using DevExpress.ExpressApp.Demos;

namespace FeatureCenter.Module.Win.Printing {
	[NavigationItem(Captions.PrintingGroup), System.ComponentModel.DisplayName(Captions.Printing_Scheduler)]
	[CreatableItem(false)]
	[Hint(Hints.EventDemoObjectHint)]
	public class EventDemoObject : EventBaseObject {
		public EventDemoObject(Session session) : base(session) { }
	}
}
