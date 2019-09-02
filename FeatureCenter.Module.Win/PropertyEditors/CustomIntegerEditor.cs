using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Collections.Generic;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Editors;
using DevExpress.XtraEditors.Repository;
using DevExpress.ExpressApp.Win.Editors;
using FeatureCenter.Module.PropertyEditors;
using DevExpress.XtraLayout;
using System.ComponentModel;

namespace FeatureCenter.Module.Win.PropertyEditors {
	[PropertyEditor(typeof(Int32), FeatureCenterEditorAliases.CustomIntegerEditor, false)]
    public class CustomIntegerEditor : PropertyEditor, IInplaceEditSupport {
        private NumericUpDown control = null;
        protected override void ReadValueCore() {
            if(control != null) {
                if(CurrentObject != null) {
                    control.ReadOnly = false;
                    control.Value = (int)PropertyValue;
                }
                else {
                    control.ReadOnly = true;
                    control.Value = 0;
                }
            }
        }
        private void control_ValueChanged(object sender, EventArgs e) {
            //alternatively use the 'control.UserEdit' property to determine whether event occurs by an end-user changes or by code.
            //https://social.msdn.microsoft.com/Forums/windows/en-US/71c6237c-82fc-4f04-8caa-9cf83d6e9b1a/numericupdown-binding-and-the-tab-key?forum=winforms
            if(!IsValueReading) {
                OnControlValueChanged();
                WriteValueCore();
            }
        }
        protected override object CreateControlCore() {
            control = new NumericUpDown();
            control.Minimum = 0;
            control.Maximum = 5;
            control.ValueChanged += control_ValueChanged;
            ReadValue();
            return control;
		}
        public CustomIntegerEditor(Type objectType, IModelMemberViewItem info)
			: base(objectType, info) {
		}
        protected override void Dispose(bool disposing) {
            if(control != null) {
                control.ValueChanged -= control_ValueChanged;
                control = null;
            }
            base.Dispose(disposing);
        }
        RepositoryItem IInplaceEditSupport.CreateRepositoryItem() {
            RepositoryItemSpinEdit item = new RepositoryItemSpinEdit();
            item.MinValue = 0;
            item.MaxValue = 5;
            item.Mask.EditMask = "0";
            return item;
        }

        protected override object GetControlValueCore() {
            if(control != null) {
                return (int)control.Value;
            }
            return null;
        }
    }
}
