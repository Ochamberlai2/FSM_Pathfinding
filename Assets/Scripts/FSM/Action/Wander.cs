using FSM;
using Pathfinding;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Actions/Wander")]
public class Wander : Action
{
   [SerializeField]
   private float wanderRadius = 15f;
   public override void Act(StateMachine sm)
   {
      Agent agent = sm as Agent;
      MovementComponent agentMoveComponent = agent.MovementComponent;

      if(agentMoveComponent.pathComplete)
      {

         Vector3 randomPos = agent.transform.position + (Random.insideUnitSphere * wanderRadius);
         Node worldNode = null;

         while(worldNode == null)
         {
            worldNode = PathfindingGrid.Instance.NodeFromWorldPoint(randomPos);
         }
         agentMoveComponent.GetPath(randomPos);
       
      }
      if(agentMoveComponent.currentMovementPoints != null)
      {
         agentMoveComponent.MoveToCurrentPoint();
      }

   }
}
