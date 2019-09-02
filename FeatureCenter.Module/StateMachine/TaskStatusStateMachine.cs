using System;
using System.Drawing;
using System.Collections.Generic;

using DevExpress.ExpressApp;
using DevExpress.ExpressApp.StateMachine;
using DevExpress.ExpressApp.StateMachine.NonPersistent;

namespace FeatureCenter.Module.StateMachine {
    public class TaskStatusStateMachine : StateMachine<Task>, IStateMachineUISettings {
        private IState startState;

        public TaskStatusStateMachine(IObjectSpace objectSpace)
            : base(objectSpace) {
            startState = new State(this, TaskStatus.Draft);
            IState notStartedState = new State(this, "Not Started", TaskStatus.NotStarted);
            IState inProgressState = new State(this, "In Progress", TaskStatus.InProgress);
            IState pausedState = new State(this, TaskStatus.Paused);
            IState completedState = new State(this, TaskStatus.Completed);
            IState droppedState = new State(this, TaskStatus.Dropped);

            startState.Transitions.Add(new Transition(notStartedState));
            notStartedState.Transitions.Add(new Transition(startState));
            notStartedState.Transitions.Add(new Transition(inProgressState));
            //inProgressState.Transitions.Add(new Transition(startState));
            inProgressState.Transitions.Add(new Transition(pausedState, pausedState.Caption, 0));
            Transition completedTransition = new Transition(completedState, completedState.Caption, 1);
            completedTransition.SaveAndCloseView = true;
            inProgressState.Transitions.Add(completedTransition);
            inProgressState.Transitions.Add(new Transition(droppedState, droppedState.Caption, 2));
            pausedState.Transitions.Add(new Transition(inProgressState));
            droppedState.Transitions.Add(new Transition(notStartedState));

            StateAppearance inProgressAppearance = new StateAppearance(inProgressState);
            inProgressAppearance.TargetItems = "Subject";
            inProgressAppearance.Enabled = false;
            StateAppearance completedAppearance = new StateAppearance(completedState);
            completedAppearance.TargetItems = "Subject";
            completedAppearance.Enabled = false;
            StateAppearance pausedAppearance = new StateAppearance(pausedState);
            pausedAppearance.TargetItems = "*";
            pausedAppearance.BackColor = Color.Yellow;

            States.Add(startState);
            States.Add(notStartedState);
            States.Add(inProgressState);
            States.Add(pausedState);
            States.Add(completedState);
            States.Add(droppedState);
        }

        public override string Name {
            get { return "Change status to"; }
        }
        public override IState StartState { get { return startState; } }
        public override string StatePropertyName {
            get { return "Status"; }
        }

        public bool ExpandActionsInDetailView {
            get { return true; }
        }
    }
}
