using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using DevExpress.Persistent.Validation;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Demos;

namespace FeatureCenter.Module.Validation {
	public enum Sex { Male, Female }
	public enum TitleOfCourtesy { Mr, Mrs, Ms }

	[NavigationItem(Captions.ValidationGroup), System.ComponentModel.DisplayName(Captions.Validation_TailoredRule)]
	[Hint(Hints.CodeRuleHint)]
	[ImageName("Validation.Demo_Code_Rule")]
	public class CodeRuleObject : ValidationDemoBaseObject {
		private string personName;
		private Sex sex;
		private TitleOfCourtesy titleOfCourtesy;
		
		public CodeRuleObject(Session session) : base(session) { }
		
		public string PersonName {
			get { return personName; }
			set { SetPropertyValue("PersonName", ref personName, value); }
		}
		public Sex Sex {
			get { return sex; }
			set { SetPropertyValue("Sex", ref sex, value); }
		}
		public TitleOfCourtesy TitleOfCourtesy {
			get { return titleOfCourtesy; }
			set { SetPropertyValue("TitleOfCourtesy", ref titleOfCourtesy, value); }
		}
	}
	[CodeRule]
	public class CodeRuleObjectIsValidRule : RuleBase<CodeRuleObject> {
        private string usedProperty = "";
		protected override bool IsValidInternal(CodeRuleObject target, out string errorMessageTemplate) {
			if(string.IsNullOrEmpty(target.PersonName)) {
				errorMessageTemplate = "PersonName must be entered.";
                usedProperty = "PersonName";
				return false;
			}
            usedProperty = "TitleOfCourtesy";
			if(target.Sex == Sex.Male) {
				errorMessageTemplate = "Title of Courtesy for males must be 'Mr'.";
				return target.TitleOfCourtesy == TitleOfCourtesy.Mr;
			}
			else {
				errorMessageTemplate = "Title of Courtesy for a woman must be 'Ms', if she is not marred; otherwise, 'Mrs'.";
				return target.TitleOfCourtesy == TitleOfCourtesy.Mrs || target.TitleOfCourtesy == TitleOfCourtesy.Ms;
			}
		}
        public override System.Collections.ObjectModel.ReadOnlyCollection<string> UsedProperties {
            get {
                if(string.IsNullOrEmpty(usedProperty)) {
                    return base.UsedProperties;
                }
                return new List<string>(new string[] { usedProperty }).AsReadOnly();
            }
        }
		public CodeRuleObjectIsValidRule() : base("", "Save") {
            Properties.SkipNullOrEmptyValues = false;
        }
        public CodeRuleObjectIsValidRule(IRuleBaseProperties properties)
            : base(properties) {
        }
                                                                 
                                                                 
	}
}
