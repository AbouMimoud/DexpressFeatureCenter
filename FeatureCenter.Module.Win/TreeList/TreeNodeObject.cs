using System;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.Generic;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Base.General;
using DevExpress.ExpressApp.Demos;
using DevExpress.Xpo;
using DevExpress.ExpressApp.Utils;

namespace FeatureCenter.Module.Win.TreeList {
	[DefaultProperty("Name")]
	//[Hint(Hints.TreeNodeObjectHint)]
	//[ImageName("TreeList.TreeNodeObject")]
	public class TreeNodeObject : NamedBaseObject, ITreeNode, ITreeNodeImageProvider, IPropertyDescriptorContainer {
		private TreeNodeObject parentObject;
		private string additionalObjectInfo;
		public TreeNodeObject(Session session) : base(session) { }
		[Browsable(false)]
		[Association("TreeNodeObject-TreeNodeObjects")]
		public TreeNodeObject ParentObject {
			get { return parentObject; }
			set { SetPropertyValue<TreeNodeObject>("ParentObject", ref parentObject, value); }
		}
		[Association("TreeNodeObject-TreeNodeObjects"), Aggregated]
		public XPCollection<TreeNodeObject> NestedObjects {
			get { return GetCollection<TreeNodeObject>("NestedObjects"); }
		}
		public string AdditionalObjectInfo {
			get { return additionalObjectInfo; }
			set { SetPropertyValue<string>("AdditionalObjectInfo", ref additionalObjectInfo, value); }
		}

		private PropertyBagDescriptor propertyBagDescriptor;
		private IEnumerable<DevExpress.Persistent.BaseImpl.PropertyDescriptor> properties;
		[Browsable(false)]
		public IEnumerable<DevExpress.Persistent.BaseImpl.PropertyDescriptor> PropertyDescriptors {
			get {
				if(properties == null) {
					TreeNodeObject catParent = ParentObject as TreeNodeObject;
					if(catParent != null) {
						properties = PropertyBagDescriptor.PropertyDescriptors.Concat(catParent.PropertyDescriptors);
					}
					else {
						properties = PropertyBagDescriptor.PropertyDescriptors;
					}
				}
				return properties;
			}
		}
		[Aggregated]
		[Browsable(false)]
		public PropertyBagDescriptor PropertyBagDescriptor {
			get {
				if(propertyBagDescriptor == null) {
					propertyBagDescriptor = new PropertyBagDescriptor(Session);
				}
				return propertyBagDescriptor;
			}
			set { propertyBagDescriptor = value; }
		}

		#region ITreeNode Members
		IBindingList ITreeNode.Children {
			get { return NestedObjects; }
		}
		ITreeNode ITreeNode.Parent {
			get { return ParentObject; }
		}
		string ITreeNode.Name {
			get { return base.Name; }
		}
		#endregion

		#region IPropertyDescriptorContainer Members
		PropertyDescriptorCollection IPropertyDescriptorContainer.PropertyDescriptors {
			get {
				return PropertyDescriptorAdapter.CreatePropertyDescriptorCollection(new List<IPropertyDescriptor>(PropertyDescriptors));
			}
		}
		#endregion

		#region ITreeNodeImageProvider Members
		System.Drawing.Image ITreeNodeImageProvider.GetImage(out string imageName) {
			if(NestedObjects.Count > 0) {
				imageName = "BO_Category";
			}
			else {
				imageName = "BO_Unknown";
			}
			return ImageLoader.Instance.GetImageInfo(imageName).Image;
		}
		#endregion
	}

}
