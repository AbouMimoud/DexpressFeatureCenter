using DevExpress.ExpressApp;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Win.SystemModule;
using FeatureCenter.Module.ConcurrentModifications;

namespace FeatureCenter.Module.Win.ConcurrentModifications {
    public class WinConcurrentModificationsController : ConcurrentModificationsController {        
        protected override void OnActivated() {
            base.OnActivated();
            Frame.GetController<LockController>().Active[ActiveKey] = false;            
        }
    }
}
