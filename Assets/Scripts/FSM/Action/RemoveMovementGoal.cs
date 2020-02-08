using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;

[CreateAssetMenu(menuName="FSM/Actions/RemoveMovementGoal")]
public class RemoveMovementGoal : Action
{
    public override void Act(StateMachine stateMachine)
    {
        Agent agent = stateMachine as Agent;
        agent.MovementComponent.currentMovementPoints = null;

    }
}
