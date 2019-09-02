using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.Xpo;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Demos;
using DevExpress.ExpressApp;

namespace FeatureCenter.Module.ConditionalAppearance {
	[ImageName("ConditionalAppearance.ConditionalAppearance")]
	[NavigationItem(Captions.ConditionalAppearanceGroup)]
	[System.ComponentModel.DisplayName(Captions.ConditionalAppearance_ActionControl)]
    [Appearance("DeleteDisabled", AppearanceItemType.Action, "DisableDeleteAction = 'True'", TargetItems = "Delete", Enabled = false)]
    [Hint(Hints.ConditionalAppearance_ActionControlObjectHint, ViewType.Any)]
	public class ActionAppearanceControlObject : NamedBaseObject {
		private bool disableDeleteAction;

		public ActionAppearanceControlObject(Session session)
			: base(session) {			
		}
		public ActionAppearanceControlObject(Session session, string name)
			: base(session, name) {			
		}

		[ImmediatePostData]
		public bool DisableDeleteAction {
			get { return disableDeleteAction; }
			set { SetPropertyValue("DisableDeleteAction", ref disableDeleteAction, value); }
		}
	}
}
