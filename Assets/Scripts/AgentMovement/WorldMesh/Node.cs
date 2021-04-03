using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace AgentMovement
{
    class Node
    {
        //f(totalCost) = g(distCurrentStart) + h(heuristic)
        private int x, y, distCurrentStart, heuristic;
        private bool walkable;
        private Node parent;
        private GameObject nodeObject;

        public bool Walkable { get => walkable; set => walkable = value; }
        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public int TotalCost { get => distCurrentStart + heuristic; }
        public int DistCurrentStart { get => distCurrentStart; set => distCurrentStart = value; }
        public int Heuristic { get => heuristic; set => heuristic = value; }
        public Node Parent { get => parent; set => parent = value; }
        public GameObject NodeObject { get => nodeObject; set => nodeObject = value; }

        public Node(int x, int y, bool walkable)
        {
            X = x;
            Y = y;
            Walkable = walkable;
        }

        public Node(Node node)
        {
            X = node.X;
            Y = node.Y;
            Walkable = node.Walkable;
        }

        public bool Equals(Node other)
        {
            return (X == other.X && Y == other.Y);
        }
    }
}
