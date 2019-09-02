using System;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Win.SystemModule;

namespace FeatureCenter.Module.Win {
    public class HidePrintPreviewForNestedDetailViewController : ViewController<DetailView> {
        public HidePrintPreviewForNestedDetailViewController() {
            TargetViewNesting = Nesting.Nested;
        }
        protected override void OnActivated() {
            base.OnActivated();
            PrintingController printingController = Frame.GetController<PrintingController>();
            if(printingController != null) {
                printingController.PrintPreviewAction.Active["NestedDetailView"] = false;
            }
        }
        protected override void OnDeactivated() {
            PrintingController printingController = Frame.GetController<PrintingController>();
            if(printingController != null) {
                printingController.PrintPreviewAction.Active.RemoveItem("NestedDetailView");
            }
            base.OnDeactivated();
        }
    }
}
