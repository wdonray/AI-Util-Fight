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
        private bool isCameraMoving;

        private void Awake()
        {
            _camera = gameObject.GetComponent<Camera>();
        }

        private IEnumerator SmoothCameraMovement(Vector2 target)
        {
            while (!Utils.IsDistanceInRage(new Vector2(transform.position.x, transform.position.y), target, .10f))
            {
                isCameraMoving = true;
                var pos = Utils.SmoothMovement(Speed, Time.deltaTime, transform.position, target);
                transform.position = new Vector3(pos.x, pos.y, transform.position.z);
                yield return null;
            }
            isCameraMoving = false;
        }

        public void StartCameraMovement(Vector2 target)
        {
            if (!isCameraMoving) {
                StartCoroutine(SmoothCameraMovement(target));
                return;
            }
            StopAllCoroutines();
        }
    }
}
