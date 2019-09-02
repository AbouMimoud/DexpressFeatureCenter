using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;

namespace FeatureCenter.Module.Reports {
    [System.ComponentModel.DefaultProperty("Title")]
    public class Position : BaseObject {
        private string title;

        public Position(Session session)
            : base(session) {
        }

        [RuleRequiredField("RuleRequiredField for Position.Title", DefaultContexts.Save)]
        public string Title {
            get {
                return title;
            }
            set {
                SetPropertyValue("Title", ref title, value);
            }
        }
    }
}
