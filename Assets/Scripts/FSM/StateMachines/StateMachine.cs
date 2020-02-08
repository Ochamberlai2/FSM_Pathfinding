using Sirenix.OdinInspector;
using UnityEngine;


namespace FSM
{
    public abstract class StateMachine : SerializedMonoBehaviour
    {

        [Required]
        public State CurrentState;


        public virtual void FixedUpdate()
        {
            CurrentState.Tick(this);
        }
    }
}