using System;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Web.SystemModule;
using FeatureCenter.Module.Navigation;

namespace FeatureCenter.Module.Web {
    public class HideViewElementsController : ViewController {
        protected override void OnActivated() {
            base.OnActivated();
            ((DetailView)View).RemoveItem("DefaultChildItemsDisplayStyle");
            NavigationObject navigationObject = ObjectSpace.FindObject<NavigationObject>(null);
            navigationObject.IsWebApplication = true;
        }
        public HideViewElementsController() {
            TargetViewType = ViewType.DetailView;
            TargetObjectType = typeof(NavigationObject);
        }
    }
    public class DisableActionsController : ViewController {
        public DisableActionsController() {
            TargetViewType = ViewType.ListView;
            TargetObjectType = typeof(NavigationItem);
        }
        protected override void OnDeactivated() {
            Frame.GetController<ListViewProcessCurrentObjectController>().ProcessCurrentObjectAction.Active["HideViewElementsController"] = true;
            Frame.GetController<ListViewController>().EditAction.Active["HideViewElementsController"] = true;
            base.OnDeactivated();
        }
        protected override void OnActivated() {
            base.OnActivated();
            Frame.GetController<ListViewProcessCurrentObjectController>().ProcessCurrentObjectAction.Active["HideViewElementsController"] = false;
            Frame.GetController<ListViewController>().EditAction.Active["HideViewElementsController"] = false;
        }
    }
    //todo mikhlyuk remove
    public class ShowDetailActionsController : ViewController<ListView> {
        private int expandedIndex = 0;
        public ShowDetailActionsController() {
            TargetViewId = "MasterObjectFull_ListView";
        }
        protected override void OnViewControlsCreated() {
            base.OnViewControlsCreated();
            DevExpress.ExpressApp.Web.Editors.ASPx.ASPxGridListEditor editor = View.Editor as DevExpress.ExpressApp.Web.Editors.ASPx.ASPxGridListEditor;
            editor.Grid.DataBound += Grid_DataBound;
        }
        protected override void OnDeactivated() {
            DevExpress.ExpressApp.Web.Editors.ASPx.ASPxGridListEditor editor = View.Editor as DevExpress.ExpressApp.Web.Editors.ASPx.ASPxGridListEditor;
            expandedIndex = -1;
            for(Int32 i = 0; i < editor.Grid.VisibleRowCount; i++) {
                if(editor.Grid.DetailRows.IsVisible(i)) {
                    expandedIndex = i;
                }
            }
            editor.Grid.DataBound -= Grid_DataBound;
            base.OnDeactivated();
        }
        private void Grid_DataBound(object sender, EventArgs e) {
            if(expandedIndex != -1) {
                ((DevExpress.Web.ASPxGridView)sender).DetailRows.ExpandRow(expandedIndex);
            }
        }
        private void ShowToolbars(DevExpress.Web.ASPxGridView grid) {
            ((DevExpress.ExpressApp.Web.Editors.ASPx.ASPxGridDetailRowTemplate)grid.Templates.DetailRow).CanMinimizeTemplate = false;
            grid.SettingsDetail.AllowOnlyOneMasterRowExpanded = true;
        }
    }
    public class ExpandDetailRowsController : ViewController<ListView> {
        public ExpandDetailRowsController() {
            TargetViewId = "MasterObject_ListView";
        }
        protected override void OnViewControlsCreated() {
            base.OnViewControlsCreated();
            DevExpress.ExpressApp.Web.Editors.ASPx.ASPxGridListEditor editor = View.Editor as DevExpress.ExpressApp.Web.Editors.ASPx.ASPxGridListEditor;
            editor.Grid.DataBound += Grid_DataBound;
        }

        void Grid_DataBound(object sender, EventArgs e) {
            ((DevExpress.Web.ASPxGridView)sender).DetailRows.ExpandRow(0);
        }
        protected override void OnDeactivated() {
            DevExpress.ExpressApp.Web.Editors.ASPx.ASPxGridListEditor editor = View.Editor as DevExpress.ExpressApp.Web.Editors.ASPx.ASPxGridListEditor;
            if(editor.Grid != null) {
                editor.Grid.DataBound -= Grid_DataBound;
            }
            base.OnDeactivated();
        }
    }
}

