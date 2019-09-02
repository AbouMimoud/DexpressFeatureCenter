using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Web.Editors.ASPx;
using FeatureCenter.Module.PropertyEditors;

namespace FeatureCenter.Module.Web.PropertyEditors {
    public class CriteriaEditorController : ObjectViewController<DetailView, CriteriaProperties> {
        protected override void OnActivated() {
            base.OnActivated();
            ASPxCriteriaPropertyEditor hierarchyCriteriaPropertyEditor = View.FindItem("CriteriaWithNestedProperties") as ASPxCriteriaPropertyEditor;
            if(hierarchyCriteriaPropertyEditor != null) {
                hierarchyCriteriaPropertyEditor.AllowFilterControlHierarchy = true;
                hierarchyCriteriaPropertyEditor.MaxHierarchyDepth = 4;
            }
        }
    }
}
