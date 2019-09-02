using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.Persistent.Base;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using FeatureCenter.Module.Actions;
using FeatureCenter.Module.Actions.CustomizeAction;

namespace FeatureCenter.Module.Win.Actions {

    public class CustomizeParametrizedActionController : DisableControllersByConditionViewController {
        private int ScaledWidth(int width) {
            int result = width;
            Size systemDPI = DevExpress.Utils.ScaleUtils.GetSystemDPI();
            if(systemDPI.Width != 96) {
                result = (int)(result * systemDPI.Width / 96f);
            }
            return result;
        }
        public ParametrizedAction CustomStringParametrizedAction { get; set; }
        public ParametrizedAction CustomDateParametrizedAction { get; set; }
        public SingleChoiceAction CustomizeWidthSingleChoiceAction { get; set; }
        public SimpleAction ItemClickSimpleAction = null;
        protected override bool GetIsDisabled() {
            return true;
        }
        public CustomizeParametrizedActionController()
            : base() {
            TargetObjectType = typeof(CustomizeActionControlObject);

            ItemClickSimpleAction = new SimpleAction(this, "ItemClick", PredefinedCategory.RecordEdit);
            CustomStringParametrizedAction = new ParametrizedAction(this, "StringEditMask", PredefinedCategory.RecordEdit, typeof(string));
            CustomStringParametrizedAction.ToolTip = "String Edit Mask Customize";
            CustomizeWidthSingleChoiceAction = new SingleChoiceAction(this, "CustomWidth", PredefinedCategory.View);
            CustomizeWidthSingleChoiceAction.Items.Add(new ChoiceActionItem("First", null));
            CustomizeWidthSingleChoiceAction.Items.Add(new ChoiceActionItem("Second", null));
            CustomizeWidthSingleChoiceAction.Items.Add(new ChoiceActionItem("Third", null));
            CustomDateParametrizedAction = new ParametrizedAction(this, "DateTimeEditMask", PredefinedCategory.View, typeof(DateTime));
            CustomDateParametrizedAction.ToolTip = "DateTime Edit Mask Customize";           

            CustomizeWidthSingleChoiceAction.CustomizeControl += CustomizeWidthSingleChoiceAction_CustomizeControl;
            ItemClickSimpleAction.CustomizeControl += ItemClickSimpleAction_CustomizeControl;
            CustomStringParametrizedAction.CustomizeControl += CustomStringParametrizedAction_CustomizeControl;
            CustomDateParametrizedAction.CustomizeControl += CustomDateParametrizedAction_CustomizeControl;
        }
        private void CustomDateParametrizedAction_CustomizeControl(object sender, CustomizeControlEventArgs e) {
            //Inside BarManager. 
            BarEditItem barItem = e.Control as BarEditItem;
            if(barItem != null) {
                RepositoryItemDateEdit repositoryItem = (RepositoryItemDateEdit)barItem.Edit;
                repositoryItem.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
                repositoryItem.Mask.EditMask = "MM/dd/yyyy hh:mm:ss";
                repositoryItem.Mask.UseMaskAsDisplayFormat = true;
                barItem.Width = 270; //BarManager scales controls itself
            }
            else {
                //Inside LayoutManager.
                ButtonEdit buttonEdit = e.Control as ButtonEdit;
                if(buttonEdit != null) {
                    buttonEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
                    buttonEdit.Properties.Mask.EditMask = "MM/dd/yyyy hh:mm:ss";
                    buttonEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
                    buttonEdit.MinimumSize = new Size(ScaledWidth(270), 0);
                }
            }
        }
        private void CustomStringParametrizedAction_CustomizeControl(object sender, CustomizeControlEventArgs e) {
            //Inside BarManager. 
            BarEditItem barItem = e.Control as BarEditItem;
            if(barItem != null) {
                RepositoryItemTextEdit repositoryItem = (RepositoryItemTextEdit)barItem.Edit;
                repositoryItem.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
                repositoryItem.Mask.EditMask = "(000)000-00-00";
                repositoryItem.Mask.UseMaskAsDisplayFormat = true;
                repositoryItem.EditValueChanged += repositoryItem_EditValueChanged;
                barItem.Width = 250; //BarManager scales controls itself
            }
            else {
                //Inside LayoutManager.
                ButtonEdit buttonEdit = e.Control as ButtonEdit;
                if(buttonEdit != null) {
                    buttonEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
                    buttonEdit.Properties.Mask.EditMask = "(000)000-00-00";
                    buttonEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
                    buttonEdit.MinimumSize = new Size(ScaledWidth(250), 0);
                    buttonEdit.EditValueChanged += repositoryItem_EditValueChanged;
                }
            }
        }
        private void repositoryItem_EditValueChanged(object sender, EventArgs e) {
            TextEdit textEdit = (TextEdit)sender;
            if(String.IsNullOrEmpty(textEdit.Text)) {
                textEdit.Properties.Appearance.BackColor = Color.White;
            }
            else {
                textEdit.Properties.Appearance.BackColor = Color.Yellow;
            }
        }
        private void CustomizeWidthSingleChoiceAction_CustomizeControl(object sender, CustomizeControlEventArgs e) {
            //Inside BarManager. 
            BarEditItem barItem = e.Control as BarEditItem;
            if(barItem != null) {
                barItem.Width = 60; //BarManager scales controls itself
            }
            else {
                //Inside LayoutManager.
                ImageComboBoxEdit comboBoxEdit = e.Control as ImageComboBoxEdit;
                if(comboBoxEdit != null) {
                    comboBoxEdit.MinimumSize = new Size(ScaledWidth(60), 0);
                }
            }
        }
        private void ItemClickSimpleAction_CustomizeControl(object sender, CustomizeControlEventArgs e) {
            //Inside BarManager. 
            BarButtonItem barItem = e.Control as BarButtonItem;
            if(barItem != null) {
                barItem.ItemClick += (s, args) => {
                    XtraMessageBox.Show("Item Clicked");
                };
            }
            else {
                //Inside LayoutManager.
                SimpleButton button = e.Control as SimpleButton;
                if(button != null) {
                    button.Click += (s, args) => {
                        XtraMessageBox.Show("Item Clicked");
                    };
                }
            }
        }
    }
}

