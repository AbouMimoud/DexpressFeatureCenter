using System.ComponentModel;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Demos;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace FeatureCenter.Module.Actions {
    [NonPersistent]
    public class ActionEnabled {
        public ActionEnabled(ActionBaseRootObject owner) {
            this.Owner = owner;
        }
        [Browsable(false)]
        public ActionBaseRootObject Owner;
    }

	[NonPersistent]
	[ImageName(ActionsDemoStrings.SimpleActionImageName)]
	[NavigationItem(ActionsDemoStrings.NavBarGroupName)]
	[System.ComponentModel.DisplayName(ActionsDemoStrings.SimpleAction)]
	[Hint(Hints.SimpleActionHint, ViewType.DetailView)]
	public class SimpleActionRootObject : ActionBaseRootObject {
		private SimpleAction properties = new SimpleAction();
		public static void simpleAction_Execute(object sender, SimpleActionExecuteEventArgs e) {
			if(((ActionBase)sender).Controller is ActionBaseController) {
				((ActionBaseController)((ActionBase)sender).Controller).LogTrace(e.Action);
			}
		}
        [EditorAlias(EditorAliases.DetailPropertyEditor)]
		[ModelDefault("VisibleProperties", "Caption, ToolTip, ImageName")]
		public SimpleAction SimpleAction {
			get { return properties; }
		}
        [ModelDefault(CustomDetailViewItemsGenarator.TabPageNameAttribute, "Enabled")]
        [Index(9)]
        [Aggregated, EditorAlias(EditorAliases.DetailPropertyEditor), ExpandObjectMembers(ExpandObjectMembers.Never)]
        public ActionEnabled Enabled {
            get { return new ActionEnabled(this); }
        }
    }

}
