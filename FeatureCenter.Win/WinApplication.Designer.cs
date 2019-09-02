namespace FeatureCenter.Win
{
	partial class FeatureCenterWindowsFormsApplication
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.module1 = new DevExpress.ExpressApp.SystemModule.SystemModule();
            this.module2 = new DevExpress.ExpressApp.Win.SystemModule.SystemWindowsFormsModule();
			this.module3 = new FeatureCenter.Module.FeatureCenterModule();
			this.module4 = new FeatureCenter.Module.Win.FeatureCenterWindowsFormsModule();
			//this.module5 = new DevExpress.ExpressApp.Reports.Win.ReportsWindowsFormsModule();
			this.module6 = new DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule();
			this.module7 = new DevExpress.ExpressApp.FileAttachments.Win.FileAttachmentsWindowsFormsModule();
			this.module8 = new DevExpress.ExpressApp.Validation.Win.ValidationWindowsFormsModule();
			this.treeListEditorsWindowsFormsModule1 = new DevExpress.ExpressApp.TreeListEditors.Win.TreeListEditorsWindowsFormsModule();
			this.schedulerWindowsFormsModule1 = new DevExpress.ExpressApp.Scheduler.Win.SchedulerWindowsFormsModule();
			this.schedulerModuleBase1 = new DevExpress.ExpressApp.Scheduler.SchedulerModuleBase();
            this.scriptRecorderModuleBase1 = new DevExpress.ExpressApp.ScriptRecorder.ScriptRecorderModuleBase();
            this.scriptRecorderWindowsFormsModule1 = new DevExpress.ExpressApp.ScriptRecorder.Win.ScriptRecorderWindowsFormsModule();
            this.viewVariantsModule1 = new DevExpress.ExpressApp.ViewVariantsModule.ViewVariantsModule();
			this.conditionalAppearanceModule = new DevExpress.ExpressApp.ConditionalAppearance.ConditionalAppearanceModule();
			this.kpiModule = new DevExpress.ExpressApp.Kpi.KpiModule();
			this.chartModule = new DevExpress.ExpressApp.Chart.ChartModule();
			this.chartWindowsFormsModule = new DevExpress.ExpressApp.Chart.Win.ChartWindowsFormsModule();
			this.pivotGridModule = new DevExpress.ExpressApp.PivotGrid.PivotGridModule();
			this.pivotGridWindowsFormsModule = new DevExpress.ExpressApp.PivotGrid.Win.PivotGridWindowsFormsModule();
            this.stateMachine1 = new DevExpress.ExpressApp.StateMachine.StateMachineModule();
            this.reportsModule = new DevExpress.ExpressApp.ReportsV2.ReportsModuleV2();
            this.reportsWindowsFormsModule = new DevExpress.ExpressApp.ReportsV2.Win.ReportsWindowsFormsModuleV2();
            this.notificationsModule = new DevExpress.ExpressApp.Notifications.NotificationsModule();
            this.notificationsModuleWin = new DevExpress.ExpressApp.Notifications.Win.NotificationsWindowsFormsModule();
            this.dashboardsModule = new DevExpress.ExpressApp.Dashboards.DashboardsModule();
            this.dashboardsWindowsFormsModule = new DevExpress.ExpressApp.Dashboards.Win.DashboardsWindowsFormsModule();
            this.officeWindowsFormsModule = new DevExpress.ExpressApp.Office.Win.OfficeWindowsFormsModule();
            this.officeWindowsFormsModule.RichTextMailMergeDataType = typeof(DevExpress.Persistent.BaseImpl.RichTextMailMergeData);
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // dashboardsModule
            // 
            this.dashboardsModule.DashboardDataType = typeof(DevExpress.Persistent.BaseImpl.DashboardData);
            //
            // ReportsModule
            //
            this.reportsModule.ReportDataType = typeof(DevExpress.Persistent.BaseImpl.ReportDataV2);
            this.reportsModule.ReportStoreMode = DevExpress.ExpressApp.ReportsV2.ReportStoreModes.XML;
            // 
            // FeatureCenterWindowsFormsApplication
            // 
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
			this.Modules.Add(this.treeListEditorsWindowsFormsModule1);
			this.Modules.Add(this.schedulerModuleBase1);
			this.Modules.Add(this.schedulerWindowsFormsModule1);
            this.Modules.Add(this.scriptRecorderModuleBase1);
            this.Modules.Add(this.scriptRecorderWindowsFormsModule1);
			this.Modules.Add(this.conditionalAppearanceModule);
			this.Modules.Add(this.kpiModule);
			this.Modules.Add(this.chartModule);
			this.Modules.Add(this.dashboardsModule);
			this.Modules.Add(this.chartWindowsFormsModule);
			this.Modules.Add(this.pivotGridModule);
			this.Modules.Add(this.pivotGridWindowsFormsModule);
            this.Modules.Add(this.stateMachine1);
            this.Modules.Add(this.reportsModule);
            this.Modules.Add(this.reportsWindowsFormsModule);
            this.Modules.Add(this.notificationsModule);
            this.Modules.Add(this.notificationsModuleWin);
            this.Modules.Add(this.dashboardsWindowsFormsModule);
            this.Modules.Add(this.officeWindowsFormsModule);
            this.UseOldTemplates = false;
			this.DatabaseVersionMismatch += new System.EventHandler<DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs>(this.FeatureCenterWindowsFormsApplication_DatabaseVersionMismatch);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
        }

        #endregion

        private DevExpress.ExpressApp.SystemModule.SystemModule module1;
        private DevExpress.ExpressApp.Win.SystemModule.SystemWindowsFormsModule module2;
		private FeatureCenter.Module.FeatureCenterModule module3;
		private FeatureCenter.Module.Win.FeatureCenterWindowsFormsModule module4;
		//private DevExpress.ExpressApp.Reports.Win.ReportsWindowsFormsModule module5;
		private DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule module6;
		private DevExpress.ExpressApp.FileAttachments.Win.FileAttachmentsWindowsFormsModule module7;
		private DevExpress.ExpressApp.Validation.Win.ValidationWindowsFormsModule module8;
		private DevExpress.ExpressApp.TreeListEditors.Win.TreeListEditorsWindowsFormsModule treeListEditorsWindowsFormsModule1;
		private DevExpress.ExpressApp.Scheduler.Win.SchedulerWindowsFormsModule schedulerWindowsFormsModule1;
		private DevExpress.ExpressApp.Scheduler.SchedulerModuleBase schedulerModuleBase1;
		private DevExpress.ExpressApp.ConditionalAppearance.ConditionalAppearanceModule conditionalAppearanceModule;
		private DevExpress.ExpressApp.ScriptRecorder.Win.ScriptRecorderWindowsFormsModule scriptRecorderWindowsFormsModule1;
        private DevExpress.ExpressApp.ScriptRecorder.ScriptRecorderModuleBase scriptRecorderModuleBase1;
        private DevExpress.ExpressApp.ViewVariantsModule.ViewVariantsModule viewVariantsModule1;
		private DevExpress.ExpressApp.Kpi.KpiModule kpiModule;
		private DevExpress.ExpressApp.Chart.ChartModule chartModule;
		private DevExpress.ExpressApp.Chart.Win.ChartWindowsFormsModule chartWindowsFormsModule;
		private DevExpress.ExpressApp.PivotGrid.PivotGridModule pivotGridModule;
		private DevExpress.ExpressApp.PivotGrid.Win.PivotGridWindowsFormsModule pivotGridWindowsFormsModule;
        private DevExpress.ExpressApp.StateMachine.StateMachineModule stateMachine1;
        private DevExpress.ExpressApp.ReportsV2.ReportsModuleV2 reportsModule;
        private DevExpress.ExpressApp.ReportsV2.Win.ReportsWindowsFormsModuleV2 reportsWindowsFormsModule;
        private DevExpress.ExpressApp.Notifications.NotificationsModule notificationsModule;
        private DevExpress.ExpressApp.Notifications.Win.NotificationsWindowsFormsModule notificationsModuleWin;
        private DevExpress.ExpressApp.Dashboards.DashboardsModule dashboardsModule;
        private DevExpress.ExpressApp.Dashboards.Win.DashboardsWindowsFormsModule dashboardsWindowsFormsModule;
        private DevExpress.ExpressApp.Office.Win.OfficeWindowsFormsModule officeWindowsFormsModule;
    }
}
