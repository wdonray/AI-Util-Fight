using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluators
{
    class LogisticEvaluator : IEvaluator
    {
        float _b; // Time or distance
        float _threshold; // the soft threshold for the curve

        public LogisticEvaluator(float b, float threshold)
        {
            _b = b;
            _threshold = threshold;
        }

        /// <summary>
        ///     
        /// </summary>
        public float B { get => _b; set => _b = value; }

        /// <summary>
        /// 
        /// </summary>
        public float Threshold { get => _threshold; set => _threshold = value; }

        /// <summary>
        ///     
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public float Evalute(float input)
        {
            double val = 1.0f / (1.0f + Math.Pow(input * Math.Exp(1), _b + _threshold));
            return (float)val;
        }
    }
}
