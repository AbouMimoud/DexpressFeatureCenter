using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;

namespace FeatureCenter.Module.Reports {
    public class PhoneNumberReportContact : BaseObject {
        private string number;
        private ContactForReport contact;

        public PhoneNumberReportContact(Session session) : base(session) { }

        [Persistent]
        public string Number {
            get { return number; }
            set {
                SetPropertyValue("Number", ref number, value);
            }
        }

        [Association("ContactForReport-PhoneNumberReportContact")]
        public ContactForReport Contact {
            get { return contact; }
            set { SetPropertyValue("Contact", ref contact, value); }
        }
    }
}
