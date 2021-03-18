using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Grid
{
    [Serializable]
    class Grid
    {
        /// <summary>
        ///     
        /// </summary>
        private LayerMask _unwalkableMask;
        /// <summary>
        ///     
        /// </summary>
        private Vector2 _gridWorldSize;
        /// <summary>
        ///     
        /// </summary>
        private float _nodeRadius;
        /// <summary>
        ///     
        /// </summary>
        private PathNode[,] _gridContainer;
        /// <summary>
        ///     
        /// </summary>
        private float _nodeDiameter;
        /// <summary>
        ///     
        /// </summary>
        private int _gridSizeX, _gridSizeY;

        public LayerMask UnwalkableMask { get => _unwalkableMask; set => _unwalkableMask = value; }
        public Vector2 GridWorldSize { get => _gridWorldSize; set => _gridWorldSize = value; }
        public float NodeRadius { get => _nodeRadius; set => _nodeRadius = value; }
        public float NodeDiameter { get => _nodeDiameter; set => _nodeDiameter = value; }
        public int GridSizeX { get => _gridSizeX; set => _gridSizeX = value; }
        public int GridSizeY { get => _gridSizeY; set => _gridSizeY = value; }
        internal PathNode[,] GridContainer { get => _gridContainer; set => _gridContainer = value; }

        /// <summary>
        ///     
        /// </summary>
        public int MaxSize { get => GridSizeX + GridSizeY; }

        /// <summary>
        ///     
        /// </summary>
        /// <param name="unwalkableMask"></param>
        /// <param name="gridWorldSize"></param>
        /// <param name="nodeRadius"></param>
        /// <param name="transform"></param>
        public Grid(LayerMask unwalkableMask, Vector2 gridWorldSize, float nodeRadius, Transform transform)
        {
            UnwalkableMask = unwalkableMask;
            GridWorldSize = gridWorldSize;
            NodeRadius = nodeRadius;
            NodeDiameter = NodeRadius * 2;
            GridSizeX = Mathf.RoundToInt(GridWorldSize.x / NodeDiameter);
            GridSizeY = Mathf.RoundToInt(GridWorldSize.y / NodeDiameter);
            CreateGrid(transform);
        }

        /// <summary>
        ///     
        /// </summary>
        /// <param name="worldTransform"></param>
        private void CreateGrid(Transform worldTransform)
        {
            GridContainer = new PathNode[GridSizeX, GridSizeY];
            Vector3 botLeft = worldTransform.position - Vector3.right * GridWorldSize.x / 2 - Vector3.forward * GridWorldSize.y / 2;

            for (int x = 0; x < GridSizeX; x ++)
            {
                for (int y = 0; y < GridSizeY; y ++)
                {
                    Vector3 worldPoint = botLeft + Vector3.right * (x * NodeDiameter + NodeRadius) + Vector3.forward * (y * NodeDiameter + NodeRadius);
                    bool walkable = !(Physics.CheckSphere(worldPoint, NodeRadius, UnwalkableMask));
                    GridContainer[x, y] = new PathNode(walkable, worldPoint, x, y);
                }
            }
            Console.WriteLine(GridContainer);
        }

        /// <summary>
        ///     
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public List<PathNode> GetNeighbours(PathNode node)
        {
            List<PathNode> nodes = new List<PathNode>();

            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    if (x == 0 && y == 0)
                        continue;

                    int checkX = node.X + x;
                    int checkY = node.Y + y;

                    if (checkX >= 0 && checkX < GridSizeX && checkY >= 0 && checkY < GridSizeY)
                    {
                        nodes.Add(GridContainer[checkX, checkY]);
                    }
                }
            }

            return nodes;
        }
    }
}
