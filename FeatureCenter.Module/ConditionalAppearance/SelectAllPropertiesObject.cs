using System;
using DevExpress.Xpo;
using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.Demos;

namespace FeatureCenter.Module.ConditionalAppearance {
	[ImageName("ConditionalAppearance.ConditionalAppearance")]
	[NavigationItem(Captions.ConditionalAppearanceGroup)]
	[System.ComponentModel.DisplayName(Captions.ConditionalAppearance_UsingWildcard)]
	//[Hint(Hints.ConditionalAppearance_SelectAllPropertiesObjectHint, ViewType.Any)]
	[Appearance("SelectAllPropertiesObject.AllProperties - declared in code ID", TargetItems = "*;DisableProperties", Criteria = "DisableProperties = 'True'", Enabled = false)]
    [Hint(Hints.ConditionalAppearance_SelectAllPropertiesObjectHint, ViewType.Any)]
	public class ConditionalAppearanceSelectAllPropertiesObject : NamedBaseObject {
		public ConditionalAppearanceSelectAllPropertiesObject(Session session) : base(session) { }
		public ConditionalAppearanceSelectAllPropertiesObject(Session session, string name)
			: base(session, name) {
			if(!session.IsObjectsLoading)
				Name = name;
		}
		private string _Description;
		public string Description {
			get { return _Description; }
			set { SetPropertyValue("Description", ref _Description, value); }
		}
		private bool _DisableProperties;
		[ImmediatePostData]
		public bool DisableProperties {
			get { return _DisableProperties; }
			set { SetPropertyValue("DisableProperties", ref _DisableProperties, value); }
		}
	}
}
