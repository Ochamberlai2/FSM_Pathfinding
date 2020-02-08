using UnityEngine;

namespace FSM
{
  /*
    Base class for a FSM action
  */
  public abstract class Action : ScriptableObject
  {
          public abstract void Act(StateMachine stateMachine);
  }
}
