
using UnityEngine;
using Pathfinding;

/*
    Component to be used by any moving agent
*/
[RequireComponent(typeof(Transform))]
public class MovementComponent : MonoBehaviour
{
    public Vector3 currentMovementGoal;
    public Vector3[] currentMovementPoints = new Vector3[0];
    public bool pathComplete = true;
    [SerializeField]
    private float speed = 4f;

    [SerializeField]
    private float goalReachedRadius = 0.1f;
    private int currentGoalIndex = 0;



    public void GetPath(Vector3 worldPoint)
    {
        currentMovementPoints = AStar.AStarSearch(transform.position, worldPoint);
        if(currentMovementPoints.Length > 0)
        {
            currentMovementGoal = currentMovementPoints[0];
            currentGoalIndex = 0;
            pathComplete = false;
        }
    }

    public void MoveToCurrentPoint()
    {
        if(currentMovementPoints.Length > 0 && Vector3.Distance(transform.position, currentMovementPoints[currentMovementPoints.Length-1]) <= goalReachedRadius)
        {
            pathComplete = true;
        }
        //if the current movement goal has been reached, set the current movement point to the next. 
        if(Vector3.Distance(transform.position, currentMovementGoal) <= goalReachedRadius && currentGoalIndex < currentMovementPoints.Length)
        {
            currentMovementGoal = currentMovementPoints[currentGoalIndex++];
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, currentMovementGoal, speed * Time.deltaTime);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(currentMovementGoal,0.33f);    
    }

}
