using System;
using System.Linq;
using System.Threading;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Win;
using System.Collections.Generic;
using DevExpress.ExpressApp.Actions;

namespace FeatureCenter.Module.Win.Splash {
    public class SplashController : ViewController<DashboardView> {
        private const string STR_SplashDemoActionCategory = "SplashDemo";
        private readonly SimpleAction defaultXafSplashFormAction, defaultXafWaitFormAction, customXtraSplashFormAction, customXtraSplashImageAction;
        private readonly string[,] splashUpdates = new string[,]{
                                                    { "Please wait...", "Starting..." }, 
                                                    { "A bit more...", "Pretending to do something..." }, 
                                                    { "Thanks for waiting!", "Finishing..." } 
        };
        public SplashController() {
            TargetViewId = "SplashDemoDashboard";
            defaultXafSplashFormAction = new SimpleAction(this, "DefaultXafSplashForm", STR_SplashDemoActionCategory, OnSplashDemoActionExecute);
            defaultXafSplashFormAction.Caption = Hints.DefaultXafSplashFormActionCaption;

            defaultXafWaitFormAction = new SimpleAction(this, "DefaultXafWaitForm", STR_SplashDemoActionCategory, OnSplashDemoActionExecute);
            defaultXafWaitFormAction.Caption = Hints.DefaultXafWaitFormActionCaption;

            customXtraSplashFormAction = new SimpleAction(this, "CustomXtraSplashForm", STR_SplashDemoActionCategory, OnSplashDemoActionExecute);
            customXtraSplashFormAction.Caption = Hints.CustomXtraSplashFormActionCaption;

            customXtraSplashImageAction = new SimpleAction(this, "CustomXtraSplashImage", STR_SplashDemoActionCategory, OnSplashDemoActionExecute);
            customXtraSplashImageAction.Caption = Hints.CustomXtraSplashImageActionCaption;
        }
        protected override void OnActivated() {
            base.OnActivated();
            defaultXafSplashFormAction.Tag = new DevExpress.ExpressApp.Win.Core.SplashScreen();
            defaultXafWaitFormAction.Tag = new DevExpress.ExpressApp.Win.Utils.DXSplashScreen();
            customXtraSplashFormAction.Tag = new DevExpress.ExpressApp.Win.Utils.DXSplashScreen(typeof(CustomXtraSplashForm));
            try {
                customXtraSplashImageAction.Tag = new DevExpress.ExpressApp.Win.Utils.DXSplashScreen("SplashImage.png");
            }
            catch {
                customXtraSplashImageAction.Active["SplashImage"] = false;
            }
        }
        private void OnSplashDemoActionExecute(object sender, SimpleActionExecuteEventArgs args) {
            // Set the WinApplication.SplashScreen property to provide a splash screen for your application.
            WinApplication.SplashScreen = (ISplash)args.Action.Tag;
            // Call the SetDisplayText to provide the initial display text for your splash screen.
            WinApplication.SplashScreen.SetDisplayText(splashUpdates[0, 0]);
            
            // The following methods are called manually for demo purposes only.
            WinApplication.StartSplash();
            for(int i = 0; i < splashUpdates.Length / 2; i++) {
                if(WinApplication.SplashScreen is ISupportUpdateSplash) {
                    bool demoFlag = true;
                    if(demoFlag) {
                        // You can also update your splash screen to notify users about current progress.
                        ((ISupportUpdateSplash)WinApplication.SplashScreen).UpdateSplash(splashUpdates[i, 0], splashUpdates[i, 1]);
                    }//OR
                    else {
                        // This approach is good when you do not have access to a WinApplication, e.g,. in the ModuleUpdater class.
                        // You can also localize or customize built-in XAF status messages by overriding the XafApplication.UpdateStatus method (test the Context parameter with the DevExpress.ExpressApp.Localization.ApplicationStatusMesssageId enumeration value).
                        ((WinApplication)Application).UpdateStatus(splashUpdates[i, 0], "", splashUpdates[i, 1]);
                    }
                }
                Thread.Sleep(1500);
            }
            WinApplication.StopSplash();
        }
        protected override void OnDeactivated() {
            base.OnDeactivated();
            WinApplication.StopSplash();
        }
        protected WinApplication WinApplication {
            get { return (WinApplication)base.Application; }
        }
    }
}
