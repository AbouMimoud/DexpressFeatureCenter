using DevExpress.ExpressApp;
using DevExpress.ExpressApp.SystemModule;

namespace FeatureCenter.Module.ConcurrentModifications {
    public class ConcurrentModificationsController : ObjectViewController<DetailView, Person> {
        protected const string ActiveKey = "ConcurrentModificationsController";
        protected override void OnActivated() {
            base.OnActivated();
            Frame.GetController<DeleteObjectsViewController>().Active[ActiveKey] = false;
            Frame.GetController<NewObjectViewController>().Active[ActiveKey] = false;
            Frame.GetController<ModificationsController>().SaveAndCloseAction.Active[ActiveKey] = false;
            Frame.GetController<ModificationsController>().SaveAndNewAction.Active[ActiveKey] = false;
            ((DevExpress.ExpressApp.Xpo.XPObjectSpace)ObjectSpace).Session.TrackPropertiesModifications = true;
            ObjectSpace.Reloaded += ObjectSpace_Reloaded;
            View.CurrentObject = GetPerson();
        }
        protected override void OnDeactivated() {
            ObjectSpace.Reloaded -= ObjectSpace_Reloaded;
            base.OnDeactivated();
        }

        private void ObjectSpace_Reloaded(object sender, System.EventArgs e) {
            ((DevExpress.ExpressApp.Xpo.XPObjectSpace)ObjectSpace).Session.TrackPropertiesModifications = true;
        }
        private Person GetPerson() {
            Person person = ObjectSpace.FindObject<Person>(null);
            if(person == null) {
                person = ObjectSpace.CreateObject<Person>();
                person.ContactName = "Maria Anders";
                person.ContactTitle = "Sales Representative";
                person.CompanyName = "Alfreds Futterkiste";
                person.Country = "Germany";
                person.City = "Berlin";
                person.Phone = "030-0074321";
                ObjectSpace.CommitChanges();
            }
            return person;
        }
    }
}
