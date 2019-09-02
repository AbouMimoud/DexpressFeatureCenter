using DevExpress.ExpressApp;
using DevExpress.Xpo;
using FeatureCenter.Module.StateMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using DevExpress.Persistent.Base;

namespace FeatureCenter.Module.Performance {
    public class CustomEmployee : Employee, IXafEntityObject {
        public CustomEmployee(Session session)
            : base(session) {
        }
        public void OnCreated() {
        }
        public new void OnLoaded() {
            if(IsSleepOnLoad) {
                Thread.Sleep(2000);
            }
        }
        private void timer_Tick(object sender, EventArgs e) {
        }
        public new void OnSaving() {
        }
        public static bool IsSleepOnLoad {
            get;
            set;
        }
    }
}
