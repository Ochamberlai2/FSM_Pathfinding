using UnityEngine;
using FSM;
using Pathfinding;

[CreateAssetMenu(menuName = "FSM/Actions/Seek")]
public class Seek : Action
{
    [SerializeField]
    float distanceBeforeRefreshingPath = 3f; 
    public override void Act(StateMachine stateMachine)
    {
        Agent agent = stateMachine as Agent;
        MovementComponent movementComponent = agent.MovementComponent;
        if(movementComponent.currentMovementPoints == null)
            movementComponent.GetPath(agent.Target.transform.position);
        
        movementComponent.MoveToCurrentPoint();
        

    }
}
