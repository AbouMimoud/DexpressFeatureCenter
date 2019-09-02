using System;
using System.ComponentModel;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;

namespace FeatureCenter.Module.Reports {
    [VisibleInReports]
    [ImageName("BO_Person")]
    [DefaultProperty("FirstName")]
    [NavigationItem("Reports")]
    [System.ComponentModel.DisplayName("Contact")]
    public class ContactForReport : BaseObject {
        private TitleOfCourtesy titleOfCourtesy;
        private Position position;
        private string firstName;
        private DateTime birthday;
        private string email;
        private string lastName;

        public ContactForReport(Session session) :
            base(session) {
        }

        [Index(5)]
        public TitleOfCourtesy TitleOfCourtesy {
            get {
                return titleOfCourtesy;
            }
            set {
                SetPropertyValue("TitleOfCourtesy", ref titleOfCourtesy, value);
            }
        }
        [Index(3)]
        public Position Position {
            get {
                return position;
            }
            set {
                SetPropertyValue("Position", ref position, value);
            }
        }
        [Index(0)]
        public string FirstName {
            get { return firstName; }
            set {
                SetPropertyValue("FirstName", ref firstName, value);
            }
        }
        [Index(1)]
        public string LastName {
            get { return lastName; }
            set {
                SetPropertyValue("LastName", ref lastName, value);
            }
        }
        [Index(4)]
        public DateTime Birthday {
            get { return birthday; }
            set {
                SetPropertyValue("Birthday", ref birthday, value);
            }
        }
        [Index(3)]
        [Size(255)]
        public string Email {
            get { return email; }
            set {
                SetPropertyValue("Email", ref email, value);
            }
        }
        [Aggregated, Association("ContactForReport-PhoneNumberReportContact")]
        public XPCollection<PhoneNumberReportContact> PhoneNumbers {
            get { return GetCollection<PhoneNumberReportContact>("PhoneNumbers"); }
        }
    }
    public enum TitleOfCourtesy {
        Dr,
        Miss,
        Mr,
        Mrs,
        Ms
    };
}
