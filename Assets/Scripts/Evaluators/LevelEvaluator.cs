using System;

namespace Evaluators
{
    class LevelEvaluator : IEvaluator
    {
        public float Evalute(float input)
        {
            return (float)Math.Round(input / 100f, 2);
        }
    }
}
