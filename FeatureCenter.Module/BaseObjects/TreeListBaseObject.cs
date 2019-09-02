using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.Persistent.Base;
using System.ComponentModel;
using DevExpress.Xpo;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Base.General;

namespace FeatureCenter.Module {
	[NavigationItem(false)]
	[DefaultProperty("Caption")]
	[ImageName("ListEditors.Demo_ListEditors_TreeList")]
	public class TreeListBaseObject : BaseObject, ITreeNode {
		private TreeListBaseObject parentObject;
		private string caption;
		public TreeListBaseObject(Session session) : base(session) { }
		public string Caption {
			get { return caption; }
			set { SetPropertyValue<string>("Caption", ref caption, value); }
		}
		[Browsable(false)]
		[Association("TreeListBaseObject-TreeListBaseObject")]
		public TreeListBaseObject ParentObject {
			get { return parentObject; }
			set { SetPropertyValue<TreeListBaseObject>("ParentObject", ref parentObject, value); }
		}
		[Association("TreeListBaseObject-TreeListBaseObject"), Aggregated]
		public XPCollection<TreeListBaseObject> NestedObjects {
			get { return GetCollection<TreeListBaseObject>("NestedObjects"); }
		}
		#region ITreeNode Members
		IBindingList ITreeNode.Children {
			get { return NestedObjects; }
		}
		string ITreeNode.Name {
			get { return Caption; }
		}
		ITreeNode ITreeNode.Parent {
			get { return ParentObject; }
		}
		#endregion
	}
}
