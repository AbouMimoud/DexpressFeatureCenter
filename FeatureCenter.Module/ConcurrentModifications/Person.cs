using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;

namespace FeatureCenter.Module.ConcurrentModifications {
    [Persistent("PersonData")]
    public class Person : BaseObject {
        private string contactName;
        private string contactTitle;
        private string companyName;
        private string country;
        private string city;
        private string phone;
        public Person(Session session) : base(session) { }
        public string ContactName {
            get { return contactName; }
            set { SetPropertyValue("ContactName", ref contactName, value); }
        }
        public string ContactTitle {
            get { return contactTitle; }
            set { SetPropertyValue("ContactTitle", ref contactTitle, value); }
        }
        public string CompanyName {
            get { return companyName; }
            set { SetPropertyValue("CompanyName", ref companyName, value); }
        }
        public string Country {
            get { return country; }
            set { SetPropertyValue("Country", ref country, value); }
        }
        public string City {
            get { return city; }
            set { SetPropertyValue("City", ref city, value); }
        }
        public string Phone {
            get { return phone; }
            set { SetPropertyValue("Phone", ref phone, value); }
        }
    }
}
