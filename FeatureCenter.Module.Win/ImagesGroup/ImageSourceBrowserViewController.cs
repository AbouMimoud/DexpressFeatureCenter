using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Demos.Win;
using DevExpress.ExpressApp.SystemModule;

namespace FeatureCenter.Module.Win.ImagesGroup {
    public partial class ImageLibrariesNavigationController : WindowController {
        private const string ImagesGroupItemCaption = "Images";
        private const string StandardImageLibraryItemCaption = "Standard Image Library";
        private const string CustomImageLibraryItemCaption = "Custom Image Library";
        private ChoiceActionItem CreateImagesLibraryObjectNavigationItem(string caption, string imageSourceName, string imageName) {
			IObjectSpace objectSpace = Application.CreateObjectSpace(typeof(ImageSourceBrowserBase));
            ImageSourceBrowserBase browserObject = objectSpace.FindObject<ImageSourceBrowserBase>(new BinaryOperator("ImageSourceName", imageSourceName), false);
            string objectKey = objectSpace.GetKeyValueAsString(browserObject);
            ViewShortcut viewShortcut = new ViewShortcut(typeof(ImageSourceBrowserBase), objectKey, Application.GetDetailViewId(typeof(ImageSourceBrowserBase)));
            ChoiceActionItem newItem = new ChoiceActionItem(caption, caption, viewShortcut);
            newItem.ImageName = imageName;
            return newItem;
        }
        protected override void OnActivated() {
            base.OnActivated();
            if(NavigationController != null) {
                ChoiceActionItem imagesGroup = NavigationController.ShowNavigationItemAction.Items.Find(ImagesGroupItemCaption, ChoiceActionItemFindType.Recursive, ChoiceActionItemFindTarget.Group);
                if(imagesGroup == null) {
                    imagesGroup = new ChoiceActionItem(ImagesGroupItemCaption, null);
                    NavigationController.ShowNavigationItemAction.Items.Add(imagesGroup);
                }
                imagesGroup.Items.Add(CreateImagesLibraryObjectNavigationItem(StandardImageLibraryItemCaption, "DevExpress.ExpressApp.Images" + AssemblyInfo.VSuffix, "ImageLibrary.Demo_Image_Library_Standard"));
                imagesGroup.Items.Add(CreateImagesLibraryObjectNavigationItem(CustomImageLibraryItemCaption, "CustomImages", "ImageLibrary.Demo_Image_Library_Custom"));
                ChoiceActionItem imagesBrowserBaseItem = NavigationController.ShowNavigationItemAction.Items.Find(Application.GetListViewId(typeof(ImageSourceBrowserBase)), ChoiceActionItemFindType.Recursive, ChoiceActionItemFindTarget.Leaf);
                if(imagesBrowserBaseItem != null) {
                    imagesBrowserBaseItem.ParentItem.Items.Remove(imagesBrowserBaseItem);
                }
            }
        }
        public ImageLibrariesNavigationController() {
            TargetWindowType = WindowType.Main;
        }
        protected ShowNavigationItemController NavigationController {
            get { return Frame.GetController<ShowNavigationItemController>(); }
        }
    }

    public class DisableImageBrowserDetailViewController : ViewController {
        private const string ActivityReason = "ActiveInDemo";
        private ImageBrowserDetailViewController ImageBrowserDetailViewController {
            get { return Frame.GetController<ImageBrowserDetailViewController>(); }
        }
        protected override void OnActivated() {
            base.OnActivated();
            if(ImageBrowserDetailViewController != null) {
                ImageBrowserDetailViewController.Active.SetItemValue(ActivityReason, false);
            }
        }
        protected override void OnDeactivated() {
            if(ImageBrowserDetailViewController != null) {
                ImageBrowserDetailViewController.Active.RemoveItem(ActivityReason);
            }
            base.OnDeactivated();
        }
        public DisableImageBrowserDetailViewController()
            : base() {
            TargetObjectType = typeof(ImageSourceBrowserBase);
            TargetViewType = ViewType.DetailView;
        }
    }
}
