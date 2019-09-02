using System;
using System.Configuration;
using System.Windows.Forms;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.Win.SystemModule;
using DevExpress.Persistent.Base;
using DevExpress.XtraBars.Ribbon;
using FeatureCenter.Module.Win;

namespace FeatureCenter.Win
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
		[STAThread]
        static void Main(string[] arguments)
        {
            //XafTypesInfo.Instance.RegisterEntity("PropertyLogicImplementation", typeof(FeatureCenter.Module.DC.IPropertyLogicImplementation));
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
            EditModelPermission.AlwaysGranted = System.Diagnostics.Debugger.IsAttached;
			FeatureCenterWindowsFormsApplication xafApplication = new FeatureCenterWindowsFormsApplication();            
            if(Tracing.GetFileLocationFromSettings() == FileLocation.CurrentUserApplicationDataFolder) {
                Tracing.LocalUserAppDataPath = Application.LocalUserAppDataPath;
            }
            Tracing.Initialize();
            // Refer to the http://documentation.devexpress.com/#Xaf/CustomDocument2680 help article for more details on how to provide a custom splash form.
            xafApplication.SplashScreen = new DevExpress.ExpressApp.Win.Utils.DXSplashScreen();
            xafApplication.CreateCustomTemplate += new EventHandler<CreateCustomTemplateEventArgs>(xafApplication_CreateCustomTemplate);

			if(ConfigurationManager.ConnectionStrings["ConnectionString"] != null) {
				xafApplication.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
			}
            DevExpress.ExpressApp.ScriptRecorder.ScriptRecorderControllerBase.ScriptRecorderEnabled = true;
            if(System.Diagnostics.Debugger.IsAttached && xafApplication.CheckCompatibilityType == CheckCompatibilityType.DatabaseSchema) {
                xafApplication.DatabaseUpdateMode = DatabaseUpdateMode.UpdateDatabaseAlways;
            }
            try
            {
				xafApplication.Setup();
				xafApplication.Start();
            }
            catch (Exception e)
            {
				xafApplication.HandleException(e);
            }
        }

        static MainRibbonForm createdMainRibbonForm;
        static MainForm createdMainForm;
        static void xafApplication_CreateCustomTemplate(object sender, CreateCustomTemplateEventArgs e) {
            if(e.Application.Model != null) {
                bool isRibbon = ((IModelOptionsWin)e.Application.Model.Options).FormStyle == RibbonFormStyle.Ribbon;
                if(isRibbon) {
                    if(e.Context == TemplateContext.ApplicationWindow) {
                        if(createdMainRibbonForm != null) {
                            e.Template = createdMainRibbonForm;
                            createdMainRibbonForm = null;
                        }
                        else {
                            e.Template = new MainRibbonForm();
                        }
                    }
                    else if(e.Context == TemplateContext.View) {
                        e.Template = new DetailRibbonForm();
                    }
                }
                else {
                    if(e.Context == TemplateContext.ApplicationWindow) {
                        if(createdMainForm != null) {
                            e.Template = createdMainForm;
                            createdMainForm = null;
                        }
                        else {
                            e.Template = new MainForm();
                        }
                    }
                    else if(e.Context == TemplateContext.View) {
                        e.Template = new DetailForm();
                    }
                }
            }
            else {
                if(e.Context == TemplateContext.ApplicationWindow) {
                    e.UseDefaultTemplate = false;
                    createdMainRibbonForm = new MainRibbonForm();
                    createdMainForm = new MainForm();
                }
            }
        }
    }
}
