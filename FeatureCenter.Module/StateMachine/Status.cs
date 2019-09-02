using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.Persistent.Base;
using System.ComponentModel;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;

namespace FeatureCenter.Module.StateMachine {
    [DefaultProperty("Caption")]
    [NavigationItem("Directories")]
    [ImageName("BO_List")]
    public class Status : BaseObject {
        private string caption;
        public Status(Session session)
            : base(session) {

        }
        public string Caption {
            get { return caption; }
            set { SetPropertyValue("Caption", ref caption, value); }
        }
    }

}
