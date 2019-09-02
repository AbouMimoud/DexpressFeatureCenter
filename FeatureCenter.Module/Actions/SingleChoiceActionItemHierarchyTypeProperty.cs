//using System;
//using System.Collections.Generic;
//using System.Text;
//using DevExpress.ExpressApp.Actions;
//using DevExpress.Persistent.Base;
//using DevExpress.Xpo;
//using DevExpress.ExpressApp;

//namespace FeatureCenter.Module.Actions {
//    public class HierarchyTypeListController : ActionBaseController {
//        public HierarchyTypeListController() {
//            SingleChoiceAction singleChoiceAction = new SingleChoiceAction(this, "HierarchyTypeList", PredefinedCategory.RecordEdit);
//            singleChoiceAction.Execute += new SingleChoiceActionExecuteEventHandler(SingleChoiceActionRootObject.singleChoiceAction_Execute);
//            SingleChoiceActionRootObject.CreateDefaultItems(singleChoiceAction);
//            singleChoiceAction.ItemType = SingleChoiceActionItemType.ItemIsOperation;
//            singleChoiceAction.ItemHierarchyType = ChoiceActionItemHierarchyType.List;
//            singleChoiceAction.Caption = ActionsDemoStrings.HierarchyTypeList;
//            singleChoiceAction.ToolTip = ActionsDemoStrings.SingleChoiceActionHierarchyTypeListTooltip;
//        }
//    }

//    public class HierarchyTypeTreeController : ActionBaseController {
//        public HierarchyTypeTreeController() {
//            SingleChoiceAction singleChoiceAction = new SingleChoiceAction(this, "HierarchyTypeTree", PredefinedCategory.RecordEdit);
//            singleChoiceAction.Execute += new SingleChoiceActionExecuteEventHandler(SingleChoiceActionRootObject.singleChoiceAction_Execute);
//            SingleChoiceActionRootObject.CreateDefaultItems(singleChoiceAction);
//            singleChoiceAction.ItemType = SingleChoiceActionItemType.ItemIsOperation;
//            singleChoiceAction.ItemHierarchyType = ChoiceActionItemHierarchyType.Tree;
//            singleChoiceAction.Caption = ActionsDemoStrings.HierarchyTypeTree;
//            singleChoiceAction.ToolTip = ActionsDemoStrings.SingleChoiceActionHierarchyTypeTreeTooltip;
//        }
//    }

//}
