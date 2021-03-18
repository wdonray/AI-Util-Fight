using System;
using System.Collections.Generic;
using Urge = Intention.Urge;

namespace Selectors
{
    public interface ISelector
    {
        /// <summary>
        ///     Selects a urge from the given set and returns the index
        /// </summary>
        /// <param name="urges">The urges</param>
        /// <returns></returns>
        int Select(ICollection<Urge> urges);
    }
}
