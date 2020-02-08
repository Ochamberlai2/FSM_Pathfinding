
using UnityEngine;
using Pathfinding;

public class MovementComponent : MonoBehaviour
{
    private Vector3 currentMovementGoal;
    private Vector3[] currentMovementPoints;

    public void GetPath(Vector3 worldPoint)
    {
        currentMovementPoints = AStar.AStarSearch(transform.position, worldPoint);
    }

}
