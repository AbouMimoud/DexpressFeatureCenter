using System;
using DevExpress.CodeParser;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Web.Editors.ASPx;
using DevExpress.Web.Internal;
using FeatureCenter.Module.DC;
using FeatureCenter.Module.PropertyEditors;
using DevExpress.Web;

namespace FeatureCenter.Module.Web.PropertyEditors {
    [PropertyEditor(typeof(string), FeatureCenterEditorAliases.CSCodePropertyEditor, false)]
    public class CSCodePropertyEditor : ASPxPropertyEditor {
        public CSCodePropertyEditor(Type objectType, DevExpress.ExpressApp.Model.IModelMemberViewItem model)
            : base(objectType, model) {
        }
        protected override void SetImmediatePostDataScript(string script) {
        }
        protected override void SetImmediatePostDataCompanionScript(string script) {
        }
        public override bool IsCaptionVisible {
            get { return false; }
        }
         protected override void ReadEditModeValueCore() {
             ((LabelControl)Editor).Text = DevExpress.Web.Demos.CodeFormatter.GetFormattedCode(TokenLanguage.CSharp, (string)PropertyValue);
        }
        protected override void ReadViewModeValueCore() {
            ((LabelControl)InplaceViewModeEditor).Text = DevExpress.Web.Demos.CodeFormatter.GetFormattedCode(TokenLanguage.CSharp, (string)PropertyValue);
        }
        protected override System.Web.UI.WebControls.WebControl CreateEditModeControlCore() {
            return new LabelControl(new ASPxLabel());// T297426 , T360546
        }
        protected override System.Web.UI.WebControls.WebControl CreateViewModeControlCore() {
            return new LabelControl(new ASPxLabel());// T297426 , T360546
        }
    }
}
