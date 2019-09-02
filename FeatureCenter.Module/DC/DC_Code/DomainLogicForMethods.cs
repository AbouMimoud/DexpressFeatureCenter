using System;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.Actions;

namespace FeatureCenter.Module.DC {
    [DomainComponent]
    public interface ITask {
        string Description { get; set; }
        DateTime DueDate { get; set; }
        [Aggregated]
        ITaskReport Report { get; set; }
        ITaskReport CreateReport(string text);
        void Postpone();
    }
    [DomainLogic(typeof(ITask))]
    public class ITask_Logic {
        // the AfterConstruction logic method is executed after an object is constructed
        // use this method to initialize properties with default values
        public static void AfterConstruction(ITask task) {
            task.DueDate = DateTime.Now.AddDays(1);
            task.Report = task.CreateReport("new task");
        }
        // specific logic methods are executed when the corresponding domain component method is called
        public void Postpone(ITask task) {
            task.DueDate = task.DueDate.AddDays(1);
            task.Report.Text = "postponed task";
        }        
        // you can use an IObjectSpace parameter in method logics to perform Object Space specific actions
        public static ITaskReport CreateReport(ITask task, IObjectSpace objectSpace, string text) {
            ITaskReport report = objectSpace.CreateObject<ITaskReport>();
            report.Text = text;
            return report;
        }
    }

    [DomainComponent]
    public interface ITaskReport {
        string Text { get; set; }
    }

    public class ITaskController : ViewController {
        private SimpleAction postponeAction;
        private void PostponeAction_Execute(object sender, SimpleActionExecuteEventArgs e) {
            ((ITask)View.CurrentObject).Postpone();
        }
        public ITaskController() {
            TargetObjectType = typeof(ITask);
            postponeAction = new SimpleAction(this, "Postpone", PredefinedCategory.Edit);
            postponeAction.SelectionDependencyType = SelectionDependencyType.RequireSingleObject;
            postponeAction.ToolTip = "Postpone the task to the next day";
            postponeAction.Execute += PostponeAction_Execute;
        }
    }
}
