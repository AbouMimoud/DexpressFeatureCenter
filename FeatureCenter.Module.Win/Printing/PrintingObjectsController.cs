using System;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.ExpressApp.Win.SystemModule;
using DevExpress.ExpressApp.Win.Templates.ActionContainers;
using DevExpress.ExpressApp.Win.Templates.Controls;
using DevExpress.Persistent.Base;
using DevExpress.XtraBars;
using FeatureCenter.Module.Actions;

namespace FeatureCenter.Module.Win.Printing {
	public partial class PrintingObjectsController : WindowController {
		private SingleChoiceAction printingSettingsStorageSelector;
		private void printingSettingsStorageSelector_Execute(object sender, SingleChoiceActionExecuteEventArgs e) {
			if(e.SelectedChoiceActionItem.Data is PrintingSettingsStorage) {
                PrintingWindowsFormsModule.PrintingSettingsStorage = (PrintingSettingsStorage)(e.SelectedChoiceActionItem.Data);
			}
		}
		private XafBar GetOwnToolbarForBarItemContainer(ActionContainerBarItem container) {
			Guard.ArgumentNotNull(container, "container");
            XafBar toolBar = container.Manager.Bars[container.ContainerId] as XafBar;
			if(toolBar == null) {
				toolBar = new XafBar(container.Manager);
				toolBar.BarName = container.ContainerId;
                toolBar.Text = container.ContainerId;
				toolBar.Visible = true;
				toolBar.DockStyle = BarDockStyle.Top;
				toolBar.OptionsBar.MultiLine = true;
				toolBar.AddItem(container);
			}
			return toolBar;
		}
		private ActionContainerBarItem PrintActionContainer {
			get {
				foreach(IActionContainer container in Frame.Template.GetContainers()) {
					if(container.ContainerId == PredefinedCategory.Print.ToString()) {
						return container as ActionContainerBarItem;
					}
				}
				return null;
			}
		}
        private SystemWindowsFormsModule PrintingWindowsFormsModule {
            get { return (SystemWindowsFormsModule)Application.Modules.FindModule(typeof(SystemWindowsFormsModule)); }
		}
        private void Frame_ViewChanged(object sender, ViewChangedEventArgs e) {
			ActionContainerBarItem printActionContainer = PrintActionContainer;
            ObjectView objectView = Frame.View as ObjectView;
            if(printActionContainer != null && objectView !=null) {
				PrintActionContainer.Manager.Items[printingSettingsStorageSelector.Caption].PaintStyle = BarItemPaintStyle.CaptionGlyph;
                Type objectType = objectView.ObjectTypeInfo.Type;
                bool barVisible =(objectType == typeof(EventDemoObject) || objectType == typeof(GridDemoObject) || objectType == typeof(LayoutDemoObject) || objectType == typeof(TreeListDemoObject));
                GetOwnToolbarForBarItemContainer(PrintActionContainer).Visible = barVisible;
            }
		}
		protected override void OnActivated() {
			base.OnActivated();
			ShowNavigationItemController navigationController = Frame.GetController<ShowNavigationItemController>();
			foreach(ChoiceActionItem item in printingSettingsStorageSelector.Items) {
				if(item.Data.Equals(PrintingWindowsFormsModule.PrintingSettingsStorage)) {
					printingSettingsStorageSelector.SelectedItem = item;
					break;
				}
			}
            if(((IModelOptionsWin)Application.Model.Options).FormStyle == DevExpress.XtraBars.Ribbon.RibbonFormStyle.Standard) {
                Frame.ViewChanged += new EventHandler<ViewChangedEventArgs>(Frame_ViewChanged);
            }
		}
		protected override void OnDeactivated() {
			Frame.ViewChanged -= new EventHandler<ViewChangedEventArgs>(Frame_ViewChanged);
			base.OnDeactivated();
		}
		public PrintingObjectsController() {
			TargetWindowType = WindowType.Main;
			DevExpress.ExpressApp.Scheduler.Win.SchedulerListEditor.DailyPrintStyleCalendarHeaderVisible = false;
			printingSettingsStorageSelector = new SingleChoiceAction(this, "PrintingSettingsStorage", PredefinedCategory.Print);
			printingSettingsStorageSelector.Execute += new SingleChoiceActionExecuteEventHandler(printingSettingsStorageSelector_Execute);
            ChoiceActionItem viewStorage = new ChoiceActionItem(PrintingSettingsStorage.View.ToString(), PrintingSettingsStorage.View);
            //TODO Minakov
            ChoiceActionItem applicationStorage = new ChoiceActionItem(PrintingSettingsStorage.Application.ToString(), PrintingSettingsStorage.Application);
			printingSettingsStorageSelector.Items.Add(viewStorage);
			printingSettingsStorageSelector.Items.Add(applicationStorage);
		}
	}

    public class DisablePrintingController : ViewController<ObjectView> {
        protected override void OnActivated() {
            base.OnActivated();
            if(View.ObjectTypeInfo.Type == typeof(ActionEnabled)
                || typeof(ActionBase).IsAssignableFrom(View.ObjectTypeInfo.Type)
                || View.ObjectTypeInfo.Type == typeof(DemoItem) || typeof(ActionBaseRootObject).IsAssignableFrom(View.ObjectTypeInfo.Type)) {
                Frame.GetController<DevExpress.ExpressApp.Win.SystemModule.PrintingController>().Active["DemoDisablePrinting"] = false;
            }
        }
		protected override void OnDeactivated() {
            Frame.GetController<DevExpress.ExpressApp.Win.SystemModule.PrintingController>().Active.RemoveItem("DemoDisablePrinting");
			base.OnDeactivated();
        }
    }
}
