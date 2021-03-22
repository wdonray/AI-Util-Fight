using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace AgentMovement
{
    class PathRequestManager : MonoBehaviour
    {
        /// <summary>
        ///     Queue up the path request
        /// </summary>
        private Queue<PathRequest> _pathRequests = new Queue<PathRequest>();
        /// <summary>
        ///     Store the current path request
        /// </summary>
        private PathRequest _currentPathRequest;
        /// <summary>
        ///     Instance of itself / singleton
        /// </summary>
        private static PathRequestManager _instance;


        public static PathRequestManager Instance { get => _instance; set => _instance = value; }

        private void Awake()
        {
            if (Instance != null && Instance != this) 
            { Destroy(gameObject); } 
            else { Instance = this; }


        }
    }
}
