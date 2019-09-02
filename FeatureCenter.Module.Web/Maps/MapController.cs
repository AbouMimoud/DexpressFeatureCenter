using System;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Maps.Web;

namespace FeatureCenter.Module.Web.Maps {
    public class MapController : ViewController<ListView> {
        private SingleChoiceAction changeProviderAction;
        public MapController() {
            TargetObjectType = typeof(IMapsMarker);

            changeProviderAction = new SingleChoiceAction(this, "Map provider", PredefinedCategory.Edit);
            changeProviderAction.Items.Add(new ChoiceActionItem("Google", MapProvider.Google));
            changeProviderAction.Items.Add(new ChoiceActionItem("Bing", MapProvider.Bing));
            changeProviderAction.Execute += changeProviderAction_Execute;

            changeProviderAction.ImageMode = ImageMode.UseActionImage;
            changeProviderAction.ItemType = SingleChoiceActionItemType.ItemIsMode;
            changeProviderAction.ImageName = "Maps.Change_Provider";

            SimpleAction drawRouteAction = new SimpleAction(this, "Show/hide routes", PredefinedCategory.Edit);
            drawRouteAction.Execute += drawRouteAction_Execute;
            drawRouteAction.ImageName = "Maps.Show_Routes";
        }
        protected override void OnActivated() {
            base.OnActivated();
            changeProviderAction.SelectedIndex = 0;
        }
        private void changeProviderAction_Execute(object sender, SingleChoiceActionExecuteEventArgs e) {
            WebMapsListEditor listEditor = View.Editor as WebMapsListEditor;
            if(listEditor != null) {
                listEditor.MapViewer.MapSettings.Provider = (MapProvider)e.SelectedChoiceActionItem.Data;
            }
        }
        private void drawRouteAction_Execute(object sender, SimpleActionExecuteEventArgs e) {
            WebMapsListEditor listEditor = View.Editor as WebMapsListEditor;
            if(listEditor != null) {
                listEditor.MapViewer.MapSettings.RouteSettings.Enabled = !listEditor.MapViewer.MapSettings.RouteSettings.Enabled;
            }
        }
    }
    //public class EnableHtmlMapController : ViewController<ListView> {
    //    public EnableHtmlMapController() {
    //        TargetObjectType = typeof(IMapsMarker);
    //    }
    //    protected override void OnViewControlsCreated() {
    //        WebMapsListEditor listEditor = View.Editor as WebMapsListEditor;
    //        if (listEditor != null) {
    //            listEditor.MapViewer.EncodeHtml = false;
    //        }
    //    }
    //}
    public class EnableHtmlVectorMapController : ViewController<ListView> {
        protected override void OnViewControlsCreated() {
            WebVectorMapsListEditor listEditor = View.Editor as WebVectorMapsListEditor;
            if (listEditor != null) {
                listEditor.VectorMapViewer.EncodeHtml = false;
            }
        }
    }
}
