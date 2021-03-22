using UnityEngine;

namespace AgentMovement
{
    /// <summary>
    ///     The score of each square is defined by this function f(n) = g(n) + h(n)
    /// </summary>
    class PathNode
    {
        /// <summary>
        ///     g(n) is the number of steps from point A (the Enemy’s position) to the current square.
        /// </summary>
        private int _stepsFromTargetToNode;
        /// <summary>
        ///     h(n) is the number of steps from the square being evaluated to the destination (in this case, the Player)
        /// </summary>
        private int _stepsFromNodeToDestination;
        /// <summary>
        ///     Coordinates
        /// </summary>
        private int _x, _y;
        /// <summary>
        ///     Can path be traversed
        /// </summary>
        private bool _walkable;
        /// <summary>
        ///     Position relative to the grid
        /// </summary>
        private Vector2 _worldPos;

        public int StepsFromTargetToNode { get => _stepsFromTargetToNode; set => _stepsFromTargetToNode = value; }
        public int StepsFromNodeToDestination { get => _stepsFromNodeToDestination; set => _stepsFromNodeToDestination = value; }
        public int X { get => _x; set => _x = value; }
        public int Y { get => _y; set => _y = value; }
        public bool Walkable { get => _walkable; set => _walkable = value; }
        public Vector2 WorldPos { get => _worldPos; set => _worldPos = value; }

        /// <summary>
        ///     
        /// </summary>
        public int GetScore { get => StepsFromNodeToDestination + StepsFromTargetToNode; }

        /// <summary>
        ///     
        /// </summary>
        /// <param name="nodeToCompare"></param>
        /// <returns></returns>
        public int CompareTo(PathNode nodeToCompare)
        {
            int compare = GetScore.CompareTo(nodeToCompare.GetScore);
            return compare == 0 ? StepsFromNodeToDestination.CompareTo(nodeToCompare.StepsFromNodeToDestination) : -compare;
        }

        public PathNode(bool walkable, Vector2 worldPos, int x, int y)
        {
            Walkable = walkable;
            WorldPos = worldPos;
            X = x;
            Y = y;
        }
    }
}
