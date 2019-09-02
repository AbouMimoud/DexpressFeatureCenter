using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.StateMachine;
using FeatureCenter.Module.Northwind;
using DevExpress.ExpressApp.Xpo;

namespace FeatureCenter.Module.StateMachine {

    public enum TaskStatus { Draft, NotStarted, InProgress, Paused, Completed, Dropped }

    [NavigationItem]
    [Persistent("StateMachineTask")]
    [ImageName("BO_Task")]
    public class Task : BaseObject, IStateMachineProvider {
        public Task(Session session)
            : base(session) { }

        public string Subject {
            get { return GetPropertyValue<string>("Subject"); }
            set { SetPropertyValue<string>("Subject", value); }
        }
        public Employee AssignedTo {
            get { return GetPropertyValue<Employee>("AssignedTo"); }
            set { SetPropertyValue<Employee>("AssignedTo", value); }
        }
        public TaskStatus Status {
            get { return GetPropertyValue<TaskStatus>("Status"); }
            set { SetPropertyValue<TaskStatus>("Status", value); }
        }

        #region IStateMachineProvider Members

        public IList<IStateMachine> GetStateMachines() {
            List<IStateMachine> result = new List<IStateMachine>();
            result.Add(new TaskStatusStateMachine(XPObjectSpace.FindObjectSpaceByObject(this)));
            return result;
        }

        #endregion
    }
}
