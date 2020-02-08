using UnityEngine;


namespace FSM
{   
    /*
        Represents any agent that can think for itself
    */
    public class Agent : StateMachine
    {   
        [HideInInspector]
        public MovementComponent MovementComponent = null;
        public GameObject Target;

        public override void Awake() 
        {
            base.Awake();
            MovementComponent = GetComponent<MovementComponent>();
        }
        private void OnDrawGizmos() 
        {
            Gizmos.color = CurrentState.debugGizmoColour;
            Gizmos.DrawCube(gameObject.transform.position + (Vector3.up * 1.25f), new Vector3(0.5f, 0.5f, 0.5f));    
        }
    }
}