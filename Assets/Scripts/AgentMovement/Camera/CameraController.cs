using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using GlobalUtils;
using System.Collections;

namespace AgentMovement
{
    class CameraController : MonoBehaviour
    {
        public float Speed;

        private Camera _camera;
        private void Awake()
        {
            _camera = gameObject.GetComponent<Camera>();
        }

        private IEnumerator SmoothCameraMovement(Vector2 target)
        {
            //Never stops
            while (transform.position.x != target.x || transform.position.y != target.y)
            {
                var pos = Utils.SmoothMovement(Speed, Time.deltaTime, transform.position, target);
                transform.position = new Vector3(pos.x, pos.y, transform.position.z);
                yield return null;
            }
        }

        public void StartCameraMovement(Vector2 target)
        {
            StartCoroutine(SmoothCameraMovement(target));
        }
    }
}
