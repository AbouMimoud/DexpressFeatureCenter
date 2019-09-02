using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Web.Editors.ASPx;
using DevExpress.ExpressApp.Web.Templates.ActionContainers;
using DevExpress.ExpressApp.Web.Templates.ActionContainers.Menu;
using DevExpress.Persistent.Base;
using DevExpress.Web;
using FeatureCenter.Module.Actions;
using FeatureCenter.Module.Actions.CustomizeAction;

namespace FeatureCenter.Module.Web.Actions {
    public class CustomizeMenuActionsController : DisableControllersByConditionViewController  {

        public ParametrizedAction CustomStringParametrizedAction { get; set; }
        public ParametrizedAction CustomDateParametrizedAction { get; set; }
        public SingleChoiceAction CustomizeWidthSingleChoiceAction { get; set; }
        public SimpleAction ClientClickScriptViaCustomizeControl { get; set; }
        public SimpleAction ClientClickScriptViaExtentionsSimpleAction { get; set; }

        public CustomizeMenuActionsController() {
            TargetObjectType = typeof(CustomizeMenuActionControl);
            TargetViewType = ViewType.DetailView;
            
            CustomStringParametrizedAction = new ParametrizedAction(this, "StringEditMask", PredefinedCategory.RecordEdit, typeof(string));
            CustomStringParametrizedAction.PaintStyle = DevExpress.ExpressApp.Templates.ActionItemPaintStyle.Image;
            CustomStringParametrizedAction.ToolTip = "String Edit Mask Customize";
            CustomDateParametrizedAction = new ParametrizedAction(this, "DateTimeEditMask", PredefinedCategory.RecordEdit, typeof(DateTime));
            CustomDateParametrizedAction.ToolTip = "DateTime Edit Mask Customize";
            CustomDateParametrizedAction.PaintStyle = DevExpress.ExpressApp.Templates.ActionItemPaintStyle.Image;

            CustomizeWidthSingleChoiceAction = new SingleChoiceAction(this, "CustomWidth", PredefinedCategory.Reports);
            CustomizeWidthSingleChoiceAction.Items.Add(new ChoiceActionItem("First", null));
            CustomizeWidthSingleChoiceAction.Items.Add(new ChoiceActionItem("Second", null));
            CustomizeWidthSingleChoiceAction.Items.Add(new ChoiceActionItem("Third", null));


            ClientClickScriptViaCustomizeControl = new SimpleAction(this, "ClientScriptOnEvent", PredefinedCategory.Reports);
            ClientClickScriptViaCustomizeControl.ToolTip = "Client click script is edit using ActionBase.CustomizeControl event";

            ClientClickScriptViaExtentionsSimpleAction = new SimpleAction(this, "ClientScript", PredefinedCategory.Reports);
            ClientClickScriptViaExtentionsSimpleAction.ToolTip = "Client click script is edit using extention";
            ClientClickScriptViaExtentionsSimpleAction.SetClientScript("alert('Clicked!');", false);    
        
            CustomStringParametrizedAction.CustomizeControl += CustomStringParametrizedAction_CustomizeControl;
            CustomDateParametrizedAction.CustomizeControl += CustomDateParametrizedAction_CustomizeControl;
            CustomizeWidthSingleChoiceAction.CustomizeControl += CustomizeWidthSingleChoiceAction_CustomizeControl;
            ClientClickScriptViaCustomizeControl.CustomizeControl += ClientClickScriptViaCustomizeControl_CustomizeControl;
        }
        private void CustomDateParametrizedAction_CustomizeControl(object sender, CustomizeControlEventArgs e) {
            ParametrizedActionMenuActionItem actionItem = e.Control as ParametrizedActionMenuActionItem;
            if(actionItem != null) {
                ASPxDateEdit editor = actionItem.Control.Editor as ASPxDateEdit;
                if(editor != null) {
                    editor.Width = 250;
                    editor.Date = DateTime.Now;
                    editor.EditFormat = EditFormat.DateTime;
                    editor.EditFormatString = "MM/dd/yyyy hh:mm:ss";
                    editor.DisplayFormatString = "{0:MM/dd/yyyy hh:mm:ss}";
                    
                }
            }
        }
        private void CustomStringParametrizedAction_CustomizeControl(object sender, CustomizeControlEventArgs e) {
            ParametrizedActionMenuActionItem actionItem = e.Control as ParametrizedActionMenuActionItem;
            if(actionItem != null) {
                ASPxButtonEdit editor = actionItem.Control.Editor as ASPxButtonEdit;
                if(editor != null) {
                    editor.Width = 200;
                    editor.ValidationSettings.Display = Display.None;
                    editor.MaskSettings.Mask = "(000)000-00-00";                                        
                    editor.ClientSideEvents.ValueChanged = @"function(s, e){                            
                        s.GetInputElement().style.backgroundColor = 'yellow';
                    }";
                }
            }
        }
        private void CustomizeWidthSingleChoiceAction_CustomizeControl(object sender, CustomizeControlEventArgs e) {
            SingleChoiceActionAsModeMenuActionItem actionItem = e.Control as SingleChoiceActionAsModeMenuActionItem;
            if(actionItem != null) {                
                ((DropDownSingleChoiceActionControlBase)actionItem.Control).ComboBox.Width = System.Web.UI.WebControls.Unit.Pixel(60);
            }
        }
        private void ClientClickScriptViaCustomizeControl_CustomizeControl(object sender, CustomizeControlEventArgs e) {
            ClickableMenuActionItem actionItem = e.Control as ClickableMenuActionItem;
            if(actionItem != null) {
                actionItem.ClientClickScript = "alert('Clicked!');";
                actionItem.ProcessOnServer = false; // cancel server-side processing
            }
        }

        protected override bool GetIsDisabled() {
            return true;
        }
    }
}
