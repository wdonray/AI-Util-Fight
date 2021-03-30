using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentMovement
{
    // Add variable for chance
    class Grid
    {
        private int rowLength, colLength;

        private List<Node> nodes;

        public int RowLength { get => rowLength; set => rowLength = value; }
        public int ColLength { get => colLength; set => colLength = value; }
        public List<Node> Nodes { get => nodes; set => nodes = value; }

        public Grid(int rows, int cols)
        {
            rowLength = rows;
            colLength = cols;
            nodes = new List<Node>(rowLength * colLength);
        }

        public void CreateGrid()
        {
            Random rand = new Random();
            for (int x = 0; x < rowLength; x++)
            {
                for (int y = 0; y < colLength; y++)
                {
                    nodes.Add(new Node(x, y, (rand.Next(0, 100) > 10)));
                }
            }
        }
    }
}
