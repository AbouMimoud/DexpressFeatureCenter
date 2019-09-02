using System;
using System.ComponentModel;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Data;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Demos;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using FeatureCenter.Module.Reports;

namespace FeatureCenter.Module.NonPersistentObjects {
    [DomainComponent]
    [Hint(Hints.NonPersistentObjectsListHint)]
    public abstract class BaseNonPersistentClass : IObjectSpaceLink, INotifyPropertyChanged {
        private String name;
        private IObjectSpace objectSpace;

        protected void RaisePropertyChanged(String propertyName) {
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));			
        }
        public BaseNonPersistentClass(String name)
            : base() {
            this.name = name;
        }
        public String Name {
            get { return name; }
            set {
                if(name != value) {
                    name = value;
                    RaisePropertyChanged("Name");
                }
            }
        }

        // INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        // IObjectSpaceLink
        [Browsable(false)]
        public IObjectSpace ObjectSpace {
            get { return objectSpace; }
            set { objectSpace = value; }
        }
    }

    [DomainComponent]
    [NavigationItem(false)]
    [ImageName("NonPersistentObjects.Non-persistent_object")]
    public class SimpleNonPersistentClass : BaseNonPersistentClass {
        public SimpleNonPersistentClass(String name)
            : base(name) {
        }
        public SimpleNonPersistentClass()
            : this("") {
        }
    }
    [NavigationItem(false)]
    [DomainComponent]
    public abstract class NonPersistentClassWithKeyProperty : BaseNonPersistentClass {
        protected static int idCounter = 4;
        private Int32 id;
        public NonPersistentClassWithKeyProperty(Int32 id, String name)
            : base(name) {
            this.id = id;
        }
        public NonPersistentClassWithKeyProperty()
            : this(idCounter++, "") {
        }
        [Key]
        [Browsable(false)]
        public Int32 ID {
            get { return id; }
        }
    }

    [DomainComponent]
    [NavigationItem(false)]
    [ImageName("NonPersistentObjects.Non-persistent_object_with_non-persistent_collection")]
    [Hint(Hints.NonPersistentWithCollectionHint, ViewType.DetailView)]
    public class NonPersistentClassWithNonPersistentCollection : NonPersistentClassWithKeyProperty {
        private BindingList<NonPersistentClassWithPersistentProperty> nonPersistentObjectsCollection;
        public NonPersistentClassWithNonPersistentCollection(Int32 id, String name)
            : base(id, name) {
            nonPersistentObjectsCollection = new BindingList<NonPersistentClassWithPersistentProperty>();
        }
        public NonPersistentClassWithNonPersistentCollection()
            : this(idCounter++, "") {
        }
        [ModelDefault("Caption", "Non-Persistent Objects Collection")]
        public BindingList<NonPersistentClassWithPersistentProperty> NonPersistentObjectsCollection {
            get { return nonPersistentObjectsCollection; }
        }
        public void AddNonPersistentClassWithPersistentProperty(NonPersistentClassWithPersistentProperty nonPersistentClass) {
            nonPersistentClass.ReferencedNonPersistentObject = this;
        }
    }
    [NavigationItem(false)]
    [Hint(Hints.NonPersistentWithPersistentPropertytHint, ViewType.DetailView)]
    [ImageName("NonPersistentObjects.Non-persistent_object")]
    [DomainComponent]
    public class NonPersistentClassWithPersistentProperty : NonPersistentClassWithKeyProperty {
        private NonPersistentClassWithNonPersistentCollection referencedNonPersistentObject;
        private ContactForReport persistentOwner;

        public NonPersistentClassWithPersistentProperty(Int32 id, String name)
            : base(id, name) {
        }
        public NonPersistentClassWithPersistentProperty()
            : base() {
        }
        [VisibleInListView(false)]
        [ModelDefault("Caption", "Referenced Non-Persistent Object")]
        public NonPersistentClassWithNonPersistentCollection ReferencedNonPersistentObject {
            get { return referencedNonPersistentObject; }
            set {
                if(referencedNonPersistentObject != value) {
                    referencedNonPersistentObject = value;
                    if(!referencedNonPersistentObject.NonPersistentObjectsCollection.Contains(this)) {
                        referencedNonPersistentObject.NonPersistentObjectsCollection.Add(this);
                    }
                    RaisePropertyChanged("ReferencedNonPersistentClass");
                }
            }
        }
        public ContactForReport PersistentOwner {
            get { return persistentOwner; }
            set {
                if(persistentOwner != value) {
                    persistentOwner = value;
                    RaisePropertyChanged("Owner");
                }
            }
        }
        [ModelDefault("AllowEdit", "False")]
        public System.Collections.Generic.IList<ContactForReport> PersistentObjectsCollection {
            get {
                return ((ObjectSpace != null) && !ObjectSpace.IsDisposed) ? ObjectSpace.GetObjects<ContactForReport>(/* some critria if need */) : null;
            }
        }
    }
}
