using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Demos;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace FeatureCenter.Module.Actions {

	[NonPersistent]
	[ImageName(ActionsDemoStrings.SingleChoiceActionImageName)]
	[NavigationItem(ActionsDemoStrings.NavBarGroupName)]
	[System.ComponentModel.DisplayName(ActionsDemoStrings.SingleChoiceAction)]
	[Hint(Hints.SingleChoiceActionHint, ViewType.DetailView)]
	public class SingleChoiceActionRootObject : ActionBaseRootObject {
		private SingleChoiceAction isOperation = new SingleChoiceAction();
		private SingleChoiceAction isMode = new SingleChoiceAction();
		private SingleChoiceAction htTree = new SingleChoiceAction();
		private SingleChoiceAction htList = new SingleChoiceAction();
		private SingleChoiceAction scaConstructor = new SingleChoiceAction();
		public static void singleChoiceAction_Execute(object sender, SingleChoiceActionExecuteEventArgs e) {
			if(((ActionBase)sender).Controller is ActionBaseController) {
				((ActionBaseController)((ActionBase)sender).Controller).LogTrace(e.Action, e.SelectedChoiceActionItem.Caption);
			}
		}
        public static void CreateDefaultItems(SingleChoiceAction singleChoiceAction) {
            CreateDefaultItems(singleChoiceAction, false);
        }
        public static void CreateDefaultItems(SingleChoiceAction singleChoiceAction, bool isActionHierarchical) {
			ChoiceActionItem itemA = new ChoiceActionItem(ActionsDemoStrings.ItemA, null);
			ChoiceActionItem itemB = new ChoiceActionItem(ActionsDemoStrings.ItemB, null);
			ChoiceActionItem itemC = new ChoiceActionItem(ActionsDemoStrings.ItemC, null);
            if (isActionHierarchical) {
                itemA.Items.Add(new ChoiceActionItem(ActionsDemoStrings.ItemA + "1", null));
                itemA.Items.Add(new ChoiceActionItem(ActionsDemoStrings.ItemA + "2", null));
                itemA.Items.Add(new ChoiceActionItem(ActionsDemoStrings.ItemA + "3", null));
                itemB.Items.Add(new ChoiceActionItem(ActionsDemoStrings.ItemB + "1", null));
                itemB.Items.Add(new ChoiceActionItem(ActionsDemoStrings.ItemB + "2", null));
                itemC.Items.Add(new ChoiceActionItem(ActionsDemoStrings.ItemC + "1", null));
                itemC.Items.Add(new ChoiceActionItem(ActionsDemoStrings.ItemC + "2", null));
                itemC.Items.Add(new ChoiceActionItem(ActionsDemoStrings.ItemC + "3", null));
                itemC.Items.Add(new ChoiceActionItem(ActionsDemoStrings.ItemC + "4", null));
            }
			singleChoiceAction.Items.Add(itemA);
			singleChoiceAction.Items.Add(itemB);
			singleChoiceAction.Items.Add(itemC);
		}
        [ModelDefault(CustomDetailViewItemsGenarator.TabPageNameAttribute, "ItemType")]
        [Index(50)]
        [ModelDefault(CustomDetailViewItemsGenarator.VisiblePropertiesAttribute, "ItemType")]
        public SingleChoiceAction ItemIsOperation {
            get { return isOperation; }
        }
        [ModelDefault(CustomDetailViewItemsGenarator.TabPageNameAttribute, "ItemType")]
        [Index(40)]
        [ModelDefault(CustomDetailViewItemsGenarator.VisiblePropertiesAttribute, "ItemType")]
        public SingleChoiceAction ItemIsMode {
			get { return isMode; }
		}
        [ModelDefault("VisibleProperties", "Caption, ToolTip, ImageName, ItemType")]
		public SingleChoiceAction SingleChoiceAction {
			get { return scaConstructor; }
		}
	}

}
