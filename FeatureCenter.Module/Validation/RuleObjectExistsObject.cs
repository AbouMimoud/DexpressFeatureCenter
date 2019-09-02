using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using DevExpress.Persistent.Validation;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Demos;

namespace FeatureCenter.Module.Validation {
    public class RuleObjectExistsCollectionObject : NamedBaseObject {
        private Subject itemSubject;
        private RuleObjectExistsObject owner;
        public RuleObjectExistsCollectionObject(Session session) : base(session) { }
        public Subject ItemSubject {
            get { return itemSubject; }
            set { SetPropertyValue("ItemSubject", ref itemSubject, value); }
        }
        [Association("RuleObjectExistsObject-RuleObjectExistsCollectionObjects")]
        public RuleObjectExistsObject Owner {
            get { return owner; }
            set { owner = value; }
        }
    }

	public enum Position { Student, Teacher }
	public enum Subject { Physics, Mathemathics, Biology }

	[NavigationItem(Captions.ValidationGroup), System.ComponentModel.DisplayName(Captions.Validation_RuleObjectExists)]
	[Hint(Hints.RuleObjectExistsHint)]
    [RuleObjectExists("RuleObjectExistsObject_RuleObjectExists", DefaultContexts.Save, "Subject = '@Subject' AND Position = 'Teacher'", SkipNullOrEmptyValues = true, TargetCriteria = "Position = 'Student'")]
    [ImageName("Validation.Demo_Rule_Object_Exists")]
    public class RuleObjectExistsObject : ValidationDemoBaseObject {
		private string personName;
		private Position position;
		private Subject subject;

		public RuleObjectExistsObject(Session session) : base(session) { }

		public string PersonName {
			get { return personName; }
			set { SetPropertyValue("PersonName", ref personName, value); }
		}
		public Position Position {
			get { return position; }
			set { SetPropertyValue("Position", ref position, value); }
		}
		public Subject Subject {
			get { return subject; }
			set { SetPropertyValue("Subject", ref subject, value); }
		}
        [RuleObjectExists("ObjectExists1", DefaultContexts.Save, @"[ItemSubject] = '@Owner.Subject' or Contains([Name], [Owner.Name])", IncludeCurrentObject = true)]
        [Association("RuleObjectExistsObject-RuleObjectExistsCollectionObjects"), Aggregated]
        public XPCollection<RuleObjectExistsCollectionObject> Collection {
            get { return GetCollection<RuleObjectExistsCollectionObject>("Collection"); }
        }
	}
}
