using DevExpress.ExpressApp;
using DevExpress.ExpressApp.SystemModule;
using FeatureCenter.Module.StateMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace FeatureCenter.Module.Performance {
    public class DelayedDetailViewDataLoadingController : ViewController {
        ListViewProcessCurrentObjectController listViewProcessCurrentObjectController;
        private void listViewProcessCurrentObjectController_CustomProcessSelectedItem(object sender, CustomProcessListViewSelectedItemEventArgs e) {
            CustomEmployee.IsSleepOnLoad = true;
            if(View.Id == "CustomEmployee_ListView_1") {
                Application.IsDelayedDetailViewDataLoadingEnabled = true;
            }
            else {
                Application.IsDelayedDetailViewDataLoadingEnabled = false;
            }
        }
        protected override void OnActivated() {
            base.OnActivated();
            listViewProcessCurrentObjectController = Frame.GetController<ListViewProcessCurrentObjectController>();
            if(listViewProcessCurrentObjectController != null) {
                listViewProcessCurrentObjectController.CustomProcessSelectedItem += listViewProcessCurrentObjectController_CustomProcessSelectedItem;
            }
        }
        protected override void OnDeactivated() {
            if(listViewProcessCurrentObjectController != null) {
                listViewProcessCurrentObjectController.CustomProcessSelectedItem -= listViewProcessCurrentObjectController_CustomProcessSelectedItem;
            }
            CustomEmployee.IsSleepOnLoad = false;
            base.OnDeactivated();
        }
        public DelayedDetailViewDataLoadingController() {
            this.TargetObjectType = typeof(CustomEmployee);
            this.TargetViewType = ViewType.ListView;
        }
    }
}
