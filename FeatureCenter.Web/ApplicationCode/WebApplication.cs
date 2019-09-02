using System;
using System.Configuration;

using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Web;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Internal;
using FeatureCenter.Module;
using FeatureCenter.Module.ListEditors;

namespace FeatureCenter.Web {
	public partial class FeatureCenterAspNetApplication : WebApplication {
		private DevExpress.ExpressApp.SystemModule.SystemModule module1;
		private DevExpress.ExpressApp.Web.SystemModule.SystemAspNetModule module2;
		private FeatureCenter.Module.FeatureCenterModule module3;
		private FeatureCenter.Module.Web.FeatureCenterAspNetModule module4;
		//private DevExpress.ExpressApp.Reports.Web.ReportsAspNetModule module5;
		private DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule module6;
		private DevExpress.ExpressApp.FileAttachments.Web.FileAttachmentsAspNetModule module7;
		private DevExpress.ExpressApp.Validation.ValidationModule module8;
        private DevExpress.ExpressApp.Validation.Web.ValidationAspNetModule validationAspNetModule;
		private DevExpress.ExpressApp.HtmlPropertyEditor.Web.HtmlPropertyEditorAspNetModule module9;
		private DevExpress.ExpressApp.TreeListEditors.Web.TreeListEditorsAspNetModule module10;
		private DevExpress.ExpressApp.Scheduler.Web.SchedulerAspNetModule schedulerAspNetModule1;
		private DevExpress.ExpressApp.Scheduler.SchedulerModuleBase schedulerModuleBase1;
		private DevExpress.ExpressApp.ScriptRecorder.Web.ScriptRecorderAspNetModule scriptRecorderAspNetModule1;
		private DevExpress.ExpressApp.ScriptRecorder.ScriptRecorderModuleBase scriptRecorderModuleBase1;
		private DevExpress.ExpressApp.ViewVariantsModule.ViewVariantsModule viewVariantsModule1;
		private DevExpress.ExpressApp.ConditionalAppearance.ConditionalAppearanceModule conditionalAppearanceModule;
		private DevExpress.ExpressApp.Kpi.KpiModule kpiModule;
		private DevExpress.ExpressApp.Chart.ChartModule chartModule;
		private DevExpress.ExpressApp.Chart.Web.ChartAspNetModule chartAspNetModule;
		private DevExpress.ExpressApp.PivotGrid.PivotGridModule pivotGridModule;
		private DevExpress.ExpressApp.PivotGrid.Web.PivotGridAspNetModule pivotGridAspNetModule;
		private DevExpress.ExpressApp.StateMachine.StateMachineModule stateMachine1;
		private DevExpress.ExpressApp.ReportsV2.ReportsModuleV2 reportsModule;
		private DevExpress.ExpressApp.ReportsV2.Web.ReportsAspNetModuleV2 reportsAspNetModule;
        private DevExpress.ExpressApp.Notifications.NotificationsModule notificationsModule;
        private DevExpress.ExpressApp.Notifications.Web.NotificationsAspNetModule notificationsModuleWeb;
        private DevExpress.ExpressApp.Office.Web.OfficeAspNetModule officeAspNetModule;
        private DevExpress.ExpressApp.Office.OfficeModule officeModule;
        private DevExpress.ExpressApp.Maps.Web.MapsAspNetModule mapsModuleWeb;
        private DevExpress.ExpressApp.Dashboards.DashboardsModule dashboardsModule;

        private FeatureCenterXpoDataStoreProvider provider;
		private static readonly object CreateDefaultObjectSpaceProviderLockObject = new object();

		#region Default XAF configuration options (https://www.devexpress.com/kb=T501418)
		static FeatureCenterAspNetApplication() {
			EnableMultipleBrowserTabsSupport = true;
			DevExpress.ExpressApp.Web.Editors.ASPx.ASPxGridListEditor.AllowFilterControlHierarchy = true;
			DevExpress.ExpressApp.Web.Editors.ASPx.ASPxGridListEditor.MaxFilterControlHierarchyDepth = 3;
			DevExpress.ExpressApp.Web.Editors.ASPx.ASPxCriteriaPropertyEditor.AllowFilterControlHierarchyDefault = false;
			DevExpress.ExpressApp.Web.Editors.ASPx.ASPxCriteriaPropertyEditor.MaxHierarchyDepthDefault = 3;
			DevExpress.Persistent.Base.PasswordCryptographer.EnableRfc2898 = true;
			DevExpress.Persistent.Base.PasswordCryptographer.SupportLegacySha512 = false;
		}
		private void InitializeDefaults() {
			LinkNewObjectToParentImmediately = false;
			OptimizedControllersCreation = true;
			EnableModelCache = true;
		}
		#endregion

