using DevExpress.ExpressApp;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.Demos;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace FeatureCenter.Module.ConditionalAppearance {
	[ImageName("ConditionalAppearance.ConditionalAppearance")]
	[NavigationItem(Captions.ConditionalAppearanceGroup)]
	[System.ComponentModel.DisplayName(Captions.ConditionalAppearance_HidingShowingEditors)]
    [Appearance("HideShowEditorsObject.SimpleProperty ID", TargetItems = "SimpleProperty", Criteria = "HideSimpleProperty = 'True'", Visibility = ViewItemVisibility.Hide, Context = "DetailView")]
    [Appearance("HideShowEditorsObject.LookupProperty ID", TargetItems = "LookupProperty", Criteria = "HideLookupProperty = 'True'", Visibility = ViewItemVisibility.ShowEmptySpace, Context = "DetailView")]
    [Appearance("HideShowEditorsObject.AggregatedProperty ID", TargetItems = "AggregatedProperty", Criteria = "HideAggregatedProperty = 'True'", Visibility = ViewItemVisibility.Hide, Context = "DetailView")]    
    [Hint(Hints.ConditionalAppearance_HideShowEditorsObjectHint, ViewType.Any)]
	public class ConditionalAppearanceHideShowEditorsObject : NamedBaseObject {
		public ConditionalAppearanceHideShowEditorsObject(Session session) : base(session) { }
		public ConditionalAppearanceHideShowEditorsObject(Session session, string name)
			: base(session, name) {
			if(!session.IsObjectsLoading)
				Name = name;
		}
		public override void AfterConstruction() {
			base.AfterConstruction();
			AggregatedProperty = new ConditionalAppearanceHideShowEditorsAggregatedObject(Session);
		}
		private bool _HideSimpleProperty;
		[ImmediatePostData]
		[VisibleInListView(false)]
		[VisibleInLookupListView(false)]
		public bool HideSimpleProperty {
			get { return _HideSimpleProperty; }
			set { SetPropertyValue("HideSimpleProperty", ref _HideSimpleProperty, value); }
		}
		private string _SimpleProperty;
		[VisibleInListView(false)]
		[VisibleInLookupListView(false)]
		public string SimpleProperty {
			get { return _SimpleProperty; }
			set { SetPropertyValue("SimpleProperty", ref _SimpleProperty, value); }
		}
		private bool _HideLookupProperty;
		[ImmediatePostData]
		[VisibleInListView(false)]
		[VisibleInLookupListView(false)]
		public bool HideLookupProperty {
			get { return _HideLookupProperty; }
			set { SetPropertyValue("HideLookupProperty", ref _HideLookupProperty, value); }
		}
		private ConditionalAppearanceHideShowEditorsLookupObject _LookupProperty;
		[VisibleInListView(false)]
		[VisibleInLookupListView(false)]
		public ConditionalAppearanceHideShowEditorsLookupObject LookupProperty {
			get { return _LookupProperty; }
			set { SetPropertyValue("LookupProperty", ref _LookupProperty, value); }
		}
		private bool _HideAggregatedProperty;
		[ImmediatePostData]
		[VisibleInListView(false)]
		[VisibleInLookupListView(false)]
		public bool HideAggregatedProperty {
			get { return _HideAggregatedProperty; }
			set { SetPropertyValue("HideAggregatedProperty", ref _HideAggregatedProperty, value); }
		}
		private ConditionalAppearanceHideShowEditorsAggregatedObject _AggregatedProperty;
		[ExpandObjectMembers(ExpandObjectMembers.Never)]
		[VisibleInListView(false)]
		[VisibleInLookupListView(false)]
        [ModelDefault("PropertyEditorType", "DevExpress.ExpressApp.Editors.DetailPropertyEditor")]
		public ConditionalAppearanceHideShowEditorsAggregatedObject AggregatedProperty {
			get { return _AggregatedProperty; }
			set { SetPropertyValue("AggregatedProperty", ref _AggregatedProperty, value); }
		}		
	}
    [Appearance("HideShowEditorsAggregatedObject.AllProperties ID", TargetItems = "*;HideProperties", Criteria = "HideProperties = 'True'", Visibility = ViewItemVisibility.Hide, Context = "DetailView")]
	public class ConditionalAppearanceHideShowEditorsAggregatedObject : NamedBaseObject {
		public ConditionalAppearanceHideShowEditorsAggregatedObject(Session session) : base(session) { }
		public ConditionalAppearanceHideShowEditorsAggregatedObject(Session session, string name)
			: base(session, name) {
			if(!session.IsObjectsLoading)
				Name = name;
		}
		private string _Description;
		public string Description {
			get { return _Description; }
			set { SetPropertyValue("Description", ref _Description, value); }
		}
		private bool _HideProperties;
		[ImmediatePostData]
		public bool HideProperties {
			get { return _HideProperties; }
			set { SetPropertyValue("HideProperties", ref _HideProperties, value); }
		}
	}
	public class ConditionalAppearanceHideShowEditorsLookupObject : NamedBaseObject {
		public ConditionalAppearanceHideShowEditorsLookupObject(Session session) : base(session) { }
		public ConditionalAppearanceHideShowEditorsLookupObject(Session session, string name)
			: this(session) {
			if(!session.IsObjectsLoading)
				Name = name;
		}
	}
	public class ConditionalAppearanceHideShowEditorsCollectionElementObject : NamedBaseObject {
		public ConditionalAppearanceHideShowEditorsCollectionElementObject(Session session) : base(session) { }
		public ConditionalAppearanceHideShowEditorsCollectionElementObject(Session session, string name)
			: this(session) {
			if(!session.IsObjectsLoading)
				Name = name;
		}
	}
}
