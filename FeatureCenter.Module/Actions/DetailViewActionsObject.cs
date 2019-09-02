using System.ComponentModel;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Demos;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace FeatureCenter.Module.Actions {
    [AutoCreatableObject]
    [ImageName(ActionsDemoStrings.ActionsInDetailViewImageName)]
    [System.ComponentModel.DisplayName(ActionsDemoStrings.ActionsInDetailViews)]
    [Hint(Hints.ActionsInDetailViewHint, ViewType.DetailView)]
    [NonPersistent]
    public class DetailViewActionsObjectRoot {
        private DetailViewActionsObject detailViewActionsObject = new DetailViewActionsObject();
        [ModelDefault("PropertyEditorType", "DevExpress.ExpressApp.Editors.DetailPropertyEditor")]
        public DetailViewActionsObject DetailViewActionsObject {
            get { return detailViewActionsObject; }
        }
    }
    [NonPersistent]
    public class DetailViewActionsObject : INotifyPropertyChanged {
        public DetailViewActionsObject() {
            name = "Object1";
        }
        private string name;
        private string log;
        public string Name {
            get { return name; }
            set { name = value; }
        }
        [NonPersistent]
        [VisibleInListView(false), VisibleInLookupListView(false), Size(SizeAttribute.Unlimited)]
        [ModelDefault("AllowEdit", "False")]
        public string Log {
            get { return log; }
            set {
                if(log != value) {
                    log = value;
                    OnPropertyChanged("Log");
                }
            }
        }
        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName) {
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
