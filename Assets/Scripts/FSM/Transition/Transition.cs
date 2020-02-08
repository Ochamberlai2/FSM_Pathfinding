using Sirenix.OdinInspector;


namespace FSM
{
    /*
        Represents a transition from one state to another. Includes a list of actions to occur on entry into the next state and a list to be used on exit from current state
    */
    [System.Serializable]
    public class Transition
    {
        public Decision Decision;
        public State TransitionState;
        [Title("Set of actions to be executed on state change", Bold = false)]
        public Action[] ExitActions;
        public Action[] EntryActions;
        [Title("If this is ticked, the transition will occur if decision is true",Bold = false)]
        public bool TransitionCondition;
    }
}