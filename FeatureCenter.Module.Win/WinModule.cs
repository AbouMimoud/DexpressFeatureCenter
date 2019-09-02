using System;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Demos;
using DevExpress.ExpressApp.Demos.Win;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Updating;
using DevExpress.Persistent.AuditTrail;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using FeatureCenter.Module.Win.Templates;

namespace FeatureCenter.Module.Win
{
    [ToolboxItemFilter("Xaf.Platform.Win")]
    public sealed partial class FeatureCenterWindowsFormsModule : ModuleBase
    {
        private void AuditTrailServiceInstance_CustomizeAuditTrailSettings(object sender, CustomizeAuditTrailSettingsEventArgs e) {
            e.AuditTrailSettings.AddType(typeof(FeatureCenter.Module.Win.Audit.FullyAuditedBatchCreationObject), true);
            e.AuditTrailSettings.AddType(typeof(FeatureCenter.Module.Win.Audit.PartiallyAuditedBatchCreationObject), true);
        }

		public FeatureCenterWindowsFormsModule()
        {
            InitializeComponent();
        }
        public override ICollection<Type> GetXafResourceLocalizerTypes() {
			ICollection<Type> result = new List<Type>();
            result.Add(typeof(FeatureCenterMainFormTemplateLocalizer));
            result.Add(typeof(FeatureCenterDetailFormTemplateLocalizer));
            result.Add(typeof(FeatureCenterMainRibbonFormTemplateLocalizer));
            result.Add(typeof(FeatureCenterDetailRibbonFormTemplateLocalizer));
            return result;
        }
        public override void CustomizeTypesInfo(DevExpress.ExpressApp.DC.ITypesInfo typesInfo) {
			base.CustomizeTypesInfo(typesInfo);
			typesInfo.FindTypeInfo(typeof(ImageSourceBrowserBase)).AddAttribute(new HintAttribute("", ViewType.Any, "Hint"));
            DevExpress.ExpressApp.DC.IMemberInfo hintMember = typesInfo.FindTypeInfo(typeof(ImageSourceBrowserBase)).CreateMember("Hint", typeof(string));
            hintMember.AddAttribute(new SizeAttribute(1024));
        }
        public override void Setup(XafApplication application) {
            base.Setup(application);
            AuditTrailService.Instance.CustomizeAuditTrailSettings += new CustomizeAuditSettingsEventHandler(AuditTrailServiceInstance_CustomizeAuditTrailSettings);
        }
        protected override void RegisterEditorDescriptors(EditorDescriptorsFactory editorDescriptorsFactory) {
            base.RegisterEditorDescriptors(editorDescriptorsFactory);
            editorDescriptorsFactory.RegisterListEditorAlias("Thumbnail", typeof(IPictureItem), true);
            editorDescriptorsFactory.RegisterListEditor("Thumbnail", typeof(IPictureItem), typeof(WinThumbnailEditor), true);
        }
        public override IEnumerable<ModuleUpdater> GetModuleUpdaters(IObjectSpace objectSpace, Version versionFromDB) {
            ModuleUpdater updater = new Updater(objectSpace, versionFromDB);
            return new ModuleUpdater[] { updater };
        }
    }
}
