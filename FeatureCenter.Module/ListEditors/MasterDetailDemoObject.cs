using System;
using System.ComponentModel;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;

namespace FeatureCenter.Module.ListEditors {
    [ImageName("ListEditors.Demo_ListEditors_Grid_MasterDetail")]
    [NavigationItem(false)]
    public class MasterObject : BaseObject {
        public MasterObject(Session session) : base(session) { }
        [VisibleInListView(false)]
        public DateTime Birthday { get; set; }
        [VisibleInListView(false)]
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        [VisibleInListView(false)]
        public string PhoneNumber { get; set; }
        [VisibleInListView(false)]
        public DateTime HiredDate { get; set; }

        [Association("MasterObject-DetailObjects"), Aggregated]
        public XPCollection<DetailObject> DetailObjects {
            get { return GetCollection<DetailObject>("DetailObjects"); }
        }
    }
    [ImageName("ListEditors.Demo_ListEditors_Grid_MasterDetail")]
    [DefaultProperty("Title")]
    [NavigationItem(false)]
    public class DetailObject : BaseObject {
        public DetailObject(Session session) : base(session) { }
        public string Title { get; set; }
        public string Comment  { get; set; }
        public DateTime BeginDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        [Browsable(false), Association("MasterObject-DetailObjects")]
        public MasterObject MasterObject { get; set; }
    }
}
