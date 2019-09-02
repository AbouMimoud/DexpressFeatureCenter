using System;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Win.Editors;
using DevExpress.Utils;
using DevExpress.XtraEditors.Repository;
using FeatureCenter.Module.PropertyEditors;

namespace FeatureCenter.Module.Win.PropertyEditors {
    [PropertyEditor(typeof(DateTime), FeatureCenterEditorAliases.CustomDateTimeEditor, false)]
    public class CustomDateTimeEditor : DatePropertyEditor {
        public CustomDateTimeEditor(Type objectType, IModelMemberViewItem info) : base(objectType, info) { }

        protected override void SetupRepositoryItem(RepositoryItem item) {
            base.SetupRepositoryItem(item);
            RepositoryItemDateTimeEdit dateProperties = (RepositoryItemDateTimeEdit)item;
            dateProperties.CalendarTimeEditing = DefaultBoolean.True;
            dateProperties.CalendarView = CalendarView.Vista;
        }
    }
}
