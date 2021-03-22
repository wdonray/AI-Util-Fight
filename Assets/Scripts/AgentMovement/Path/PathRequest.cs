using System;
using UnityEngine;

namespace AgentMovement
{
    class PathRequest
    {
        /// <summary>
        ///     Store the start and end path of the request
        /// </summary>
        private Vector3 _pathStart, _pathEnd;
        /// <summary>
        ///     A callback action to state the postions that were traversed and if they made it to the end goal or not
        /// </summary>
        private Action<Vector3[], bool> _callBack;
        /// <summary>
        ///     The agent that requested the path
        /// </summary>
        private string _agentID;

        public Vector3 PathStart { get => _pathStart; set => _pathStart = value; }
        public Vector3 PathEnd { get => _pathEnd; set => _pathEnd = value; }
        public Action<Vector3[], bool> CallBack { get => _callBack; set => _callBack = value; }
        public string AgentID { get => _agentID; set => _agentID = value; }

        /// <summary>
        ///     
        /// </summary>
        /// <param name="pathStart"></param>
        /// <param name="pathEnd"></param>
        /// <param name="callBack"></param>
        public PathRequest(string agentID, Vector3 pathStart, Vector3 pathEnd, Action<Vector3[], bool> callBack = null)
        {
            AgentID = agentID;
            PathStart = pathStart;
            PathEnd = pathEnd;
            CallBack = callBack;
        }
    }
}
