using System;
using System.Globalization;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;

namespace FeatureCenter.Module.Localization {
    //The XafApplication.SetLanguage method is not designed to switch languages at runtime. The application should be restarted after changing the language.
    //This controller is for demo purposes only. Do not use it in production applications.
	public class ChangeLanguageController : WindowController {
		private const string navBarGroupCaption = "Localization";
		private const string languageShortcutKey = "Language";
		private const string formattingCultureShortcutKey = "Formatting";
		private readonly string defaultCultureName = CultureInfo.InvariantCulture.TwoLetterISOLanguageName;
		private const string defaultLanguageCaption = CaptionHelper.DefaultLanguage;
		public const string defaultCultureCaption = "(Default culture)";

		private ChoiceActionItem localizationNavBarGroup = null;
		private SingleChoiceAction chooseLanguage;
		private SingleChoiceAction chooseFormattingCulture;
		private string defaultFormattingCultureName;
        private ViewShortcut currentNavigationItemShortcut = null;

		private void ChooseLanguage_Execute(object sender, DevExpress.ExpressApp.Actions.SingleChoiceActionExecuteEventArgs e) {
			string newLanguageName = e.SelectedChoiceActionItem.Data as string;
			if(newLanguageName == defaultLanguageCaption) {
				newLanguageName = defaultCultureName;
			}
			Application.SetLanguage(newLanguageName);
		}
		private void ChooseFormattingCulture_Execute(object sender, SingleChoiceActionExecuteEventArgs e) {
			string newCultureName = e.SelectedChoiceActionItem.Data as string;
			if(newCultureName == defaultLanguageCaption) {
				newCultureName = defaultFormattingCultureName;
			}
			Application.SetFormattingCulture(newCultureName);
		}
        //private void ChangeLanguageController_CustomShowNavigationItem(object sender, CustomShowNavigationItemEventArgs e) {
        //    ViewShortcut shortcut = e.ActionArguments.SelectedChoiceActionItem.Data as ViewShortcut;
        //    if(shortcut != null) {
        //        if(shortcut.Keys.Contains(languageShortcutKey) && shortcut.Keys.Contains(formattingCultureShortcutKey)) {
        //            currentNavigationItemShortcut = shortcut;
        //            ChoiceActionItem languageItem = chooseLanguage.Items.Find(shortcut[languageShortcutKey]);
        //            if(languageItem != null) {
        //                chooseLanguage.DoExecute(languageItem);
        //            }
        //            ChoiceActionItem formattingCultureItem = chooseFormattingCulture.Items.Find(shortcut[formattingCultureShortcutKey]);
        //            if(formattingCultureItem != null) {
        //                chooseFormattingCulture.DoExecute(formattingCultureItem);
        //            }
        //            if((Window.View is ObjectView) && (((ObjectView)Window.View).ObjectTypeInfo.Type == typeof(LocalizationObject))) {
        //                e.Handled = true;
        //            }
        //        }
        //    }
        //}
		private void StoreDefaultCulture() {
			defaultFormattingCultureName = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
		}
        private void navigationController_CustomUpdateSelectedItem(object sender, CustomUpdateSelectedItemEventArgs e) {
            if(e.ProposedSelectedItem != null && localizationNavBarGroup != null && localizationNavBarGroup.Items.Contains(e.ProposedSelectedItem)) {
                if(currentNavigationItemShortcut != null && ((ViewShortcut)e.ProposedSelectedItem.Data) != currentNavigationItemShortcut) {
                    ChoiceActionItem correctSelectedItem = localizationNavBarGroup.Items.Find(currentNavigationItemShortcut);
                    if(correctSelectedItem != null) {
						e.ProposedSelectedItem = correctSelectedItem;
                        e.Handled = true;
                    }
                    currentNavigationItemShortcut = null;
                }
            }
        }
		private void UpdateCultureChoiceActionItem(string languageAspect, string formattingAspect, string id, string imageName) {
			ChoiceActionItem item = localizationNavBarGroup.Items.Find(id, ChoiceActionItemFindType.Recursive, ChoiceActionItemFindTarget.Any);
			if(item != null) {
				ViewShortcut viewShortcut = new ViewShortcut(typeof(LocalizationObject), null, Application.GetListViewId(typeof(LocalizationObject)));
				viewShortcut.Add(languageShortcutKey, languageAspect);
				viewShortcut.Add(formattingCultureShortcutKey, formattingAspect);
				item.Data = viewShortcut;
				item.ImageName = imageName;
			}
		}
		protected override void OnActivated() {
			base.OnActivated();

            ShowNavigationItemController navigationController = Frame.GetController<ShowNavigationItemController>();
            //StoreDefaultCulture();
			localizationNavBarGroup = navigationController.ShowNavigationItemAction.Items.Find(navBarGroupCaption, ChoiceActionItemFindType.Recursive, ChoiceActionItemFindTarget.Any);
			if(localizationNavBarGroup != null) {
				UpdateCultureChoiceActionItem(defaultLanguageCaption, defaultFormattingCultureName, "Language: Default, Formatting: User", "Localization.Demo_Localization_Def_User");
                //UpdateCultureChoiceActionItem("de", defaultFormattingCultureName, "Language: de, Formatting: User", "Localization.Demo_Localization_de_User");
                //UpdateCultureChoiceActionItem(defaultLanguageCaption, "de", "Language: Default, Formatting: de", "Localization.Demo_Localization_Def_de");
                //UpdateCultureChoiceActionItem("de", "de", "Language: de, Formatting: de", "Localization.Demo_Localization_de_de");
            }

            //ChoiceActionItem currentLanguageItem = ChooseLanguage.Items.Find(Application.Model.CurrentAspect, ChoiceActionItemFindType.NonRecursive, ChoiceActionItemFindTarget.Leaf);
            //ChoiceActionItem currentLanguageItem = ChooseLanguage.Items.Find(((IModelApplicationServices)(Application.Model)).CurrentAspect, ChoiceActionItemFindType.NonRecursive, ChoiceActionItemFindTarget.Leaf);
            //if(currentLanguageItem != null) {
            //    ChooseLanguage.SelectedIndex = ChooseLanguage.Items.IndexOf(currentLanguageItem);
            //}
			//ChooseFormattingCulture.SelectedIndex = ChooseFormattingCulture.Items.IndexOf(ChooseFormattingCulture.Items.Find(System.Threading.Thread.CurrentThread.CurrentCulture.Name, ChoiceActionItemFindType.Recursive, ChoiceActionItemFindTarget.Any));

			//navigationController.CustomShowNavigationItem += new EventHandler<CustomShowNavigationItemEventArgs>(ChangeLanguageController_CustomShowNavigationItem);
            navigationController.CustomUpdateSelectedItem += new EventHandler<CustomUpdateSelectedItemEventArgs>(navigationController_CustomUpdateSelectedItem);
			this.chooseFormattingCulture.Execute += new SingleChoiceActionExecuteEventHandler(ChooseFormattingCulture_Execute);
			this.chooseLanguage.Execute += new DevExpress.ExpressApp.Actions.SingleChoiceActionExecuteEventHandler(ChooseLanguage_Execute);

		}
		protected override void OnDeactivated() {
			base.OnDeactivated();
			ShowNavigationItemController navigationController = Frame.GetController<ShowNavigationItemController>();
			//navigationController.CustomShowNavigationItem -= new EventHandler<CustomShowNavigationItemEventArgs>(ChangeLanguageController_CustomShowNavigationItem);
            navigationController.CustomUpdateSelectedItem -= new EventHandler<CustomUpdateSelectedItemEventArgs>(navigationController_CustomUpdateSelectedItem);
			this.chooseLanguage.Execute -= new DevExpress.ExpressApp.Actions.SingleChoiceActionExecuteEventHandler(ChooseLanguage_Execute);
			this.chooseFormattingCulture.Execute -= new SingleChoiceActionExecuteEventHandler(ChooseFormattingCulture_Execute);
		}
		public ChangeLanguageController() {
            this.TargetWindowType = WindowType.Main;
            StoreDefaultCulture();
			this.chooseLanguage = new DevExpress.ExpressApp.Actions.SingleChoiceAction(this, "ChooseLanguage", PredefinedCategory.Tools);
			this.chooseFormattingCulture = new DevExpress.ExpressApp.Actions.SingleChoiceAction(this, "ChooseFormattingCulture", PredefinedCategory.Tools);
			this.chooseLanguage.Items.Add(new ChoiceActionItem(defaultLanguageCaption, defaultLanguageCaption, defaultLanguageCaption));
			this.chooseLanguage.Items.Add(new ChoiceActionItem("de", "German (de)", "de"));
			this.chooseFormattingCulture.Items.Add(new ChoiceActionItem(defaultCultureCaption, defaultCultureCaption, defaultFormattingCultureName));
			this.chooseFormattingCulture.Items.Add(new ChoiceActionItem("de", "German (de)", "de"));
			chooseLanguage.SelectedIndex = 0;
			chooseFormattingCulture.SelectedIndex = 0;
		}
		public DevExpress.ExpressApp.Actions.SingleChoiceAction ChooseLanguage {
			get { return chooseLanguage; }
		}
		public DevExpress.ExpressApp.Actions.SingleChoiceAction ChooseFormattingCulture {
			get { return chooseFormattingCulture; }
		}
	}
}
