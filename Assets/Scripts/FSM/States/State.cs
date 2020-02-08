using UnityEngine;


namespace FSM
{
    /*
        Generic state class for use in finite state machines
    */
    [CreateAssetMenu(menuName = "FSM/State")]
    public class State : ScriptableObject
    {

        public Action[] Actions; // list of actions to be executed while in this state
        public Transition[] Transitions;// list of transitions to evaluate while in state, to transition to other states
        public Color debugGizmoColour = Color.gray;// colour of debug gizmo to represent being in this state

        

        public void Tick(StateMachine stateMachine)
        {
            HandleActions(stateMachine);
            HandleTransitions(stateMachine);
        }

        protected void HandleActions(StateMachine stateMachine)
        {
            for (int i = 0; i < Actions.Length; i++)
            {
                Actions[i].Act(stateMachine);
            }
        }

        protected void HandleTransitions(StateMachine stateMachine)
        {
            //Loop through transitions, figure out if a transition should be made and transition to it
            for(int i = 0; i < Transitions.Length; i++)
            {
                if (Transitions[i].Decision.Evaluate(stateMachine) == Transitions[i].TransitionCondition)
                {
                    for(int j = 0; j < Transitions[i].ExitActions.Length; j++)
                    {
                        Transitions[i].ExitActions[j].Act(stateMachine);
                    }
                    stateMachine.CurrentState = Transitions[i].TransitionState;
                    for(int j = 0; j < Transitions[i].EntryActions.Length; j++)
                    {
                        Transitions[i].EntryActions[j].Act(stateMachine);
                    }
                    //on the first transition success, return so we dont move to the next one
                    return;
                }
            }
            //if no transition is found, it will stay in this state
        }
    }
}