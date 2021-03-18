using Intention;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Evaluators;
using GlobalUtils;
using System.Collections;

namespace Actors
{
    class BaseAgent : MonoBehaviour 
    {
        private Agent _agent = new Agent("Worker 1");

        public Urge wanderUrge = new Urge("Wander");


        //IEnumerator RandomValues()
        //{
        //    while(_agent != null)
        //    {
        //        yield return new WaitForSeconds(2);
        //        healthUrge.Value = GetLerpedRandomValue(healthUrge.Value);
        //        healthUrge.Weight = 1.2f;
        //        foodUrge.Value = GetLerpedRandomValue(foodUrge.Value);
        //        waterUrge.Value = GetLerpedRandomValue(waterUrge.Value);
        //        _agent.AddUrges(new List<Urge>() { healthUrge, foodUrge, waterUrge });
        //        Debug.Log(_agent.Act().Item2);
        //    }
        //}

        private float GetLerpedRandomValue(float value) { 
            return Mathf.Lerp(value, Random.Range(0f, 100f), 2f);
        }

        private Vector3 GetRoamingPosition(Vector3 startingPos)
        {
            return startingPos + Utils.GetRandomDirection() * Random.Range(10f, 70f);
        }

        //IEnumerator WanderAgent()
        //{

        //}

        private void Start()
        {
            //StartCoroutine(RandomValues());
        }
    }
}
