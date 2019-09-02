using System;
using System.Globalization;

using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Win.Editors;

using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using FeatureCenter.Module.PropertyEditors;
using DevExpress.ExpressApp.Model;

namespace FeatureCenter.Module.Win.PropertyEditors {
	[PropertyEditor(typeof(String), FeatureCenterEditorAliases.CustomStringEditor, false)]
    public class CustomStringEditor : StringPropertyEditor {
        public CustomStringEditor(Type objectType, IModelMemberViewItem info)
            : base(objectType, info) {
        }

        protected override object CreateControlCore() {
            return new ComboBoxEdit();
        }

        protected override RepositoryItem CreateRepositoryItem() {
            return new RepositoryItemComboBox();
        }

        protected override void SetupRepositoryItem(DevExpress.XtraEditors.Repository.RepositoryItem item) {
            base.SetupRepositoryItem(item);
            foreach(CultureInfo culture in CultureInfo.GetCultures(CultureTypes.InstalledWin32Cultures)) {
                ((RepositoryItemComboBox)item).Items.Add(culture.EnglishName + "(" + culture.Name + ")");
            }
            ((RepositoryItemComboBox)item).TextEditStyle = TextEditStyles.DisableTextEditor;
        }
    }
}
