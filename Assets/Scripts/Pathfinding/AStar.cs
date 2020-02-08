using System.Collections.Generic;
using UnityEngine;
using System;

namespace Pathfinding
{
    /*
        Logic to conduct an A* search for use in pathfinding
    */
    public static class AStar
    {
        public static Vector3[] AStarSearch(Vector3 startPosition, Vector3 goalPosition)
        {
            bool pathSuccess = false;
            Node startNode = PathfindingGrid.Instance.NodeFromWorldPoint(startPosition); 
            Node endNode =  PathfindingGrid.Instance.NodeFromWorldPoint(goalPosition); 

            Heap<Node> frontier = new Heap<Node>(PathfindingGrid.Instance.maxSize);
            HashSet<Node> visited = new HashSet<Node>();

            frontier.Add(startNode);
            if(startNode.walkable && endNode.walkable)
            {
                while(frontier.Count > 0)
                {
                    Node currentNode = frontier.RemoveFirst();
                    visited.Add(currentNode);

                    //If the current node is the goal, break out of the loop early
                    if(currentNode == endNode)
                    {
                        pathSuccess = true;
                        break;
                    }

                    List<Node> currentNeighbours = PathfindingGrid.Instance.GetNeighbours(currentNode);
                    for(int i = 0; i < currentNeighbours.Count; i++)
                    {
                        if(!currentNeighbours[i].walkable || visited.Contains(currentNeighbours[i]))
                            continue;

                        //get movement cost to neighbour
                        int movementCost = currentNode.gCost + GetDistance(currentNode, currentNeighbours[i]);

                        if (movementCost < currentNeighbours[i].gCost || !frontier.Contains(currentNeighbours[i]))
                        {
                            //set the g and h costs and also set the parent
                            currentNeighbours[i].gCost = movementCost;
                            currentNeighbours[i].hCost = GetDistance(currentNeighbours[i], endNode);
                            currentNeighbours[i].parentNode = currentNode;
                        }
                        //if open doesnt contain the neighbour, we need to add it
                        if (!frontier.Contains(currentNeighbours[i]))
                        {
                            frontier.Add(currentNeighbours[i]);
                        }
                        else
                        {
                            frontier.UpdateItem(currentNeighbours[i]);
                        }
                    }
                    if(pathSuccess)
                    {
                        return RetracePath(startNode, endNode);
                    }
                }
            }
            //no path has been found
            return null;
        }
        private static Vector3[] RetracePath(Node startNode, Node targetNode)
        {
            //set an empty list
            List<Node> path = new List<Node>();
            //set the current node to being the target
            Node currentNode = targetNode;
            //and while the current node isnt the start node
            while (currentNode != startNode)
            {
                //continue adding the nodes to the path
                path.Add(currentNode);
                //and alter current node to be the parent of the previous one
                currentNode = currentNode.parentNode;
            }
            Vector3[] waypoints = SimplifyPath(path);
            Array.Reverse(waypoints);

            return waypoints;
        }
        private static Vector3[] SimplifyPath(List<Node> path)
        {
            List<Vector3> waypoints = new List<Vector3>();
            Vector2 directionOld = Vector2.zero;
            for (int i = 1; i < path.Count; i++)
            {
                Vector2 directionNew = new Vector2(path[i].gridX - path[i-1].gridX, path[i].gridY - path[i-1].gridY);
                if (directionNew != directionOld)
                {
                    waypoints.Add(path[i-1].WorldPosition);
                }
                directionOld = directionNew;
            }
            return waypoints.ToArray();
        }
        //using 1 as the movement left, right, up or down, and sqrt(2) for diagonal movement, both multiplied by 10
        private static int GetDistance(Node nodeA, Node nodeB)
        {
            int dstX = (int)Mathf.Abs(nodeA.gridX - nodeB.gridX);
            int dstY = (int)Mathf.Abs(nodeA.gridY - nodeB.gridY);

            return 10 * (dstX + dstY) + (14 - 2 * 10) * Mathf.Min(dstX, dstY);
        }
    }
}