using System;
using UnityEngine;

namespace GlobalUtils
{
    class Utils : MonoBehaviour
    {
        /// <summary>
        ///     Returns a random vector3
        /// </summary>
        /// <returns></returns>
        public static Vector3 GetRandomDirection()
        {
            return new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f)).normalized;
        }

        /// <summary>
        ///     Converts an angle to a vector3
        /// </summary>
        /// <param name="angle">0 - 360/param>
        /// <returns></returns>
        public static Vector3 GetVectorFromAngle(int angle)
        {
            float angleRad = angle * (Mathf.PI / 180f);
            return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
        }
    }
}
