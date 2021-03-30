using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentMovement
{
    class Node
    {
        private int x, y;
        private bool walkable;

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public bool Walkable { get => walkable; set => walkable = value; }

        public Node(int x, int y, bool walkable)
        {
            X = x;
            Y = y;
            Walkable = walkable;
        }
    }
}
