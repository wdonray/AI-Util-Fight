using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace AgentMovement
{
    class AIPathfindingMovement : MonoBehaviour
    {
        /// <summary>
        ///     Needs to be in stats
        /// </summary>
        private float _speed = 30f;
        /// <summary>
        ///     List of paths for AI
        /// </summary>
        private List<Vector3> _pathVectorList;
        /// <summary>
        ///     Current path AI is going to
        /// </summary>
        private int _currentPathIndex;
        /// <summary>
        ///     Current directions
        /// </summary>
        public Vector3 MoveDirection, LastMoveDirection;
        /// <summary>
        ///     
        /// </summary>
        private float _pathFindingTimer;

        private void Update()
        {
            _pathFindingTimer -= Time.deltaTime;

        }


    }
}
