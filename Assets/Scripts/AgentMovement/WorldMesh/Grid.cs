using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentMovement
{
    class Grid
    {
        private int rowLength, colLength;
        private List<Node> nodes;
        private int blockedChance;

        public int RowLength { get => rowLength; set => rowLength = value; }
        public int ColLength { get => colLength; set => colLength = value; }
        public List<Node> Nodes { get => nodes; set => nodes = value; }
        public int BlockedChance { get => blockedChance; set => blockedChance = value; }

        public Grid(int rows, int cols, int blockChance)
        {
            RowLength = rows;
            ColLength = cols;
            BlockedChance = blockChance;
            nodes = new List<Node>(rowLength * colLength);
        }

        public void CreateGrid()
        {
            Random rand = new Random();
            for (int x = 0; x < RowLength; x++)
            {
                for (int y = 0; y < ColLength; y++)
                {
                    Nodes.Add(new Node(x, y, (rand.Next(0, 100) > BlockedChance)));
                }
            }
        }
    }
}
