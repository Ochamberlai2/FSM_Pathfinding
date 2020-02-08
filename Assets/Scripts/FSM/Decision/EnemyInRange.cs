using FSM;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Decisions/EnemyInRange")]
public class EnemyInRange : Decision
{
    [SerializeField]
    private float visionRange = 5f;
    public override bool Evaluate(StateMachine stateMachine)
    {
        Agent agent = stateMachine as Agent;
        return Vector3.Distance(stateMachine.transform.position,agent.Target.transform.position) < visionRange;
    }
}