using System;

using DevExpress.Xpo;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Updating;
using DevExpress.ExpressApp.Xpo;

using FeatureCenter.Module.Web.PropertyEditors;
using FeatureCenter.Module.PropertyEditors;
using FeatureCenter.Module.Web.Layout;

namespace FeatureCenter.Module.Web
{
    public class Updater : ModuleUpdater
    {
        public Updater(IObjectSpace objectSpace, Version currentDBVersion) : base(objectSpace, currentDBVersion) { }
        public override void UpdateDatabaseAfterUpdateSchema()
        {
            base.UpdateDatabaseAfterUpdateSchema();

			if(ObjectSpace is XPObjectSpace) {
				CreateStringInSpecialFormatPropertiesObjects();
				CreateLayoutItemTemplatesObjects();
			}

            ObjectSpace.CommitChanges();
        }

		private void CreateStringInSpecialFormatPropertiesObjects() {
			if(ObjectSpace.FindObject<WebStringInSpecialFormatPropertiesObject>(null) == null) {
				WebStringInSpecialFormatPropertiesObject stringPropertiesObject = ObjectSpace.CreateObject<WebStringInSpecialFormatPropertiesObject>();
				stringPropertiesObject.Name = "Object 1";
				stringPropertiesObject.HtmlStringProperty = "<h1>String Property</h1><p>with <font color=\"red\" size=\"5\">HTML</font> <strong>formatting</strong></p>";
				stringPropertiesObject.Save();
			}
		}
		private void CreateLayoutItemTemplatesObjects() {
            if(ObjectSpace.FindObject<ItemTemplates>(null) == null) {
				ItemTemplates itemTemplates = ObjectSpace.CreateObject<ItemTemplates>();
				itemTemplates.Name = "Object 1";
				itemTemplates.Save();
			}
		}
	}
}
