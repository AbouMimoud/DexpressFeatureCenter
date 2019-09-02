using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.Persistent.Base;
using System.ComponentModel;
using DevExpress.ExpressApp.Demos;
using DevExpress.Xpo;
using FeatureCenter.Module.Audit;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp;
using DevExpress.Persistent.Validation;

namespace FeatureCenter.Module.ListEditors {

	[Hint(Hints.GridListEditorDemoObjectHint)]
	[ImageName("ListEditors.Demo_ListEditors_Grid_LargeData")]
	public class GridListEditorDemoObject : GridBaseObject, IObjectPropertiesInitializer {
		private int index;
		public GridListEditorDemoObject(Session session) : base(session) { }
		[Browsable(false)]
		public int Index {
			get { return index; }
			set { SetPropertyValue("Index", ref index, value); }
		}

		#region IObjectPropertiesInitializer Members
		public void InitializeObject(int index) {
			this.IntegerProperty = index;
			this.Name = "GridListEditorDemoObject" + index;
			this.Index = index;
			this.BooleanProperty = (index % 2 == 0);
			this.EnumProperty = this.BooleanProperty ? SampleEnum.First : ((index % 3 == 0) ? SampleEnum.Second : SampleEnum.Third);
			this.Save();
		}
		#endregion
	}

	[Hint(Hints.GridListEditorFilterDemoObjectHint)]
	[ListViewFilter("AllData", "", "All Data", true, Index = 0)]
	[ListViewFilter("EnumFirst", "EnumProperty = 'First'", "EnumProperty is First", Index = 1)]
	[ListViewFilter("EnumSecond", "EnumProperty = 'Second'", "EnumProperty is Second", Index = 2)]
	[ListViewFilter("EnumThird", "EnumProperty = 'Third'", "EnumProperty is Third", Index = 3)]
	[ListViewFilter("BooleanTrue", "BooleanProperty = true", "BooleanProperty is True", Index = 4)]
	[ListViewFilter("BooleanFalse", "BooleanProperty = false", "BooleanProperty is False", Index = 5)]
	[ImageName("ListEditors.Demo_ListEditors_Grid_Filter")]
	public class GridListEditorFilterDemoObject : GridBaseObject {
		public GridListEditorFilterDemoObject(Session session) : base(session) { }
	}

	[Hint(Hints.GridListEditorAutoFilterDemoObjectHint)]
	[ListViewAutoFilterRowAttribute(true)]
	[ImageName("ListEditors.Demo_ListEditors_Grid_AutoFilterRow")]
	public class GridListEditorAutoFilterDemoObject : GridBaseObject {
		public GridListEditorAutoFilterDemoObject(Session session) : base(session) { }
	}

	[Hint(Hints.GridListEditorNewItemRowDemoObjectHint)]
	[DefaultListViewOptionsAttribute(true, NewItemRowPosition.Top)]
	[ImageName("Action_Inline_New")]
	public class GridListEditorNewItemRowDemoObject : GridBaseObject {
		public GridListEditorNewItemRowDemoObject(Session session) : base(session) { }
	}

    [Hint(Hints.GridListEditorBatchEditDemoObjectHint)]
    [DefaultListViewOptionsAttribute(true, NewItemRowPosition.Top)]
    [ImageName("ListEditors.Demo_ListEditors_Grid_BatchEdit")]
    public class GridListEditorBatchEditDemoObject : GridBaseObject {
        public GridListEditorBatchEditDemoObject(Session session) : base(session) { }
        public override void AfterConstruction() {
            base.AfterConstruction();
            EnumProperty = SampleEnum.Second;
            IntegerProperty = 999;
        }
        public void InitializeObject(int index) {
            this.IntegerProperty = index;
            this.Name = "Object " + index;
            this.BooleanProperty = (index % 2 == 0);
            this.EnumProperty = this.BooleanProperty ? SampleEnum.First : ((index % 3 == 0) ? SampleEnum.Second : SampleEnum.Third);
            this.Save();
        }
    }

}
