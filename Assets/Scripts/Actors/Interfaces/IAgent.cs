using System;
using System.Collections.Generic;
using Urge = Intention.Urge;
using Selectors;

namespace Actors
{
    public interface IAgent
    {
        /// <summary>
        ///     Unique name for the agent
        /// </summary>
        string NameId { get; }

        /// <summary>
        ///     List of active urges for the agent
        /// </summary>
        List<Urge> Urges { get; set; }

        /// <summary>
        ///     Returns the selector associated with this AI.
        /// </summary>
        ISelector Selector { get; set; }
    }
}
