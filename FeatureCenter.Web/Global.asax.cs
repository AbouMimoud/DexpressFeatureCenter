using System;
using System.Web.Routing;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Notifications;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Web;
using DevExpress.Persistent.Base;
using DevExpress.Web;

namespace FeatureCenter.Web {
    public class Global : System.Web.HttpApplication
    {
        public Global() {
#if DEBUG
            DevExpress.EasyTest.Framework.EasyTestTracer.Tracer.SetTraceLevel(System.Diagnostics.TraceLevel.Verbose);
#endif
            InitializeComponent();
        }
        protected void Application_Start(Object sender, EventArgs e)
        {
            AboutInfo.Instance.Copyright = AssemblyInfo.AssemblyCopyright + " All Rights Reserved";
            RouteTable.Routes.RegisterXafRoutes();
            ASPxWebControl.CallbackError += new EventHandler(Application_Error);
        }
        protected void Session_Start(Object sender, EventArgs e)
        {
            Tracing.Initialize();
            FeatureCenterAspNetApplication application = new FeatureCenterAspNetApplication();
            WebApplication.SetInstance(Session, application);

            NotificationsModule notificationsModule = application.Modules.FindModule<NotificationsModule>();
            notificationsModule.NotificationsRefreshInterval = TimeSpan.FromMinutes(1);

            DevExpress.ExpressApp.ScriptRecorder.ScriptRecorderControllerBase.ScriptRecorderEnabled = true;
            if(System.Diagnostics.Debugger.IsAttached && WebApplication.Instance.CheckCompatibilityType == CheckCompatibilityType.DatabaseSchema) {
                WebApplication.Instance.DatabaseUpdateMode = DatabaseUpdateMode.UpdateDatabaseAlways;
            }
			application.Setup();
			application.Start();
        }
        protected void Application_BeginRequest(Object sender, EventArgs e) {
        }
        protected void Application_EndRequest(Object sender, EventArgs e)
        {
        }
        protected void Application_AuthenticateRequest(Object sender, EventArgs e)
        {
        }
        protected void Application_Error(Object sender, EventArgs e)
        {
            ErrorHandling.Instance.ProcessApplicationError();
        }
        protected void Session_End(Object sender, EventArgs e)
        {
            WebApplication.DisposeInstance(Session);
        }
        protected void Application_End(Object sender, EventArgs e)
        {
        }
        #region Web Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
        }
        #endregion
    }
}
