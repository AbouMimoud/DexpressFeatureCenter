using System;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.Utils;
using DevExpress.ExpressApp.DC;

namespace FeatureCenter.Module.Win {
	public class ImageFixedSizeAttribute : ImageEditorAttribute {
		public ImageFixedSizeAttribute(int width, int height)
			: base(ImageEditorMode.PictureEdit, ImageEditorMode.PictureEdit) {
			ImageSizeMode = ImageSizeMode.Normal;
			ListViewImageEditorCustomHeight = height;
			DetailViewImageEditorFixedWidth = width;
			DetailViewImageEditorFixedHeight = height;
		}
	}

	public class OriginalImageSizeAttribute : ImageEditorAttribute {
		public OriginalImageSizeAttribute()
			: base(ImageEditorMode.PictureEdit, ImageEditorMode.PictureEdit) {
			ImageSizeMode = ImageSizeMode.Normal;
		}
	}

	[DefaultProperty("ImageName")]
	[DomainComponent]
	[System.ComponentModel.DisplayName("Image")]
	public class ImagePreviewObject : IPictureItem {
		private BindingList<CategoryString> categoryStrings;
		private ImageSourceBrowserBase owner;
		private string imageName;
		protected virtual Image GetSmallImage(string name, bool isEnabled) {
			return owner.ImageSource.FindImageInfo(name + ImageLoader.SmallImageSuffix, isEnabled).Image;
		}
		protected virtual Image GetImage(string name, bool isEnabled) {
			return owner.ImageSource.FindImageInfo(name, isEnabled).Image;
		}
		protected virtual Image GetLargeImage(string name, bool isEnabled) {
			//return imageSource.FindImageInfo(name + ImageLoader.LargeImageSuffix, isEnabled).Image;
			return owner.ImageSource.FindImageInfo(name + "_32x32", isEnabled).Image;
		}
		protected virtual Image GetDialogImage(string name, bool isEnabled) {
			return owner.ImageSource.FindImageInfo(name + ImageLoader.DialogImageSuffix, isEnabled).Image;
		}
		public ImagePreviewObject(ImageSourceBrowserBase owner, string imageName) {
			this.owner = owner;
			this.imageName = imageName;
		}
		public string ImageName {
			get { return imageName; }
		}
		[ImageFixedSize(48, 48), VisibleInListView(true)]
		[System.ComponentModel.DisplayName("Small")]
		public Image Image12x12 {
			get { return GetSmallImage(imageName, true); }
		}
		[ImageFixedSize(48, 48), VisibleInListView(true)]
		[System.ComponentModel.DisplayName("Original")]
		public Image Image16x16 {
			get { return GetImage(imageName, true); }
		}
		[ImageFixedSize(48, 48), VisibleInListView(true)]
		[System.ComponentModel.DisplayName("Large")]
		public Image Image32x32 {
			get { return GetLargeImage(imageName, true); }
		}
		[ImageFixedSize(48, 48), VisibleInListView(true)]
		[System.ComponentModel.DisplayName("Dialog")]
		public Image Image48x48 {
			get { return GetDialogImage(imageName, true); }
		}
		[OriginalImageSize, VisibleInListView(false)]
		[VisibleInDetailView(false)]
		public Image OriginalImage {
			get {
				Image imageThumbnail = GetLargeImage(imageName, true);
				if(imageThumbnail == null) {
					return owner.ImageSource.FindImageInfo(imageName, true).Image;
				}
				return imageThumbnail;
			}
		}
		public BindingList<CategoryString> Categories {
			get {
				if(categoryStrings == null) {
					categoryStrings = new BindingList<CategoryString>();
					foreach(string categoryName in owner.AllCategories.Keys) {
						if(owner.AllCategories[categoryName].Contains(ImageName)) {
							categoryStrings.Add(new CategoryString(owner, categoryName));
						}
					}
				}
				return categoryStrings;
			}
		}

		#region IPictureItem Members
		string IPictureItem.ID {
			get { return ImageName; }
		}
		Image IPictureItem.Image {
			get {
				if(Image32x32 != null) {
					return Image32x32;
				}
				return OriginalImage;
			}
		}
		string IPictureItem.Text {
			get { return ImageName; }
		}
		#endregion
	}

}
