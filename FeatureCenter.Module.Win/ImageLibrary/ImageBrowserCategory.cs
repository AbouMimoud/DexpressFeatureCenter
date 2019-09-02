using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Base.General;

namespace FeatureCenter.Module.Win {
	[DomainComponent]
	[DefaultProperty("Name")]
	public abstract class ImageBrowserCategory : ITreeNode, ITreeNodeImageProvider {
		private BindingList<ImageBrowserCategory> childCategories = new BindingList<ImageBrowserCategory>();
		private ImageBrowserCategory parentCategory;
		private ImageSourceBrowserBase owner;
		private string name;
		protected abstract Image GetNodeImage(out string imageName);
		public ImageBrowserCategory(ImageSourceBrowserBase owner, string name) {
			this.owner = owner;
			this.name = name;
		}
		[Browsable(false)]
		public ImageSourceBrowserBase Owner {
			get { return owner; }
			set { owner = value; }
		}
		[Browsable(false)]
		public ImageBrowserCategory ParentCategory {
			get { return parentCategory; }
			set { parentCategory = value; }
		}
		[Browsable(false)]
		public BindingList<ImageBrowserCategory> ChildCategories {
			get { return childCategories; }
		}
		System.ComponentModel.IBindingList ITreeNode.Children {
			get { return ChildCategories; }
		}
		public string Name {
			get { return name; }
		}
		ITreeNode ITreeNode.Parent {
			get { return ParentCategory; }
		}
		Image ITreeNodeImageProvider.GetImage(out string imageName) {
			return GetNodeImage(out imageName);
		}
	}

	[DomainComponent]
	public class ImagesGroupNode : ImageBrowserCategory {
		public const string ObjectImageName = "ImageBrowserCategory";
		List<ImagePreviewObject> images = new List<ImagePreviewObject>();
		protected override Image GetNodeImage(out string imageName) {
			imageName = ObjectImageName;
			return ImageLoader.Instance.GetImageInfo(imageName).Image;
		}
		internal void FillImageCategoriesTree(IDictionary<string, IList<string>> categories, List<string> imageNames, ICollection<string> currentLevelChildren) {
			List<string> nextLevelChildren = new List<string>(currentLevelChildren);
			if(ParentCategory != null && ParentCategory.ParentCategory == null) {
				nextLevelChildren = new List<string>(categories.Keys);
			}
			nextLevelChildren.Remove(Name);

			List<string> nextLevelImageTreeNodes = new List<string>(imageNames);
			Dictionary<string, List<string>> childCategoriesImageNames = new Dictionary<string, List<string>>();
			foreach(string imageName in imageNames) {
				images.Add(new ImagePreviewObject(Owner, imageName));
				foreach(string categoryName in nextLevelChildren) {
					if(categoryName != Name) {
						if(!childCategoriesImageNames.ContainsKey(categoryName)) {
							childCategoriesImageNames.Add(categoryName, new List<string>());
						}
						if(categories[categoryName].Contains(imageName)) {
							childCategoriesImageNames[categoryName].Add(imageName);
							nextLevelImageTreeNodes.Remove(imageName);
						}
					}
				}
			}

			foreach(string childCategoryName in childCategoriesImageNames.Keys) {
				if(childCategoriesImageNames[childCategoryName].Count == 1) {
					if(!nextLevelImageTreeNodes.Contains(childCategoriesImageNames[childCategoryName][0])) {
						nextLevelImageTreeNodes.Add(childCategoriesImageNames[childCategoryName][0]);
					}
				}
				else if(childCategoriesImageNames[childCategoryName].Count > 1) {
					ImagesGroupNode childCategory = new ImagesGroupNode(Owner, this, childCategoryName);
					ChildCategories.Add(childCategory);
					childCategory.FillImageCategoriesTree(categories, childCategoriesImageNames[childCategoryName], nextLevelChildren);
				}
			}
			foreach(string nextLevelImageTreeNode in nextLevelImageTreeNodes) {
				ImageNode imageTreeNode = new ImageNode(Owner, nextLevelImageTreeNode);
				ChildCategories.Add(imageTreeNode);
			}
		}
		public ImagesGroupNode(ImageSourceBrowserBase owner, ImagesGroupNode parent, string category)
			: base(owner, category) {
			ParentCategory = parent;
		}
		public virtual IList<ImagePreviewObject> Images {
			get { return images; }
		}
	}

	[DomainComponent]
	public class ImageNode : ImageBrowserCategory {
		public const string ObjectImageName = "ImageBrowserNode";
		protected override Image GetNodeImage(out string imageName) {
			imageName = ObjectImageName;
			return ImageLoader.Instance.GetImageInfo(imageName).Image;
		}
		public ImageNode(ImageSourceBrowserBase owner, string imageName) : base(owner, imageName) { }
		[EditorAlias(EditorAliases.DetailPropertyEditor)]
		public ImagePreviewObject Image {
			get { return new ImagePreviewObject(Owner, Name); }
		}
	}

}

