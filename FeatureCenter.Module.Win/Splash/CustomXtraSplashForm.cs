using System;
using System.Collections.Generic;
using DevExpress.ExpressApp.Win.Utils;

namespace FeatureCenter.Module.Win.Splash {
    public partial class CustomXtraSplashForm : DevExpress.XtraSplashScreen.SplashScreen {
        public CustomXtraSplashForm() {
            InitializeComponent();
        }
        #region Overrides
        public override void ProcessCommand(Enum cmd, object arg) {
            base.ProcessCommand(cmd, arg);
            UpdateSplashCommand command = (UpdateSplashCommand)cmd;
            if(command == UpdateSplashCommand.Description) {
                string description = Convert.ToString(arg);
                labelControl2.Text = description;
            }
        }
        #endregion
    }
}
