using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.ExpressApp.Demos;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;

namespace FeatureCenter.Module.Validation {
    [NavigationItem(Captions.ValidationGroup), System.ComponentModel.DisplayName(Captions.Validation_ErrorandWarning)]
    [Hint(Hints.SoftValidationHint)]
    [RuleCriteria("RuleInformation", DefaultContexts.Save, @"IsInformation = false", SkipNullOrEmptyValues = false, ResultType = ValidationResultType.Information)]
    [RuleCriteria("RuleWarning", DefaultContexts.Save, @"IsWarning = false", SkipNullOrEmptyValues = false, ResultType = ValidationResultType.Warning)]
    [RuleCriteria("RuleError", DefaultContexts.Save, @"IsError = false", SkipNullOrEmptyValues = false)]
    [ImageName("Validation.Demo_Soft_Validation")]
    public class ValidationErrorsAndWarningsFeatureObject : NamedBaseObject {
        public ValidationErrorsAndWarningsFeatureObject(Session session) : base(session) { }
        public bool IsInformation { get; set; }
        public bool IsWarning { get; set; }
        public bool IsError { get; set; }
    }
}
