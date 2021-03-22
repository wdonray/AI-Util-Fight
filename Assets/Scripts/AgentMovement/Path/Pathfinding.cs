using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace AgentMovement
{
    class Pathfinding : MonoBehaviour
    {
        PathRequestManager requestManager;
        Grid grid;

        void Awake()
        {
            requestManager = GetComponent<PathRequestManager>();
            grid = GridManager.Grid;
        }

        public void StartFindPath(Vector3 startPos, Vector3 targetPos)
        {

        }

        //IEnumerator FindPath(Vector3 startPos, Vector3 targetPos)
        //{
        //    Vector3[] waypoints = new Vector3[0];
        //}
    }
}
