using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace AgentMovement
{
    class Pathfinding
    {
        private Node startNode, endNode;
        private Stack<Node> openList, closedList;

        public Node StartNode { get => startNode; set => startNode = value; }
        public Node EndNode { get => endNode; set => endNode = value; }
        internal Stack<Node> OpenList { get => openList; set => openList = value; }
        internal Stack<Node> ClosedList { get => closedList; set => closedList = value; }

        private List<Node> ReconstructPath(Stack<Node> closedList)
        {
            return closedList.Reverse().ToList();
        }

        public List<Node> AStar(Grid grid, Node startNode, Node endNode) {
            StartNode = startNode;
            EndNode = endNode;

            OpenList = new Stack<Node>();
            OpenList.Push(StartNode);
            ClosedList = new Stack<Node>();

            List<Vector2> adjacentSquares = new List<Vector2> 
            { new Vector2(0, -1), new Vector2(0, 1), new Vector2(-1, 0), new Vector2(1, 0) };

            while (OpenList.Count > 0)
            {
                Node currentNode = OpenList.Pop();
                ClosedList.Push(currentNode);

                if (currentNode.Equals( EndNode ))
                    return ReconstructPath(closedList);

                Stack<Node> neighbors = new Stack<Node>();

                //Grab Neighbors
                adjacentSquares.ForEach(newPos => {
                    var node = grid.Nodes.Find(node => new Vector2(currentNode.X + newPos.x, currentNode.Y + newPos.y) == newPos);
                    if (node.Walkable == false) return;
                    var newNode = new Node(currentNode);
                    neighbors.Push(newNode);
                });

                Node cheapestNode = null;
                //Push Cheapest
                neighbors.ToList().ForEach(child => {
                    if (ClosedList.Contains(child)) return;
                    child.DistCurrentStart = currentNode.DistCurrentStart + 1;
                    child.Heuristic = (child.X - EndNode.X) ^ 2 + (child.Y - EndNode.Y) ^ 2;

                    // I hate this block
                    if (cheapestNode == null){
                        cheapestNode = child;
                    }
                    else if (child.DistCurrentStart > cheapestNode.DistCurrentStart){
                        cheapestNode = child;
                    }

                    if (cheapestNode != null && !OpenList.Contains(cheapestNode)) OpenList.Push(cheapestNode);
                });
            }
            return ClosedList.ToList();
        }
    }
}
