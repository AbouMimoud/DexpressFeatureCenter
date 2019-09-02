using System;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.ExpressApp;

namespace FeatureCenter.Module.NonPersistentObjects {
    public class NonPersistentObjectActivatorController : ObjectViewController<DetailView, BaseNonPersistentClass> {
        protected override void OnActivated() {
            base.OnActivated();
            if((ObjectSpace is NonPersistentObjectSpace) && (View.CurrentObject == null)) {
                View.CurrentObject = View.ObjectTypeInfo.CreateInstance();
                View.ViewEditMode = DevExpress.ExpressApp.Editors.ViewEditMode.Edit;
            }
        }
    }
    public class NonPersistentObjectSpaceExtender {
        private List<BaseNonPersistentClass> globalObjects;
        private IObjectSpace additionalObjectSpace;

        private void ObjectSpace_ObjectsGetting(Object sender, ObjectsGettingEventArgs e) {
            BindingList<BaseNonPersistentClass> objects = new BindingList<BaseNonPersistentClass>();
            objects.AllowNew = true;
            objects.AllowEdit = true;
            objects.AllowRemove = true;
            foreach(BaseNonPersistentClass obj in globalObjects) {
                if(e.ObjectType.IsAssignableFrom(obj.GetType())) {
                    objects.Add(obj);
                    obj.ObjectSpace = (IObjectSpace)sender;
                }
            }
            e.Objects = objects;
        }
        private void ObjectSpace_ObjectByKeyGetting(Object sender, ObjectByKeyGettingEventArgs e) {
            foreach(BaseNonPersistentClass obj in globalObjects) {
                if((obj.GetType() == e.ObjectType) && (obj is NonPersistentClassWithKeyProperty) && (e.Key is Int32)
                        && (((NonPersistentClassWithKeyProperty)obj).ID == (Int32)e.Key)) {
                    obj.ObjectSpace = (IObjectSpace)sender;
                    e.Object = obj;
                    break;
                }
            }
        }
        private void ObjectSpace_ObjectsCountGetting(object sender, ObjectsCountGettingEventArgs e) {
            if(typeof(BaseNonPersistentClass).IsAssignableFrom(e.ObjectType)) {
                e.Count = 0;
            }
        }
        private void ObjectSpace_ObjectGetting(object sender, ObjectGettingEventArgs e) {
            if(e.SourceObject is IObjectSpaceLink) {
                e.TargetObject = e.SourceObject;
                ((IObjectSpaceLink)e.TargetObject).ObjectSpace = (IObjectSpace)sender;
            }
        }
        private void ObjectSpace_Committing(Object sender, CancelEventArgs e) {
            NonPersistentObjectSpace objectSpace = (NonPersistentObjectSpace)sender;
            foreach(Object obj in objectSpace.ModifiedObjects) {
                if(obj is BaseNonPersistentClass) {
                    if(!globalObjects.Contains((BaseNonPersistentClass)obj)) {
                        globalObjects.Add((BaseNonPersistentClass)obj);
                    }
                    else if(objectSpace.IsDeletedObject(obj)) {
                        globalObjects.Remove((BaseNonPersistentClass)obj);
                    }
                }
            }
        }
        private void ObjectSpace_Disposed(object sender, EventArgs e) {
            NonPersistentObjectSpace objectSpace = sender as NonPersistentObjectSpace;
            objectSpace.ObjectsGetting -= ObjectSpace_ObjectsGetting;
            objectSpace.ObjectByKeyGetting -= ObjectSpace_ObjectByKeyGetting;
            objectSpace.ObjectsCountGetting -= ObjectSpace_ObjectsCountGetting;
            objectSpace.ObjectGetting -= ObjectSpace_ObjectGetting;
            objectSpace.Committing -= ObjectSpace_Committing;
            additionalObjectSpace.Dispose();
            additionalObjectSpace = null;
        }
        public NonPersistentObjectSpaceExtender(NonPersistentObjectSpace objectSpace, List<BaseNonPersistentClass> globalObjects, IObjectSpace additionalObjectSpace) {
            this.globalObjects = globalObjects;
            this.additionalObjectSpace = additionalObjectSpace;
            if(objectSpace != null) {
                objectSpace.Committing += ObjectSpace_Committing;
                objectSpace.ObjectsGetting += ObjectSpace_ObjectsGetting;
                objectSpace.ObjectByKeyGetting += ObjectSpace_ObjectByKeyGetting;
                objectSpace.AdditionalObjectSpaces.Add(additionalObjectSpace);
                objectSpace.ObjectsCountGetting += ObjectSpace_ObjectsCountGetting;
                objectSpace.ObjectGetting += ObjectSpace_ObjectGetting;
                objectSpace.Disposed += ObjectSpace_Disposed;
            }
        }
    }
}
