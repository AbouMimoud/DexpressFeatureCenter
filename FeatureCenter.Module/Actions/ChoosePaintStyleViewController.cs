using System;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Editors;

namespace FeatureCenter.Module.Actions {
    public class ChoosePaintStyleViewController : ViewController<DetailView> {
        private SingleChoiceAction choosePaintStyleAction;
        private void choosePaintStyleAction_Execute(object sender, SingleChoiceActionExecuteEventArgs e) {
            if(View != null) {
                ISupportUpdate supportUpdate = View.LayoutManager.Container as ISupportUpdate;
                if(supportUpdate != null) {
                    supportUpdate.BeginUpdate();
                }
                foreach(ActionContainerViewItem viewItem in View.GetItems<ActionContainerViewItem>()) {
                    foreach(ActionBase action in viewItem.Actions) {
                        action.PaintStyle = (ActionItemPaintStyle)e.SelectedChoiceActionItem.Data;
                    }
                }
                if(supportUpdate != null) {
                    supportUpdate.EndUpdate();
                }
            }
        }
        public ChoosePaintStyleViewController() : base() {
            TargetObjectType = typeof(DetailViewActionsObject);

            choosePaintStyleAction = new SingleChoiceAction(this, "ChoosePaintStyle", DevExpress.Persistent.Base.PredefinedCategory.View);
            choosePaintStyleAction.PaintStyle = ActionItemPaintStyle.Caption;
            choosePaintStyleAction.ItemType = SingleChoiceActionItemType.ItemIsMode;
            choosePaintStyleAction.Items.Add(new ChoiceActionItem("Image", ActionItemPaintStyle.Image));
            choosePaintStyleAction.Items.Add(new ChoiceActionItem("Caption", ActionItemPaintStyle.Caption));
            choosePaintStyleAction.Items.Add(new ChoiceActionItem("CaptionAndImage", ActionItemPaintStyle.CaptionAndImage));
            choosePaintStyleAction.SelectedIndex = 2;
            choosePaintStyleAction.Execute += new SingleChoiceActionExecuteEventHandler(choosePaintStyleAction_Execute);
        }
    }
}
