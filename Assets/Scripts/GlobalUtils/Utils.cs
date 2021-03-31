using System;
using System.Collections.Generic;
using UnityEngine;

namespace GlobalUtils
{
    class Utils
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

        /// <summary>
        ///     Lerping movement
        /// </summary>
        /// <param name="speed"></param>
        /// <param name="timePerStep"></param>
        /// <param name="agent"></param>
        /// <param name="target"></param>
        public static Vector2 SmoothMovement(float speed, float timePerStep, Vector2 agentPos, Vector2 targetPos)
        {
            float interpolation = speed * timePerStep;
            agentPos.x = Mathf.Lerp(agentPos.x, targetPos.x, interpolation);
            agentPos.y = Mathf.Lerp(agentPos.y, targetPos.y, interpolation);
            return agentPos;
        }

        /// <summary>
        ///     Converts float to int
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static int FloatToInt(float val)
        {
            return Mathf.RoundToInt(val);
        }

        /// <summary>
        ///     Check if agent in range of target
        /// </summary>
        /// <param name="agentPos"></param>
        /// <param name="targetPos"></param>
        /// <param name="distance"></param>
        /// <returns></returns>
        public static bool IsDistanceInRage(Vector2 agentPos, Vector2 targetPos, float distance)
        {
            return Vector2.Distance(agentPos, targetPos) < distance;
        }

        /// <summary>
        ///     Returns a random item from list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <returns></returns>
        public static T GetRandomItemFromList<T>(List<T> items)
        {
            return items[UnityEngine.Random.Range(0, items.Count)];
        }
    }
}
