using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;

namespace FeatureCenter.Module.Actions {
    public class ActionBaseRootObjectController : ViewController<DetailView> {
        public ActionBaseRootObjectController() {
            TargetObjectType = typeof(ActionBaseRootObject);
            TargetViewType = ViewType.DetailView;
        }
        protected override void OnActivated() {
            base.OnActivated();
            foreach(IFrameContainer item in View.GetItems<IFrameContainer>()) {
                ((ViewItem)item).ControlCreated += new EventHandler<EventArgs>(ActionBaseRootObjectController_ControlCreated);
            }
            foreach(Controller controller in Frame.Controllers) {
                if(controller is ActionBaseController) {
                    ((ActionBaseController)controller).SetBaseObject((ActionBaseRootObject)View.CurrentObject);
                }
            }
        }
        void ActionBaseRootObjectController_ControlCreated(object sender, EventArgs e) {
            if(((IFrameContainer)sender).Frame != null) {
                foreach(Controller controller in ((IFrameContainer)sender).Frame.Controllers) {
                    if(controller is ActionBaseController) {
                        ((ActionBaseController)controller).SetBaseObject((ActionBaseRootObject)View.CurrentObject);
                    }
                }
            }
        }

    }
	public class ActionBaseController : ViewController {
		public ActionBaseRootObject baseObject;
		protected string targetProperty;
		private void View_CurrentObjectChanged(object sender, EventArgs e) {
			if(View.CurrentObject != null && View.CurrentObject != GetFirstAction()) {
				if(View.CurrentObject is ActionBase) {
					View.CurrentObject = GetFirstAction();
				}
			}
		}
		private ActionBase GetFirstAction() {
			return Actions.FirstOrDefault();
		}
		private string GetTargetProperty() {
			if(string.IsNullOrEmpty(targetProperty)) {
				return GetFirstAction().Id;
			}
			return targetProperty;
		}
        protected virtual Boolean IsSuitable(View view) {
            return view.Id.Contains("_" + GetTargetProperty().Replace("Demo", "") + "_");
        }
		protected override void OnViewChanging(View view) {
			base.OnViewChanging(view);
			if(view != null) {
				Active["TargetPropertyName"] = IsSuitable(view);
				if(view is DetailView) {
					Active["TargetActionType"] = (view.Id.Contains(GetFirstAction().GetType().Name));
				}
			}
		}
		protected override void OnActivated() {
			base.OnActivated();
			View.CurrentObjectChanged += new EventHandler(View_CurrentObjectChanged);
		}

        public void SetBaseObject(ActionBaseRootObject baseObject) {
            this.baseObject = baseObject;
            if(baseObject != null) {
                Active["TargetActionType"] = baseObject.GetType().Name.Contains(GetFirstAction().GetType().Name);
            }
        }
		protected override void OnDeactivated() {
			View.CurrentObjectChanged -= new EventHandler(View_CurrentObjectChanged);
			base.OnDeactivated();
		}
		public void LogTrace(ActionBase action, params object[] parameter) {
			if(baseObject != null) {
				baseObject.LogExecuteAction(action, parameter);
			}
		}
	}
}
