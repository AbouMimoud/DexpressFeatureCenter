using System;
using System.Collections.Generic;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace FeatureCenter.Module.ListEditors {
    [DefaultClassOptions]
    [ImageName("ListEditors.Demo_ListEditors_Grid_LargeData")]
    public class OrderBands : NamedBaseObject {
        private ContactBands contact;
        private ProductBands product;
        private int qty;
        private DateTime? date;
        public OrderBands(Session session) : base(session) { }
        public DateTime? Date {
            get { return date; }
            set { SetPropertyValue("Date", ref date, value); }
        }
        public int Qty {
            get { return qty; }
            set { SetPropertyValue("Qty", ref qty, value); }
        }
        [Association("ContactBands-OrderBands")]
        public ContactBands Contact {
            get { return contact; }
            set { SetPropertyValue("Contact", ref contact, value); }
        }
        [Association("ProductBands-OrderBands")]
        public ProductBands Product {
            get { return product; }
            set { SetPropertyValue("Product", ref product, value); }
        }
    }

    public class ContactBands : NamedBaseObject {
        private string email;
        private string phone;
        public ContactBands(Session session) : base(session) { }
        public string Email {
            get { return email; }
            set { SetPropertyValue("Email", ref email, value); }
        }
        public string Phone {
            get { return phone; }
            set { SetPropertyValue("Phone", ref phone, value); }
        }
        [Association("ContactBands-OrderBands")]
        public XPCollection<OrderBands> Orders {
            get { return GetCollection<OrderBands>("Orders"); }
        }
    }

    public class ProductBands : NamedBaseObject {
        private string company;
        private string country;
        private string region;
        private double unitPrice;
        public ProductBands(Session session) : base(session) { }
        public string Company {
            get { return company; }
            set { SetPropertyValue("Company", ref company, value); }
        }
        public string Country {
            get { return country; }
            set { SetPropertyValue("Country", ref country, value); }
        }
        public string Region {
            get { return region; }
            set { SetPropertyValue("Region", ref region, value); }
        }
        public double UnitPrice {
            get { return unitPrice; }
            set { SetPropertyValue("UnitPrice", ref unitPrice, value); }
        }
        [Association("ProductBands-OrderBands")]
        public XPCollection<OrderBands> Orders {
            get { return GetCollection<OrderBands>("Orders"); }
        }
    }
}
