using System.ComponentModel;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Demos;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace FeatureCenter.Module.PropertyEditors {
    public class AssociatedObject : NamedBaseObject {
        private CollectionProperties collectionProperties;
        public AssociatedObject(Session session) : base(session) { }
        [Association("CollectionProperties-AssociatedObject"), Browsable(false)]
        public CollectionProperties CollectionProperties {
            get { return collectionProperties; }
			set { SetPropertyValue("CollectionProperties", ref collectionProperties, value); }
        }
    }

    public class NoAssociationObject : NamedBaseObject {
		public NoAssociationObject(Session session) : base(session) { }
    }

    public class AggregatedObject : NamedBaseObject {
        private CollectionProperties collectionProperties;
        public AggregatedObject(Session session) : base(session) { }
        [Association("CollectionProperties-AggregatedObject"), Browsable(false)]
        public CollectionProperties CollectionProperties {
            get { return collectionProperties; }
			set { SetPropertyValue("CollectionProperties", ref collectionProperties, value); }
        }
    }

    [NonPersistent]
	public class SomeObject {
        private string name;
        public SomeObject(string name) {
            this.name = name;
        }
        public string Name {
            get { return name; }
            set { name = value; }
        }
    }

	[NavigationItem(Captions.PropertyEditorsGroup), VisibleInReports(true)]
	[System.ComponentModel.DisplayName(Captions.PropertyEditors_CollectionProperties)]
    [Hint(Hints.CollectionPropertiesHint, ViewType.Any)]
	[ImageName("PropertyEditors.Demo_Collection_Properties")]
	[AutoCreatableObject(ViewEditMode = DevExpress.ExpressApp.Editors.ViewEditMode.View)]
	public class CollectionProperties : NamedBaseObject {
		private XPCollection<NoAssociationObject> noAssociation;
		private BindingList<AssociatedObject> persistentBindingList;
		private BindingList<SomeObject> nonPersistentObjectBindingList;

		private void EnsureNonPersistentObjectBindingList() {
			if(nonPersistentObjectBindingList == null) {
				nonPersistentObjectBindingList = new BindingList<SomeObject>();
				nonPersistentObjectBindingList.Add(new SomeObject("Object 1"));
				nonPersistentObjectBindingList.Add(new SomeObject("Object 2"));
				nonPersistentObjectBindingList.Add(new SomeObject("Object 3"));
			}
		}
		public override void AfterConstruction() {
			base.AfterConstruction();
			AssociatedObject associatedObject1 = new AssociatedObject(Session);
			associatedObject1.Name = "Associated Object 1";
			Association.Add(associatedObject1);

			AggregatedObject aggregatedObject1 = new AggregatedObject(Session);
			aggregatedObject1.Name = "Aggregated Object 1";
			AggregatedAssociation.Add(aggregatedObject1);

			if(NoAssociation.Count == 0) {
				NoAssociationObject obj = new NoAssociationObject(Session);
				obj.Name = "No Association Object 1";
				obj.Save();
				NoAssociation.Add(obj);
			}
		}
		public CollectionProperties(Session session) : base(session) { }
		[Association("CollectionProperties-AssociatedObject")]
        public XPCollection<AssociatedObject> Association {
            get { return GetCollection<AssociatedObject>("Association"); }
        }
        [Association("CollectionProperties-AggregatedObject"), Aggregated]
        public XPCollection<AggregatedObject> AggregatedAssociation {
            get { return GetCollection<AggregatedObject>("AggregatedAssociation"); }
        }
        [CollectionOperationSet(AllowAdd = false, AllowRemove = false)]
		public XPCollection<NoAssociationObject> NoAssociation {
			get {
				if(noAssociation == null) {
					noAssociation = new XPCollection<NoAssociationObject>(Session);
					noAssociation.BindingBehavior = CollectionBindingBehavior.AllowNone;
				}
				return noAssociation;
			}
		}
		[System.ComponentModel.DisplayName(Captions.PropertyEditors_CollectionProperties_BindingListProperty)]
		public BindingList<AssociatedObject> PersistentBindingList {
			get {
				if(persistentBindingList == null) {
					persistentBindingList = new BindingList<AssociatedObject>();
					persistentBindingList.ListChanged += delegate(object sender, ListChangedEventArgs e) {
						if(e.ListChangedType == ListChangedType.ItemAdded) {
							Association.Add(persistentBindingList[e.NewIndex]);
						}
						else if(e.ListChangedType == ListChangedType.ItemDeleted) {
							for(int i = Association.Count - 1; i >= 0; i--) {
								if(!persistentBindingList.Contains(Association[i])) {
									Association.Remove(Association[i]);
								}
							}
						}
					};
					persistentBindingList.AllowNew = true;
					persistentBindingList.AllowRemove = true;
					foreach(AssociatedObject obj in Association) {
						persistentBindingList.Add(obj);
					}
					Association.ListChanged += delegate(object sender, ListChangedEventArgs e) {
						if(e.ListChangedType == ListChangedType.Reset) {
							persistentBindingList.Clear();
							foreach(AssociatedObject obj in Association) {
								persistentBindingList.Add(obj);
							}
						}
						else if(e.ListChangedType == ListChangedType.ItemAdded && !persistentBindingList.Contains(Association[e.NewIndex])) {
							persistentBindingList.Add(Association[e.NewIndex]);
						}
						else if(e.ListChangedType == ListChangedType.ItemDeleted) {
							for(int i = persistentBindingList.Count - 1; i >= 0; i--) {
								if(Association.IndexOf(persistentBindingList[i]) < 0) {
									persistentBindingList.RemoveAt(i);
								}
							}
						}
					};
				}
				return persistentBindingList;
			}
		}
		[System.ComponentModel.DisplayName(Captions.PropertyEditors_CollectionProperties_ReadOnlyBindingListProperty)]
		public BindingList<SomeObject> NonPersistentBindingList {
			get {
				EnsureNonPersistentObjectBindingList();
				nonPersistentObjectBindingList.AllowRemove = false;
				nonPersistentObjectBindingList.AllowNew = false;
				nonPersistentObjectBindingList.AllowEdit = false;
				return nonPersistentObjectBindingList;
			}
		}
	}
}
