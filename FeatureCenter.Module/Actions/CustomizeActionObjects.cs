using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Persistent.BaseImpl;
using System.ComponentModel;
using DevExpress.Xpo;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Demos;

namespace FeatureCenter.Module.Actions.CustomizeAction {
    public abstract class CustomizeAction : BaseObject {
        public CustomizeAction(Session session) : base(session) { }
        private string caption;
        public string Caption {
            get { return caption; }
            set { SetPropertyValue<string>("Caption", ref caption, value); }
        }
    }
    [Hint(Hints.WebCustomizeControl)]
    [ImageName("ListEditors.Demo_ListEditors_Grid_LargeData")]
    [XafDisplayName("Inline Actions In Grid")]
    public class CustomizeInlineGridActionControl : CustomizeAction {
        public CustomizeInlineGridActionControl(Session session) : base(session) { }
    }
    [Hint(Hints.WebCustomizeControl, DevExpress.ExpressApp.ViewType.DetailView)]
    [ImageName(ActionsDemoStrings.SimpleActionImageName)]
    [XafDisplayName("Actions In Views")]
    public class CustomizeMenuActionControl : CustomizeAction {
        public CustomizeMenuActionControl(Session session) : base(session) { }
    }
    [Hint(Hints.WinCustomizeControl, DevExpress.ExpressApp.ViewType.DetailView)]
    [ImageName(ActionsDemoStrings.ParametrizedActionImageName)]
    [XafDisplayName("Custom Action Controls")]
    public class CustomizeActionControlObject : CustomizeAction {
        public CustomizeActionControlObject(Session session) : base(session) { }
    }
}
