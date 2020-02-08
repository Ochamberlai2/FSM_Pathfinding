using Sirenix.OdinInspector;
using UnityEngine;


namespace FSM
{
    public abstract class StateMachine : SerializedMonoBehaviour
    {

        [Required]
        public State CurrentState;

        public virtual void Awake() 
        {
            if(CurrentState == null)
                throw new System.Exception(gameObject.name + " does not have a default state assigned");     
        }
        public virtual void FixedUpdate()
        {
            CurrentState.Tick(this);
        }
    }
}