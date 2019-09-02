using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Demos;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace FeatureCenter.Module.Actions {

	[NonPersistent]
	[ImageName(ActionsDemoStrings.ParametrizedActionImageName)]
	[NavigationItem(ActionsDemoStrings.NavBarGroupName)]
	[System.ComponentModel.DisplayName(ActionsDemoStrings.ParametrizedAction)]
	[Hint(Hints.ParametrizedActionHint, ViewType.DetailView)]
	public class ParametrizedActionRootObject : ActionBaseRootObject {
		private ParametrizedAction properties = new ParametrizedAction();
		private ParametrizedAction stringValue = new ParametrizedAction();
		private ParametrizedAction dateTimeValue = new ParametrizedAction();
		private ParametrizedAction intValue = new ParametrizedAction();
        private ParametrizedAction floatValue = new ParametrizedAction();
        //private ParametrizedAction booleanValue = new ParametrizedAction();
		public static void parametrizedAction_Execute(object sender, ParametrizedActionExecuteEventArgs e) {
			if(((ActionBase)sender).Controller is ActionBaseController) {
				((ActionBaseController)((ActionBase)sender).Controller).LogTrace(e.Action, e.ParameterCurrentValue);
			}
		}
        [ModelDefault(CustomDetailViewItemsGenarator.ActionsContainerAttribute, "StringValueParametrizedActions")]
        [ModelDefault(CustomDetailViewItemsGenarator.TabPageNameAttribute, "ValueType")]
		[Index(40)]
		public ParametrizedAction StringValue {
			get { return stringValue; }
		}
        [ModelDefault(CustomDetailViewItemsGenarator.ActionsContainerAttribute, "DateTimeValueParametrizedActions")]
        [ModelDefault(CustomDetailViewItemsGenarator.TabPageNameAttribute, "ValueType")]
		[Index(50)]
		public ParametrizedAction DateTimeValue {
			get { return dateTimeValue; }
		}
        [ModelDefault(CustomDetailViewItemsGenarator.ActionsContainerAttribute, "IntValueParametrizedActions")]
        [ModelDefault(CustomDetailViewItemsGenarator.TabPageNameAttribute, "ValueType")]
		[Index(60)]
		public ParametrizedAction IntValue {
			get { return intValue; }
		}
        [ModelDefault(CustomDetailViewItemsGenarator.ActionsContainerAttribute, "FloatValueParametrizedActions")]
        [ModelDefault(CustomDetailViewItemsGenarator.TabPageNameAttribute, "ValueType")]
        [Index(60)]
        public ParametrizedAction FloatValue {
            get { return floatValue; }
        }
        //TODO Boolean
        //[ModelDefault(CustomDetailViewItemsGenarator.ActionsContainerAttribute, "BooleanValueParametrizedActions")]
        //[ModelDefault(CustomDetailViewItemsGenarator.TabPageNameAttribute, "ValueType")]
        //[Index(60)]
        //public ParametrizedAction BooleanValue {
        //    get { return booleanValue; }
        //}
        [ModelDefault(CustomDetailViewItemsGenarator.VisiblePropertiesAttribute, "Caption, ShortCaption, ToolTip, ImageName, Value")]
		public ParametrizedAction ParametrizedAction {
			get { return properties; }
		}
	}

}
