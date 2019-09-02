using DevExpress.ExpressApp;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.Demos;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace FeatureCenter.Module.ConditionalAppearance {
	[ImageName("ConditionalAppearance.ConditionalAppearance")]
	[NavigationItem(Captions.ConditionalAppearanceGroup)]
	[System.ComponentModel.DisplayName(Captions.ConditionalAppearance_DisablingEnablingEditors)]
    [Appearance("SimpleProperty ID", TargetItems = "SimpleProperty", Criteria = "DisableSimpleProperty = 'True'", Enabled = false)]
    [Appearance("LookupProperty ID", TargetItems = "LookupProperty", Criteria = "DisableLookupProperty = 'True'", Enabled = false)]
    [Appearance("AggregatedProperty ID", TargetItems = "AggregatedProperty", Criteria = "DisableAggregatedProperty = 'True'", Enabled = false)]
    [Appearance("CollectionProperty1 ID", TargetItems = "CollectionProperty1", Criteria = "DisableCollectionProperty1 = 'True'", Enabled = false)]
    [Appearance("CollectionProperty2 ID", TargetItems = "CollectionProperty2", Criteria = "DisableCollectionProperty2 = 'True'", Enabled = false)]
    [Hint(Hints.ConditionalAppearance_DisableEnableEditorsObjectHint, ViewType.Any)]
	public class ConditionalAppearanceDisableEnableEditorsObject : NamedBaseObject {
		public ConditionalAppearanceDisableEnableEditorsObject(Session session) : base(session) { }
		public ConditionalAppearanceDisableEnableEditorsObject(Session session, string name)
			: base(session, name) {
			if(!session.IsObjectsLoading)
				Name = name;
		}
		public override void AfterConstruction() {
			base.AfterConstruction();
			AggregatedProperty = new ConditionalAppearanceDisableEnableEditorsAggregatedObject(Session);
		}
		private bool _DisableSimpleProperty;
		[ImmediatePostData]
		public bool DisableSimpleProperty {
			get { return _DisableSimpleProperty; }
			set { SetPropertyValue("DisableSimpleProperty", ref _DisableSimpleProperty, value); }
		}
		private string _SimpleProperty;
		public string SimpleProperty {
			get { return _SimpleProperty; }
			set { SetPropertyValue("SimpleProperty", ref _SimpleProperty, value); }
		}
		private bool _DisableLookupProperty;
		[ImmediatePostData]
		public bool DisableLookupProperty {
			get { return _DisableLookupProperty; }
			set { SetPropertyValue("DisableLookupProperty", ref _DisableLookupProperty, value); }
		}
		private ConditionalAppearanceDisableEnableEditorsLookupObject _LookupProperty;
		public ConditionalAppearanceDisableEnableEditorsLookupObject LookupProperty {
			get { return _LookupProperty; }
			set { SetPropertyValue("LookupProperty", ref _LookupProperty, value); }
		}
		private bool _DisableAggregatedProperty;
		[ImmediatePostData]
		[VisibleInListView(false)]
		[VisibleInLookupListView(false)]
		public bool DisableAggregatedProperty {
			get { return _DisableAggregatedProperty; }
			set { SetPropertyValue("DisableAggregatedProperty", ref _DisableAggregatedProperty, value); }
		}
		private ConditionalAppearanceDisableEnableEditorsAggregatedObject _AggregatedProperty;
		[ExpandObjectMembers(ExpandObjectMembers.Never)]
		[VisibleInListView(false)]
		[VisibleInLookupListView(false)]
        [ModelDefault("PropertyEditorType", "DevExpress.ExpressApp.Editors.DetailPropertyEditor")]
		public ConditionalAppearanceDisableEnableEditorsAggregatedObject AggregatedProperty {
			get { return _AggregatedProperty; }
			set { SetPropertyValue("AggregatedProperty", ref _AggregatedProperty, value); }
		}
		private bool _DisableCollectionProperty1;
		[ImmediatePostData]
		[VisibleInListView(false)]
		[VisibleInLookupListView(false)]
		public bool DisableCollectionProperty1 {
			get { return _DisableCollectionProperty1; }
			set { SetPropertyValue("DisableCollectionProperty1", ref _DisableCollectionProperty1, value); }
		}
		private XPCollection<ConditionalAppearanceDisableEnableEditorsCollectionElementObject> _CollectionProperty1;
		public XPCollection<ConditionalAppearanceDisableEnableEditorsCollectionElementObject> CollectionProperty1 {
			get {
				if(_CollectionProperty1 == null) {
					_CollectionProperty1 = new XPCollection<ConditionalAppearanceDisableEnableEditorsCollectionElementObject>(Session);
				}
				return _CollectionProperty1;
			}
		}
		private bool _DisableCollectionProperty2;
		[ImmediatePostData]
		[VisibleInListView(false)]
		[VisibleInLookupListView(false)]
		public bool DisableCollectionProperty2 {
			get { return _DisableCollectionProperty2; }
			set { SetPropertyValue("DisableCollectionProperty2", ref _DisableCollectionProperty2, value); }
		}
		private XPCollection<ConditionalAppearanceDisableEnableEditorsCollectionElementObject> _CollectionProperty2;
		public XPCollection<ConditionalAppearanceDisableEnableEditorsCollectionElementObject> CollectionProperty2 {
			get {
				if(_CollectionProperty2 == null) {
					_CollectionProperty2 = new XPCollection<ConditionalAppearanceDisableEnableEditorsCollectionElementObject>(Session);
				}
				return _CollectionProperty2;
			}
		}
        [Appearance("DisableEnableEditorsObject.PropertyByStaticMethod ID", TargetItems = "PropertyDisabledByStaticMethod", Enabled = false)]
		private static bool DisablePropertyByStaticMethod() {
			return true;
		}
		private string _PropertyDisabledByStaticMethod;
		public string PropertyDisabledByStaticMethod {
			get { return _PropertyDisabledByStaticMethod; }
			set { SetPropertyValue("PropertyDisabledByStaticMethod", ref _PropertyDisabledByStaticMethod, value); }
		}
        [Appearance("DisableEnableEditorsObject.PropertyByInstanceMethod ID", TargetItems = "PropertyDisabledByInstanceMethod", Enabled = false)]
		private bool DisablePropertyByInstanceMethod() {
			return PropertyDisabledByInstanceMethod == "You cannot edit me";
		}
		private string _PropertyDisabledByInstanceMethod;
		[ImmediatePostData]
		public string PropertyDisabledByInstanceMethod {
			get { return _PropertyDisabledByInstanceMethod; }
			set { SetPropertyValue("PropertyDisabledByInstanceMethod", ref _PropertyDisabledByInstanceMethod, value); }
		}
	}
    [Appearance("DisableEnableEditorsAggregatedObject ID", TargetItems = "*;DisableProperties", Criteria = "DisableProperties = 'True'", Enabled = false, Context = "DetailView")]
	public class ConditionalAppearanceDisableEnableEditorsAggregatedObject : NamedBaseObject {
		public ConditionalAppearanceDisableEnableEditorsAggregatedObject(Session session) : base(session) { }
		public ConditionalAppearanceDisableEnableEditorsAggregatedObject(Session session, string name)
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
	public class ConditionalAppearanceDisableEnableEditorsLookupObject : NamedBaseObject {
		public ConditionalAppearanceDisableEnableEditorsLookupObject(Session session) : base(session) { }
		public ConditionalAppearanceDisableEnableEditorsLookupObject(Session session, string name)
			: base(session, name) {
			if(!session.IsObjectsLoading)
				Name = name;
		}
	}
	public class ConditionalAppearanceDisableEnableEditorsCollectionElementObject : NamedBaseObject {
		public ConditionalAppearanceDisableEnableEditorsCollectionElementObject(Session session) : base(session) { }
		public ConditionalAppearanceDisableEnableEditorsCollectionElementObject(Session session, string name)
			: base(session, name) {
			if(!session.IsObjectsLoading)
				Name = name;
		}
	}
}
