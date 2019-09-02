using System;
using System.ComponentModel;

using DevExpress.ExpressApp.Demos;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace FeatureCenter.Module.ListEditors {
	[Hint(Hints.DataAccessModeDemoObjectHint)]
	[ImageName("ListEditors.Demo_ListEditors_Grid_LargeData")]
    public class DataAccessModeDemoObject : GridBaseObject, IObjectPropertiesInitializer {
		private Int32 index;
        private DataAccessModeDemoReferenceObjectA referenceObjectA;
        public DataAccessModeDemoObject(Session session) : base(session) { }
        [Browsable(false)]
        public Int32 Index {
            get { return index; }
            set { SetPropertyValue("Index", ref index, value); }
        }
        public DataAccessModeDemoReferenceObjectA ReferenceObjectA {
            get { return referenceObjectA; }
            set { SetPropertyValue("ReferenceObjectA", ref referenceObjectA, value); }
        }
		// IObjectPropertiesInitializer
        public void InitializeObject(Int32 index) {
            IntegerProperty = index;
            Name = "DataAccessModeDemoObject" + index.ToString("00000");
            Index = index;
            BooleanProperty = (index % 2 == 0);
            EnumProperty = BooleanProperty ? SampleEnum.First : ((index % 3 == 0) ? SampleEnum.Second : SampleEnum.Third);
            referenceObjectA = new DataAccessModeDemoReferenceObjectA(Session);
            referenceObjectA.ReferenceObjectB = new DataAccessModeDemoReferenceObjectB(Session);
            referenceObjectA.ReferenceObjectB.ReferenceObjectC = new DataAccessModeDemoReferenceObjectC(Session);
            referenceObjectA.Name = Name;
            referenceObjectA.ReferenceObjectB.Name = Name;
            referenceObjectA.ReferenceObjectB.ReferenceObjectC.Name = Name;

            Save();
        }
    }

    public class DataAccessModeDemoReferenceObjectA : NamedBaseObject {
        private DataAccessModeDemoReferenceObjectB referenceObjectB;
        public DataAccessModeDemoReferenceObjectA(Session session) : base(session) { }
        public DataAccessModeDemoReferenceObjectB ReferenceObjectB {
            get { return referenceObjectB; }
            set { SetPropertyValue("ReferenceObjectB", ref referenceObjectB, value); }
        }
    }
    public class DataAccessModeDemoReferenceObjectB : NamedBaseObject {
        private DataAccessModeDemoReferenceObjectC referenceObjectC;
        public DataAccessModeDemoReferenceObjectB(Session session) : base(session) { }
        public DataAccessModeDemoReferenceObjectC ReferenceObjectC {
            get { return referenceObjectC; }
            set { SetPropertyValue("ReferenceObjectC", ref referenceObjectC, value); }
        }
    }
    public class DataAccessModeDemoReferenceObjectC : NamedBaseObject {
        public DataAccessModeDemoReferenceObjectC(Session session) : base(session) { }
    }
}
