using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using System.ComponentModel;
using DevExpress.Xpo;

namespace FeatureCenter.Module.PropertyEditors {
    [ImageName("PropertyEditors.Demo_Maps_Properties")]
    [DefaultProperty("Title")]
    [NavigationItem(false)]
    public class MapsPropertyEditorDemoObject : BaseObject {
        public MapsPropertyEditorDemoObject(Session session) : base(session) { }
        public override void AfterConstruction() {
            base.AfterConstruction();
            Address = new ObjectAddress(Session);
        }
        public string Title { get; set; }
        [Aggregated, ExpandObjectMembers(ExpandObjectMembers.Never), VisibleInListView(false)]
        public ObjectAddress Address { get; set; }
    }

    [ImageName("PropertyEditors.Demo_Maps_Properties")]
    [DefaultProperty("Title")]
    [NavigationItem(false)]
    public class ObjectAddress : BaseObject, IMapsMarker {
        public ObjectAddress(Session session) : base(session) { }
        public string Title { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
