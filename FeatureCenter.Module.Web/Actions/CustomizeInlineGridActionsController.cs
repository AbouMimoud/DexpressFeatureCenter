using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Web.Editors.ASPx;
using DevExpress.ExpressApp.Web.SystemModule;
using DevExpress.ExpressApp.Web.Templates.ActionContainers.Menu;
using DevExpress.Web;
using FeatureCenter.Module.Actions;
using FeatureCenter.Module.Actions.CustomizeAction;

namespace FeatureCenter.Module.Web.Actions {
    public class CustomizeInlineGridActionsController : DisableControllersByConditionViewController {
        public SimpleAction AppearanceInlineGridAction { get; set; }
        public SimpleAction CaptionInlineGridAction { get; set; }

        private MenuItem menuItem = null;
        private string defaultCaption = "CustomizeCaption";

        public CustomizeInlineGridActionsController() {
            controllersToDeactivate.Add(typeof(ListViewController));     

            TargetObjectType = typeof(CustomizeInlineGridActionControl);
            TargetViewType = ViewType.ListView;                

            AppearanceInlineGridAction = new SimpleAction(this, "Appearance", DevExpress.Persistent.Base.PredefinedCategory.RecordEdit);
            AppearanceInlineGridAction.SelectionDependencyType = SelectionDependencyType.RequireSingleObject;
            
            CaptionInlineGridAction = new SimpleAction(this, "CustomCaption", DevExpress.Persistent.Base.PredefinedCategory.RecordEdit);
            CaptionInlineGridAction.SelectionDependencyType = SelectionDependencyType.RequireSingleObject;

            CaptionInlineGridAction.CustomizeControl += CaptionInlineGridAction_CustomizeControl;
            AppearanceInlineGridAction.CustomizeControl += AppearanceInlineGridAction_CustomizeControl;
        }
        protected override void OnActivated() {
            base.OnActivated();
            View.SelectionChanged += View_SelectionChanged;            
        }
        protected override void OnDeactivated() {
            View.SelectionChanged -= View_SelectionChanged;            
            base.OnDeactivated();
        }
        private void AppearanceInlineGridAction_CustomizeControl(object sender, CustomizeControlEventArgs e) {
            ASPxGridViewCustomButtonInitializer initializer = e.Control as ASPxGridViewCustomButtonInitializer;
            if(initializer != null) {
                initializer.Styles.Style.ForeColor = System.Drawing.Color.Red;
                initializer.Styles.Style.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Right;
                initializer.Styles.Style.Font.Underline = false;
            }
        }
        private void CaptionInlineGridAction_CustomizeControl(object sender, CustomizeControlEventArgs e) {
            // Inline Grid Action
            ASPxGridViewCustomButtonInitializer initializer = e.Control as ASPxGridViewCustomButtonInitializer;
            if(initializer != null) {
                initializer.Text = string.Format("{0} - {1}", defaultCaption, ((CustomizeInlineGridActionControl)initializer.CurrentObject).Caption);
            }
            else {
                // Inside ActionContainerHolder
                SimpleActionMenuActionItem actionItem = e.Control as SimpleActionMenuActionItem;
                if(actionItem != null) {
                    menuItem = actionItem.MenuItem;                    
                }
            }
        }
        private void View_SelectionChanged(object sender, EventArgs e) {
            if(CaptionInlineGridAction.Enabled.ResultValue && View.SelectedObjects.Count == 1 && menuItem != null) {
                string caption = string.Format("{0} - {1}", defaultCaption, ((CustomizeInlineGridActionControl)View.SelectedObjects[0]).Caption);
                menuItem.Text = caption;
                menuItem.AdaptiveText = caption;
            }
        }
        protected override bool GetIsDisabled() {
            return true;
        }
    }
}
