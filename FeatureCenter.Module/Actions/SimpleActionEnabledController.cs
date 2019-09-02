using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.Actions;
using DevExpress.Xpo;
using DevExpress.ExpressApp;

namespace FeatureCenter.Module.Actions {
    public class SimpleActionEnabledController : ViewController {
        private const string ActionId = "SimpleDemoAction_Disable";
        public SimpleActionEnabledController() {
            TargetObjectType = typeof(ActionEnabled);
            SimpleAction simpleActionEnabledDisabled = new SimpleAction(this, "SimpleDemoAction_Enabled", PredefinedCategory.View);
            simpleActionEnabledDisabled.ImageName = "Action_Save";
            simpleActionEnabledDisabled.Caption = "Save";
            simpleActionEnabledDisabled.Enabled[ActionId] = true;
            simpleActionEnabledDisabled.Execute += delegate(object sender, SimpleActionExecuteEventArgs e) {
                ((ActionEnabled)e.CurrentObject).Owner.LogExecuteAction(e.Action);
            };

            SimpleAction simpleActionDisable = new SimpleAction(this, ActionId, PredefinedCategory.Edit);
            simpleActionDisable.Caption = "Disable";
            simpleActionDisable.Execute += delegate(object sender, SimpleActionExecuteEventArgs e) {
                simpleActionEnabledDisabled.Enabled[ActionId] = !simpleActionEnabledDisabled.Enabled[ActionId];
                ((ActionEnabled)e.CurrentObject).Owner.LogExecuteAction(e.Action);
                if(simpleActionEnabledDisabled.Enabled[ActionId]) {
                    simpleActionDisable.Caption = "Disable";
                }
                else {
                    simpleActionDisable.Caption = "Enable";
                }
            };
        }
    }

}
