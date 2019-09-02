using System;
using System.Web.UI.WebControls;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Web.Editors.ASPx;
using DevExpress.Web;
using FeatureCenter.Module.PropertyEditors;

namespace FeatureCenter.Module.Web.PropertyEditors {
    [PropertyEditor(typeof(DateTime), FeatureCenterEditorAliases.CustomDateTimeEditor, false)]
    public class CustomDateTimeEditor : ASPxDateTimePropertyEditor {
        public CustomDateTimeEditor(Type objectType, IModelMemberViewItem info) : base(objectType, info) { }

        protected override void SetupControl(WebControl control) {
            base.SetupControl(control);
            if(ViewEditMode == ViewEditMode.Edit) {
                ASPxDateEdit dateEdit = (ASPxDateEdit)control;
                dateEdit.TimeSectionProperties.Visible = true;
                dateEdit.UseMaskBehavior = true;
            }
        }
    }
}
