using System;
using System.Text;
using System.ComponentModel;
using System.Collections.Generic;
using DevExpress.Xpo;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Base.General;
using DevExpress.ExpressApp.Demos;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp;
using FeatureCenter.Module.Filtering;
using DevExpress.ExpressApp.Filtering;

namespace FeatureCenter.Module.ListEditors {

	[Hint(Hints.TreeListEditorDemoObjectHint)]
	[ImageName("ListEditors.Demo_ListEditors_TreeList_LargeData")]
    [BatchCreationOptions(50, 1)]
	public class TreeListEditorDemoObject : TreeListBaseObject, IObjectPropertiesInitializer {
		private void CreateChildren(TreeListEditorDemoObject treeListEditorDemoObject, int count) {
			TreeListEditorDemoObject parentLevelObject = treeListEditorDemoObject;
			int currentLevel = 0;
			while(parentLevelObject.ParentObject != null) {
				parentLevelObject = (TreeListEditorDemoObject)parentLevelObject.ParentObject;
				currentLevel++;
			}
			if(currentLevel >= 2) {
				return;
			}
			for(int i = 0; i < count; i++) {
				TreeListEditorDemoObject childObject = new TreeListEditorDemoObject(Session);
				childObject.ParentObject = treeListEditorDemoObject;
				childObject.Caption = treeListEditorDemoObject.Caption + "-" + i;
				childObject.Save();
				CreateChildren(childObject, count + 3);
			}

		}
		public TreeListEditorDemoObject(Session session) : base(session) { }

		#region IObjectPropertiesInitializer Members
		public void InitializeObject(int index) {
			this.Caption = "Test tree list object #" + index;
			CreateChildren(this, 5);
		}
		#endregion
	}

	[Hint(Hints.TreeListEditorNodeImagesDemoObjectHint)]
	[ImageName("ListEditors.Demo_ListEditors_TreeList_NodeImages")]
	public class TreeListEditorNodeImagesDemoObject : TreeListBaseObject, ITreeNodeImageProvider {
		public TreeListEditorNodeImagesDemoObject(Session session) : base(session) { }

		#region ITreeNodeImageProvider Members
		public System.Drawing.Image GetImage(out string imageName) {
			if(NestedObjects != null && NestedObjects.Count > 0) {
				imageName = "BO_Product_Group";
			}
			else {
				imageName = "BO_Product";
			}
			return ImageLoader.Instance.GetImageInfo(imageName).Image;
		}
		#endregion
	}

	[ListViewFilter("AllData", "", "All Data", true, Index = 0)]
	[ListViewFilter("CaptionF", "StartsWith(Caption, 'F')", "Caption begins 'F'", Index = 1)]
    [ListViewFilter("CaptionS", "not StartsWith(Caption, 'F')", "Caption not begins 'F'", Index = 2)]
	[Hint(Hints.TreeListEditorFilterDemoObjectHint)]
	[ImageName("ListEditors.Demo_ListEditors_TreeList_Filter")]
	public class TreeListEditorFilterDemoObject : TreeListBaseObject {
		public TreeListEditorFilterDemoObject(Session session) : base(session) { }
	}

	[Hint(Hints.TreeListEditorFilterByTextObjectHint)]
	[ImageName(TreeListEditorFilterByTextObject.FilterByTextImageName)]
	public class TreeListEditorFilterByTextObject : TreeListBaseObject {
		private string friendlyKey;
		private string defaultProperty;
		private string nonDefaultProperty;
		private string nonPersistentProperty = "NonPersistentProperty";
		public const string FilterByTextImageName = "Filtering.Demo_Search_FilterByText";

		private FilterByTextAggregatedObject aggregatedObject;
		private FilterByTextReferencedObject referencedObject;

		public TreeListEditorFilterByTextObject(Session session) : base(session) { }

		public override void AfterConstruction() {
			base.AfterConstruction();
			aggregatedObject = new FilterByTextAggregatedObject(Session);
		}

		public string FriendlyKey {
			get { return friendlyKey; }
			set { SetPropertyValue("FriendlyKey", ref friendlyKey, value); }
		}
		public string DefaultProperty {
			get { return defaultProperty; }
			set { SetPropertyValue("DefaultProperty", ref defaultProperty, value); }
		}
		public string NonDefaultProperty {
			get { return nonDefaultProperty; }
			set { SetPropertyValue("NonDefaultProperty", ref nonDefaultProperty, value); }
		}
		public string NonPersistentProperty {
			get { return nonPersistentProperty; }
		}
		[Aggregated]
		public FilterByTextAggregatedObject AggregatedObject {
			get { return aggregatedObject; }
			set { SetPropertyValue("AggregatedObject", ref aggregatedObject, value); }
		}
		public FilterByTextReferencedObject ReferencedObject {
			get { return referencedObject; }
			set { SetPropertyValue("ReferencedObject", ref referencedObject, value); }
		}
	}
}
