using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using System.ComponentModel;
using DevExpress.ExpressApp.Demos;
using DevExpress.Xpo;
using FeatureCenter.Module.Audit;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp;

namespace FeatureCenter.Module.ListEditors {
    [ImageName("ListEditors.Demo_ListEditors_Maps")]
    [DefaultProperty("Title")]
    [NavigationItem(false)]
    public class MapsListEditorDemoObject : BaseObject, IMapsMarker {
        public MapsListEditorDemoObject(Session session) : base(session) { }
        public string Title { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        [Browsable(false), Association("USAState-Stores")]
        public VectorMapsListEditorDemoObject USAState { get; set; }
    }
}
