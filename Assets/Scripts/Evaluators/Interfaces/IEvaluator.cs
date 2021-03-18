using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluators
{
    public interface IEvaluator
    {
        /// <summary>
        ///     Returns the value for the specified input;
        /// </summary>
        /// <param name="input">that value to evaulate</param>
        /// <returns></returns>
        float Evalute(float input);
    }
}
