using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Web;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Web.SystemModule;

namespace FeatureCenter.Module.Web {
	public class ShowViewStrategyDetailViewController : DevExpress.ExpressApp.Web.SystemModule.WebModificationsController {
        private bool needResetCollectionsEditMode = false;
        protected override void OnActivated() {
            base.OnActivated();
            if(View.CurrentObject is FeatureCenter.Module.Validation.ValidationDemoBaseObject               
                || View.CurrentObject is FeatureCenter.Module.ConditionalAppearance.ConditionalAppearanceDisableEnableEditorsObject
                || View.CurrentObject is DevExpress.ExpressApp.DC.DCBaseObject) {

                    IModelOptionsWeb modelOptions = (IModelOptionsWeb)Application.Model.Options;
                    if(modelOptions.CollectionsEditMode != DevExpress.ExpressApp.Editors.ViewEditMode.Edit) {
                        modelOptions.CollectionsEditMode = DevExpress.ExpressApp.Editors.ViewEditMode.Edit;

                    UpdateListPropertyEditors();

                    needResetCollectionsEditMode = true;
                }
            }
        }
		protected override void OnDeactivated() {
			base.OnDeactivated();
            if(needResetCollectionsEditMode) {
                ((IModelOptionsWeb)Application.Model.Options).CollectionsEditMode = DevExpress.ExpressApp.Editors.ViewEditMode.View;
                needResetCollectionsEditMode = false;
            }
        }
    }
}
