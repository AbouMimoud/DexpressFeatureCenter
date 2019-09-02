using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using FeatureCenter.Module.Actions;
using System;
using System.ComponentModel;
using System.Drawing;

namespace FeatureCenter.Module.Northwind {
    [Persistent("Customers")]
	[DefaultProperty("CompanyName")]
    [VisibleInDashboards(true)]
    public class Customer : XPLiteObject {
		private string customerID;
		private string companyName;
		private string contactTitle;
		private string contactName;
		private string country;
		private string city;

		public Customer(Session session) : base(session) { }

		[Key(false), Browsable(false), MemberDesignTimeVisibility(false)]
		public string CustomerID {
			get { return customerID; }
			set { SetPropertyValue("CustomerID", ref customerID, value); }
		}
		public string CompanyName {
			get { return companyName; }
			set { SetPropertyValue("CompanyName", ref companyName, value); }
		}
		public string ContactTitle {
			get { return contactTitle; }
			set { SetPropertyValue("ContactTitle", ref contactTitle, value); }
		}
		public string ContactName {
			get { return contactName; }
			set { SetPropertyValue("ContactName", ref contactName, value); }
		}
		public string Country {
			get { return country; }
			set { SetPropertyValue("Country", ref country, value); }
		}
		public string City {
			get { return city; }
			set { SetPropertyValue("City", ref city, value); }
		}
		[Association("CustomerOrders")]
		public XPCollection<Order> Orders {
			get {
				return GetCollection<Order>("Orders");
			}
		}

        public override string ToString() {
            return CompanyName;
        }
	}
	[Persistent("Orders")]
	[VisibleInDashboards(true)]
	public class Order : XPLiteObject {
		private int orderID;
		private Customer customer;
        private NorthwindEmployee employee;
		private DateTime orderDate;
		private DateTime? shippedDate;
		private DateTime? requiredDate;
		private decimal freight;

		public Order(Session session) : base(session) { }

		[Key(true), Browsable(false), MemberDesignTimeVisibility(false)]
		public int OrderID {
			get { return orderID; }
			set { SetPropertyValue("OrderID", ref orderID, value); }
		}
		[Persistent("CustomerID"), Association("CustomerOrders")]
		public Customer Customer {
			get { return customer; }
			set { SetPropertyValue("Customer", ref customer, value); }
		}
		[Persistent("EmployeeID"), Association("EmployeeOrders")]
        public NorthwindEmployee Employee {
			get { return employee; }
			set { SetPropertyValue("Employee", ref employee, value); }
		}
		public DateTime OrderDate {
			get { return orderDate; }
			set { SetPropertyValue("OrderDate", ref orderDate, value); }
		}
		public DateTime? ShippedDate {
			get { return shippedDate; }
			set { SetPropertyValue("ShippedDate", ref shippedDate, value); }
		}
		public DateTime? RequiredDate {
			get { return requiredDate; }
			set { SetPropertyValue("RequiredDate", ref requiredDate, value); }
		}
		public decimal Freight {
			get { return freight; }
			set { SetPropertyValue("Freight", ref freight, value); }
		}

	}
	[Persistent("Employees")]
	[DefaultProperty("FullName")]
	[VisibleInDashboards(true)]
    public class NorthwindEmployee : XPLiteObject {
		private int employeeID;
		private string firstName;
		private string lastName;
        private Image photo;

		public NorthwindEmployee(Session session) : base(session) { }

		[Key(true), Browsable(false), MemberDesignTimeVisibility(false)]
		public int EmployeeID {
			get { return employeeID; }
			set { SetPropertyValue("EmployeeID", ref employeeID, value); }
		}
		public string FirstName {
			get { return firstName; }
			set { SetPropertyValue("FirstName", ref firstName, value); }
		}
		public string LastName {
			get { return lastName; }
			set { SetPropertyValue("LastName", ref lastName, value); }
		}
        [ValueConverter(typeof(ImageValueConverter))]
        public Image Photo {
            get {
                return photo;
            }
            set {
                SetPropertyValue("Photo", ref photo, value);
            }
        }
		[PersistentAlias("FirstName + ' ' + LastName")]
		public string FullName {
			get { return FirstName + " " + LastName; }
		}
        [Association("EmployeeOrders")]
		public XPCollection<Order> Orders {
			get {
				return GetCollection<Order>("Orders");
			}
		}

        public override string ToString() {
            return FullName;
        }
	}

    public class DisableControllersForNorthwindObjects : DisableControllersByConditionViewController {
        protected override string DisableReason { get { return "IsNorthwindObject"; } }
        protected override bool GetIsDisabled() {
            return (View is ObjectView) && (
                ((ObjectView)View).ObjectTypeInfo.Type.IsAssignableFrom(typeof(Order))
                || ((ObjectView)View).ObjectTypeInfo.Type.IsAssignableFrom(typeof(NorthwindEmployee))
                || ((ObjectView)View).ObjectTypeInfo.Type.IsAssignableFrom(typeof(Customer))
                );
        }
    }
}
