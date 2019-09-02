using System;

using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.SystemModule;
using FeatureCenter.Module.Skins;
using System.Collections.Generic;

namespace FeatureCenter.Module.Skins
{
    public abstract class SkinsWindowControllerBase<ChooseSkinControllerType> : WindowController where ChooseSkinControllerType : Controller
    {
        private void NavigationController_CustomShowNavigationItem(object sender, CustomShowNavigationItemEventArgs e) {
            ViewShortcut shortcut = e.ActionArguments.SelectedChoiceActionItem.Data as ViewShortcut;
            if(shortcut != null) {                
                ChoiceActionItem skinItem = ChooseSkinAction.Items.Find(shortcut["SkinID"], ChoiceActionItemFindType.Recursive, ChoiceActionItemFindTarget.Any);
                if(skinItem != null) {
                    ChooseSkinAction.DoExecute(skinItem);
                }
            }
        }
        private void NavigationController_CustomUpdateSelectNavigationItem(object sender, CustomUpdateSelectedItemEventArgs e) {
			if(e.ProposedSelectedItem != null) {
                if(e.ProposedSelectedItem.ParentItem != null && e.ProposedSelectedItem.ParentItem.Id == SkinsGroupCaption) {
					e.Handled = true;
				}
			}
        }        
        private void AddSkinNavigationItemsToGroup(ChoiceActionItemCollection items, ChoiceActionItem group) {
            foreach(ChoiceActionItem item in items) {
                ViewShortcut viewShortcut = new ViewShortcut(typeof(SkinDemoObject), null, Application.GetListViewId(typeof(SkinDemoObject)));
                viewShortcut.Add("SkinID", item.Id);
                ChoiceActionItem newItem = new ChoiceActionItem(item.Caption, item.Caption, viewShortcut);
                newItem.ImageName = ChooseSkinAction.ImageName;                
                group.Items.Add(newItem);
                AddSkinNavigationItemsToGroup(item.Items, newItem);
            }
        }
        private void CreateNavigationItems() {
            IEnumerable<ChoiceActionItem> skinsGroups = CreateSkinNavigationGroups();
            foreach(ChoiceActionItem skinsGroup in skinsGroups) {
                AddSkinNavigationItemsToGroup(ChooseSkinAction.Items, skinsGroup);                
            }
        }
        protected virtual IList<ChoiceActionItem> CreateSkinNavigationGroups() {
            List<ChoiceActionItem> result = new List<ChoiceActionItem>();
            ChoiceActionItem skinsGroup = new ChoiceActionItem(SkinsGroupCaption, SkinsGroupCaption, null);
            NavigationController.ShowNavigationItemAction.Items.Add(skinsGroup);
            result.Add(skinsGroup);
            return result;
        }
        protected override void OnActivated() {
            base.OnActivated();
            CreateNavigationItems();
            NavigationController.CustomShowNavigationItem += new EventHandler<CustomShowNavigationItemEventArgs>(NavigationController_CustomShowNavigationItem);
            NavigationController.CustomUpdateSelectedItem += new EventHandler<CustomUpdateSelectedItemEventArgs>(NavigationController_CustomUpdateSelectNavigationItem);
        }

		protected override void OnDeactivated() {
			base.OnDeactivated();
            NavigationController.CustomUpdateSelectedItem -= new EventHandler<CustomUpdateSelectedItemEventArgs>(NavigationController_CustomUpdateSelectNavigationItem);
            NavigationController.CustomShowNavigationItem -= new EventHandler<CustomShowNavigationItemEventArgs>(NavigationController_CustomShowNavigationItem);
        }
        protected abstract string SkinsGroupCaption {
            get;
        }
        protected abstract string ChooseSkinActionId {
            get;
        }
        protected ChooseSkinControllerType ChooseSkinController {
            get { return Frame.GetController<ChooseSkinControllerType>(); }
        }
        protected SingleChoiceAction ChooseSkinAction {
            get { return ChooseSkinController.Actions[ChooseSkinActionId] as SingleChoiceAction; }
        }
        protected ShowNavigationItemController NavigationController {
            get { return Frame.GetController<ShowNavigationItemController>(); }
        }
        public SkinsWindowControllerBase() {
            this.TargetWindowType = WindowType.Main;
        }

    }
}