		public FeatureCenterAspNetApplication() {
			InitializeComponent();
			InitializeDefaults();
		}
		protected override IViewUrlManager CreateViewUrlManager() {
			return new ViewUrlManager();
		}
		protected override void CreateDefaultObjectSpaceProvider(CreateCustomObjectSpaceProviderEventArgs args) {
			if (provider == null) {
				lock (CreateDefaultObjectSpaceProviderLockObject) {
					if (provider == null) {
						try {
							provider = new FeatureCenter.Module.FeatureCenterXpoDataStoreProvider();
							provider.Initialize(
								string.Format(@"XpoProvider=InMemoryDataStore; Read Only=True; Data Source={0}\App_Data\nwind.xml", AppDomain.CurrentDomain.SetupInformation.ApplicationBase),
								GetConnectionString());
						}
						catch {
							provider = null;
							throw;
						}
					}
				}
			}
			args.ObjectSpaceProviders.Add(new XPObjectSpaceProvider(provider));
			args.ObjectSpaceProviders.Add(new NonPersistentObjectSpaceProvider(TypesInfo, null));
		}
		private String GetConnectionString() {
			String result = null;
			String siteMode = ConfigurationManager.AppSettings["SiteMode"];
			if(siteMode != null && siteMode.ToLower() == "true") {
				ConnectionString = InMemoryDataStoreProvider.ConnectionString;
			}
			else {
				ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["ConnectionString"];
				if(connectionStringSettings != null) {
					result = connectionStringSettings.ConnectionString;
				}
				else {
					connectionStringSettings = ConfigurationManager.ConnectionStrings["SqlExpressConnectionString"];
					if(connectionStringSettings != null) {
						result = DbEngineDetector.PatchConnectionString(connectionStringSettings.ConnectionString);
					}
				}
			}

			return result;
		}
		private void FeatureCenterAspNetApplication_DatabaseVersionMismatch(object sender, DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs e) {
			e.Updater.Update();
			e.Handled = true;
		}
		private void InitializeComponent() {
			this.module1 = new DevExpress.ExpressApp.SystemModule.SystemModule();
			this.module2 = new DevExpress.ExpressApp.Web.SystemModule.SystemAspNetModule();
			this.module3 = new FeatureCenter.Module.FeatureCenterModule();
			this.module4 = new FeatureCenter.Module.Web.FeatureCenterAspNetModule();
			this.module6 = new DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule();
			//this.module5 = new DevExpress.ExpressApp.Reports.Web.ReportsAspNetModule();
			this.module7 = new DevExpress.ExpressApp.FileAttachments.Web.FileAttachmentsAspNetModule();
			this.module8 = new DevExpress.ExpressApp.Validation.ValidationModule();
            this.validationAspNetModule = new DevExpress.ExpressApp.Validation.Web.ValidationAspNetModule();
			this.module9 = new DevExpress.ExpressApp.HtmlPropertyEditor.Web.HtmlPropertyEditorAspNetModule();
			this.module10 = new DevExpress.ExpressApp.TreeListEditors.Web.TreeListEditorsAspNetModule();
			this.schedulerAspNetModule1 = new DevExpress.ExpressApp.Scheduler.Web.SchedulerAspNetModule();
			this.schedulerModuleBase1 = new DevExpress.ExpressApp.Scheduler.SchedulerModuleBase();
			this.scriptRecorderModuleBase1 = new DevExpress.ExpressApp.ScriptRecorder.ScriptRecorderModuleBase();
			this.scriptRecorderAspNetModule1 = new DevExpress.ExpressApp.ScriptRecorder.Web.ScriptRecorderAspNetModule();
			this.viewVariantsModule1 = new DevExpress.ExpressApp.ViewVariantsModule.ViewVariantsModule();
			this.conditionalAppearanceModule = new DevExpress.ExpressApp.ConditionalAppearance.ConditionalAppearanceModule();
			this.kpiModule = new DevExpress.ExpressApp.Kpi.KpiModule();
			this.chartModule = new DevExpress.ExpressApp.Chart.ChartModule();
			this.chartAspNetModule = new DevExpress.ExpressApp.Chart.Web.ChartAspNetModule();
			this.pivotGridModule = new DevExpress.ExpressApp.PivotGrid.PivotGridModule();
			this.pivotGridAspNetModule = new DevExpress.ExpressApp.PivotGrid.Web.PivotGridAspNetModule();
			this.stateMachine1 = new DevExpress.ExpressApp.StateMachine.StateMachineModule();
			this.reportsModule = new DevExpress.ExpressApp.ReportsV2.ReportsModuleV2();
			this.reportsAspNetModule = new DevExpress.ExpressApp.ReportsV2.Web.ReportsAspNetModuleV2();
            this.notificationsModule = new DevExpress.ExpressApp.Notifications.NotificationsModule();
            this.notificationsModuleWeb = new DevExpress.ExpressApp.Notifications.Web.NotificationsAspNetModule();
            this.officeModule = new DevExpress.ExpressApp.Office.OfficeModule();
            this.officeAspNetModule = new DevExpress.ExpressApp.Office.Web.OfficeAspNetModule();
            this.officeModule.RichTextMailMergeDataType = typeof(DevExpress.Persistent.BaseImpl.RichTextMailMergeData);
            this.mapsModuleWeb = new DevExpress.ExpressApp.Maps.Web.MapsAspNetModule();
            this.dashboardsModule = new DevExpress.ExpressApp.Dashboards.DashboardsModule();

            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			//
			// ReportsModule
			//
			this.reportsModule.ReportDataType = typeof(DevExpress.Persistent.BaseImpl.ReportDataV2);
            this.reportsModule.ReportStoreMode = DevExpress.ExpressApp.ReportsV2.ReportStoreModes.XML;
            this.reportsAspNetModule.ReportViewerType = DevExpress.ExpressApp.ReportsV2.Web.ReportViewerTypes.HTML5;
            //
            // mapsModule
            //
            this.mapsModuleWeb.GoogleApiKey = "AIzaSyDk2m6n8ICK7FSmTHBLlapAWF3epiDdkHE";
            dashboardsModule.HideDirectDataSourceConnections = true;
            // 
            // FeatureCenterAspNetApplication
            // 
            this.CheckCompatibilityType = DevExpress.ExpressApp.CheckCompatibilityType.DatabaseSchema;
            this.DatabaseUpdateMode = DatabaseUpdateMode.UpdateDatabaseAlways;
            this.ApplicationName = "FeatureCenter";
			this.Modules.Add(this.module1);
			this.Modules.Add(this.module2);
			this.Modules.Add(this.viewVariantsModule1);
			this.Modules.Add(this.module3);
			this.Modules.Add(this.module4);
			//this.Modules.Add(this.module5);
			this.Modules.Add(this.module6);
			this.Modules.Add(this.module7);
			this.Modules.Add(this.module8);
            this.Modules.Add(this.validationAspNetModule);
			this.Modules.Add(this.module9);
			this.Modules.Add(this.module10);
			this.Modules.Add(this.schedulerModuleBase1);
			this.Modules.Add(this.schedulerAspNetModule1);
			this.Modules.Add(this.scriptRecorderModuleBase1);
			this.Modules.Add(this.scriptRecorderAspNetModule1);
			this.Modules.Add(this.conditionalAppearanceModule);
			this.Modules.Add(this.kpiModule);
			this.Modules.Add(this.chartModule);
			this.Modules.Add(this.chartAspNetModule);
			this.Modules.Add(this.pivotGridModule);
			this.Modules.Add(this.pivotGridAspNetModule);
			this.Modules.Add(this.stateMachine1);
			this.Modules.Add(this.reportsModule);
			this.Modules.Add(this.reportsAspNetModule);
            this.Modules.Add(this.notificationsModule);
            this.Modules.Add(this.notificationsModuleWeb);
            this.Modules.Add(this.officeModule);
            this.Modules.Add(this.officeAspNetModule);
            this.Modules.Add(this.mapsModuleWeb);
            this.Modules.Add(this.dashboardsModule);

            this.DatabaseVersionMismatch += new System.EventHandler<DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs>(this.FeatureCenterAspNetApplication_DatabaseVersionMismatch);
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();
		}
	}
}
