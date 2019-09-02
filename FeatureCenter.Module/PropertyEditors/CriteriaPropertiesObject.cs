using System;
using System.ComponentModel;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Demos;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using DevExpress.ExpressApp.DC;

namespace FeatureCenter.Module.PropertyEditors {
	[NavigationItem(Captions.PropertyEditorsGroup), DefaultListViewOptions(true, NewItemRowPosition.Top)]	
	[Hint(Hints.CriteriaPropertiesHint)]
	[ImageName("PropertyEditors.Demo_Criteria_Properties")]
	public class CriteriaProperties : NamedBaseObject {
		private Type dataType;
		private string dataTypeName;
		private string criteria;
        private string criteriaWithNestedProperties;
		private string criteriaInPopupWindow;

		public CriteriaProperties(Session session) : base(session) { }
		
		[Browsable(false)]
		public string DataTypeName {
			get { return dataTypeName; }
			set {
				Type type = XafTypesInfo.Instance.FindTypeInfo(value) == null ? null : XafTypesInfo.Instance.FindTypeInfo(value).Type;
				if(dataType != type) {
					dataType = type;
				}
				if(!IsLoading && value != dataTypeName) {
					//B150437
					Criteria = String.Empty;
                    CriteriaWithNestedProperties = String.Empty;
					CriteriaInPopupWindow = String.Empty;
				}
				SetPropertyValue<string>("DataTypeName", ref dataTypeName, value);
			}
		}

        [TypeConverter(typeof(LocalizedPersistentClassInfoTypeConverter))]
		[ImmediatePostData, NonPersistent]
		public Type DataType {
			get { return dataType; }
			set {
				if(dataType != value) {
					dataType = value;
					DataTypeName = (value == null) ? null : value.FullName;
				}
			}
		}
		
		[CriteriaOptions("DataType")]
		[Size(SizeAttribute.Unlimited), ObjectValidatorIgnoreIssue(typeof(ObjectValidatorLargeNonDelayedMember))]
        [ModelDefault("RowCount", "0")]
		[VisibleInListView(true)]
        [EditorAlias(EditorAliases.CriteriaPropertyEditor)]
		public string Criteria {
			get { return criteria; }
			set { SetPropertyValue<string>("Criteria", ref criteria, value); }
		}

        [CriteriaOptions("DataType")]
        [Size(SizeAttribute.Unlimited), ObjectValidatorIgnoreIssue(typeof(ObjectValidatorLargeNonDelayedMember))]
        [ModelDefault("RowCount", "0")]
        [VisibleInListView(true)]
        [EditorAlias(EditorAliases.CriteriaPropertyEditor)]
        public string CriteriaWithNestedProperties {
            get { return criteriaWithNestedProperties; }
            set { SetPropertyValue<string>("CriteriaWithNestedProperties", ref criteriaWithNestedProperties, value); }
        }

        [CriteriaOptions("DataType")]
		[Size(SizeAttribute.Unlimited), ObjectValidatorIgnoreIssue(typeof(ObjectValidatorLargeNonDelayedMember))]
        [ModelDefault("RowCount", "0")]
		[VisibleInListView(true)]
        [EditorAlias(EditorAliases.PopupCriteriaPropertyEditor)]
		public string CriteriaInPopupWindow {
			get { return criteriaInPopupWindow; }
			set { SetPropertyValue<string>("CriteriaInPopupWindow", ref criteriaInPopupWindow, value); }
		}
	}

	public class CriteriaObject : NamedBaseObject {
		private CriteriaReferencedObject owner;
		private DateTime createdOn;
		private DateTime dueDate;
		private TextAndImageEnum enumProperty;
        
		public CriteriaObject(Session session) : base(session) {}		
		public DateTime CreatedOn {
			get { return createdOn; }
			set { SetPropertyValue<DateTime>("CreatedOn", ref createdOn, value); }
		}
		public DateTime DueDate {
			get { return dueDate; }
			set { SetPropertyValue<DateTime>("DueDate",  ref dueDate, value); }
		}
		public CriteriaReferencedObject Owner {
			get { return owner; }
			set { SetPropertyValue<CriteriaReferencedObject>("Reference", ref owner, value); }
		}
		public TextAndImageEnum EnumProperty {
			get { return enumProperty; }
			set { SetPropertyValue<TextAndImageEnum>("EnumProperty", ref enumProperty, value); }
		}
        [Association("CriteriaObject-CriteriaReferencedObject")]
        public XPCollection<CriteriaReferencedObject> Collection {
            get { return GetCollection<CriteriaReferencedObject>("Collection"); }
        }
	}
    public class CriteriaReferencedObject : XPCustomObject {
        [Key(false)]
        [Persistent]
        private int key;
        private string name;
        private CriteriaReferencedObject owner;
        private CriteriaObject masterObject;
        public CriteriaReferencedObject(Session session) : base(session) { }
        public void SetKey(int key) {
            this.key = key;
        }
        [PersistentAlias("key")]
        public int Key {
            get { return key; }
        }
        public string Name {
            get { return name; }
            set { SetPropertyValue("Name", ref name, value); }
        }
        public CriteriaReferencedObject Owner {
            get { return owner; }
            set { SetPropertyValue<CriteriaReferencedObject>("ReferencedObject", ref owner, value); }
        }
        [Association("CriteriaObject-CriteriaReferencedObject")]
        public CriteriaObject MasterObject {
            get { return masterObject; }
            set { SetPropertyValue<CriteriaObject>("MasterObject", ref masterObject, value); }
        }
    }

    public class LocalizedPersistentClassInfoTypeConverter : LocalizedClassInfoTypeConverter {
        public LocalizedPersistentClassInfoTypeConverter() { }
        public override System.Collections.Generic.List<Type> GetSourceCollection(ITypeDescriptorContext context) {
            System.Collections.Generic.List<Type> persistentTypes = new System.Collections.Generic.List<Type>();
            foreach(Type type in base.GetSourceCollection(context)) {
                ITypeInfo typeInfo = XafTypesInfo.Instance.FindTypeInfo(type);
                if(typeInfo != null && typeInfo.IsPersistent) {
                    persistentTypes.Add(type);
                }
            }
            return persistentTypes;
        }
    }
}
