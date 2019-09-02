using System;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;

namespace FeatureCenter.Module.Actions {

	public class ParametrizedActionValueTypeStringController : ActionBaseController {
		public ParametrizedActionValueTypeStringController() {
            this.TargetViewId = "ParametrizedActionRootObject_DetailView";
            ParametrizedAction parametrizedAction = new ParametrizedAction(this, "String", "StringValueParametrizedActions", typeof(string));
			parametrizedAction.ToolTip = ActionsDemoStrings.StringValueTooltip;
			parametrizedAction.Execute += new ParametrizedActionExecuteEventHandler(ParametrizedActionRootObject.parametrizedAction_Execute);
		}
        protected override bool IsSuitable(View view) {
            return this.TargetViewId == view.Id;
        }
	}

	public class ParametrizedActionValueTypeDateTimeController : ActionBaseController {
		public ParametrizedActionValueTypeDateTimeController() {
            this.TargetViewId = "ParametrizedActionRootObject_DetailView";
            ParametrizedAction parametrizedAction = new ParametrizedAction(this, "DateTime", "DateTimeValueParametrizedActions", typeof(DateTime));
			parametrizedAction.ToolTip = ActionsDemoStrings.DateTimeValueTooltip;
			parametrizedAction.Execute += new ParametrizedActionExecuteEventHandler(ParametrizedActionRootObject.parametrizedAction_Execute);
		}
        protected override bool IsSuitable(View view) {
            return this.TargetViewId == view.Id;
        }
	}

	public class ParametrizedActionValueTypeIntController : ActionBaseController {
		public ParametrizedActionValueTypeIntController() {
            this.TargetViewId = "ParametrizedActionRootObject_DetailView";
            ParametrizedAction parametrizedAction = new ParametrizedAction(this, "Integer", "IntValueParametrizedActions", typeof(int));
			parametrizedAction.ToolTip = ActionsDemoStrings.IntegerValueTooltip;
			parametrizedAction.Execute += new ParametrizedActionExecuteEventHandler(ParametrizedActionRootObject.parametrizedAction_Execute);
		}
        protected override bool IsSuitable(View view) {
            return this.TargetViewId == view.Id;
        }
	}

    public class ParametrizedActionValueTypeFloatController : ActionBaseController {
        public ParametrizedActionValueTypeFloatController() {
            this.TargetViewId = "ParametrizedActionRootObject_DetailView";
            ParametrizedAction parametrizedAction = new ParametrizedAction(this, "Float", "FloatValueParametrizedActions", typeof(float));
            parametrizedAction.ToolTip = ActionsDemoStrings.FloatValueTooltip;
            parametrizedAction.Execute += new ParametrizedActionExecuteEventHandler(ParametrizedActionRootObject.parametrizedAction_Execute);
        }
        protected override bool IsSuitable(View view) {
            return this.TargetViewId == view.Id;
        }
    }
    //TODO Boolean
    //public class ParametrizedActionValueTypeBooleanController : ActionBaseController {
    //    public ParametrizedActionValueTypeBooleanController() {
    //        this.TargetViewId = "ParametrizedActionRootObject_DetailView";
    //        ParametrizedAction parametrizedAction = new ParametrizedAction(this, "BooleanValue", "BooleanValueParametrizedActions", typeof(Boolean));
    //        parametrizedAction.ToolTip = ActionsDemoStrings.BooleanValueTooltip;
    //        parametrizedAction.Execute += new ParametrizedActionExecuteEventHandler(ParametrizedActionRootObject.parametrizedAction_Execute);
    //    }
    //}
}
