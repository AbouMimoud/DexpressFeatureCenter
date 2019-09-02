using System;
using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.TreeListEditors.Win;
using FeatureCenter.Module.Win;

namespace DevExpress.ExpressApp.Demos.Win {
	public class CategoryListViewController : ViewController {
		private SimpleAction openCategory;
		private void openCategory_Execute(object sender, SimpleActionExecuteEventArgs e) {
			e.ShowViewParameters.CreatedView = Application.CreateDetailView(Application.CreateObjectSpace(e.CurrentObject.GetType()), e.CurrentObject);
		}
		private void CategoryListViewController_CreateCustomCurrentObjectDetailView(object sender, CreateCustomCurrentObjectDetailViewEventArgs arg) {
			if(arg.ListViewCurrentObject != null) {
				arg.DetailViewId = Application.GetDetailViewId(arg.ListViewCurrentObject.GetType());
			}
		}
		protected override void OnActivated() {
			base.OnActivated();
			ListView listView = View as ListView;
			if(listView != null) {
				listView.CreateCustomCurrentObjectDetailView += new EventHandler<CreateCustomCurrentObjectDetailViewEventArgs>(CategoryListViewController_CreateCustomCurrentObjectDetailView);
				if(listView.Editor is TreeListEditor) {
					((TreeListEditor)listView.Editor).ClearFocusedObjectOnMouseClick = false;
				}
			}
		}
		protected override void OnDeactivated() {
			if(View is ListView) {
				((ListView)View).CreateCustomCurrentObjectDetailView -= new EventHandler<CreateCustomCurrentObjectDetailViewEventArgs>(CategoryListViewController_CreateCustomCurrentObjectDetailView);
			}
			base.OnDeactivated();
		}
		public CategoryListViewController()
			: base() {
			TargetObjectType = typeof(ImageBrowserCategory);
			TargetViewType = ViewType.ListView;

			openCategory = new SimpleAction(this, "OpenCategory", PredefinedCategory.Edit);
			openCategory.Caption = "Open";
			openCategory.ImageName = "MenuBar_OpenObject";
			openCategory.SelectionDependencyType = SelectionDependencyType.RequireSingleObject;
			openCategory.Execute += new SimpleActionExecuteEventHandler(openCategory_Execute);
		}
	}

	public class ImageBrowserDetailViewController : ViewController {
		private SimpleAction fillCategories;
		private SimpleAction categorizeImages;
		private void fillCategories_Execute(object sender, SimpleActionExecuteEventArgs e) {
			ImageSourceBrowserBase browser = e.CurrentObject as ImageSourceBrowserBase;
			if(browser != null && !string.IsNullOrEmpty(browser.ImageSourceName)) {
				browser.AddImageCategories(browser.ImageSource.GetImageNames());
				browser.BuildTreeNodes();
			}
		}
		private void categorizeImages_Execute(object sender, SimpleActionExecuteEventArgs e) {
			ImageSourceBrowserBase browser = e.CurrentObject as ImageSourceBrowserBase;
			if(browser != null && !string.IsNullOrEmpty(browser.ImageSourceName)) {
				browser.BuildTreeNodes();
			}
		}
		public ImageBrowserDetailViewController()
			: base() {
			TargetObjectType = typeof(ImageSourceBrowserBase);
			TargetViewType = ViewType.DetailView;

			fillCategories = new SimpleAction(this, "FillCategories", PredefinedCategory.Edit);
			fillCategories.Execute += new SimpleActionExecuteEventHandler(fillCategories_Execute);

			categorizeImages = new SimpleAction(this, "CategorizeImages", PredefinedCategory.Edit);
			categorizeImages.Execute += new SimpleActionExecuteEventHandler(categorizeImages_Execute);
		}
	}

	public enum ImagePreviewListMode { List, Thumbnails }

	public class ImagePreviewBaseListWinViewController : ViewController<ListView> {
		private SingleChoiceAction listViewMode;
		private void listViewMode_Execute(object sender, SingleChoiceActionExecuteEventArgs e) {
			if(e.SelectedChoiceActionItem.Data is ImagePreviewListMode && ((ImagePreviewListMode)(e.SelectedChoiceActionItem.Data)) == ImagePreviewListMode.Thumbnails) {
				//View.Model.Editor = View.Model.Application.EditorFactory.ListEditors[typeof(IPictureItem).FullName].Editors[WinThumbnailEditor.Alias];
                View.Model.EditorType = typeof(WinThumbnailEditor);
			}
			else {
                View.Model.EditorType = typeof(DevExpress.ExpressApp.Win.Editors.GridListEditor);
                //View.Model.EditorInfo = View.Model.Application.EditorFactory.ListEditors[typeof(Object).FullName].Editors["Grid"];
			}
			View.LoadModel();
            Frame.Template.SetView(View);
		}
		protected override void OnActivated() {
			base.OnActivated();

			if(View.Model.EditorType == typeof(WinThumbnailEditor)) {
				listViewMode.SelectedItem = listViewMode.Items.Find(ImagePreviewListMode.Thumbnails);
			}
			else {
				listViewMode.SelectedItem = listViewMode.Items.Find(ImagePreviewListMode.List);
			}
		}
		public ImagePreviewBaseListWinViewController()
			: base() {
			TargetObjectType = typeof(ImagePreviewObject);

			listViewMode = new SingleChoiceAction(this, "ImagePreviewListMode", PredefinedCategory.View);
			listViewMode.Items.Add(new ChoiceActionItem(ImagePreviewListMode.List.ToString(), ImagePreviewListMode.List));
			listViewMode.Items.Add(new ChoiceActionItem(ImagePreviewListMode.Thumbnails.ToString(), ImagePreviewListMode.Thumbnails));
			listViewMode.Execute += new SingleChoiceActionExecuteEventHandler(listViewMode_Execute);
		}
	}

}
