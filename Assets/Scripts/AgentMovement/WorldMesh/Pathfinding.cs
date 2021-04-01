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

        private List<Node> ReconstructPath(Node current)
        {
            Stack<Node> path = new Stack<Node>();
            while (current != null)
            {
                path.Push(current);
                current = current.Parent;
            }
            return path.Reverse().ToList();
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

                if (currentNode == EndNode)
                    return ReconstructPath(currentNode);

                Stack<Node> children = new Stack<Node>();

                adjacentSquares.ForEach(newPos => {
                    var nodePos = new Vector2(currentNode.X + newPos.x, currentNode.Y + newPos.y);
                    if (!grid.Nodes.Find(node => new Vector2(node.X, node.Y) == newPos).Walkable)
                        return;
                    var newNode = new Node(currentNode);
                    children.Push(newNode);
                });

                children.ToList().ForEach(child => {
                    if (!ClosedList.Contains(child)) return;
                    child.DistCurrentStart = currentNode.DistCurrentStart + 1;
                    child.Heuristic = (child.X - EndNode.X) ^ 2 + (child.Y - EndNode.Y) ^ 2;

                    if (OpenList.ToList().Find(openNode => child == openNode && child.DistCurrentStart > openNode.DistCurrentStart) != null)
                        OpenList.Push(child);
                });

            }
            return OpenList.ToList();
        }
    }
}
