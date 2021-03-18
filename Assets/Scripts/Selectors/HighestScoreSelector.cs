using Intention;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selectors
{
    class HighestScoreSelector : ISelector
    {
        /// <summary>
        ///     Selects the highest score urge
        /// </summary>
        /// <param name="urges">The Urges</param>
        /// <returns></returns>
        public int Select(ICollection<Urge> urges)
        {
            int count = urges.Count;

            if (count == 0 || count == 1) {
                return 0;
            }

            List <Urge> collectionList = urges.ToList();
            float maxUrgeValue = 0.0f;
            int selectionIndex = 0;

            for(var i = 0; i < count; i++)
            {
                (selectionIndex, maxUrgeValue) = GetHighestScoreIndex(collectionList, maxUrgeValue, selectionIndex, i);
            }

            return selectionIndex;
        }
        
        /// <summary>
        ///     Returns the highest scores index
        /// </summary>
        /// <param name="collectionList"></param>
        /// <param name="maxUrgeValue"></param>
        /// <param name="selectionIndex"></param>
        /// <param name="currentIndex"></param>
        /// <returns></returns>
        private (int, float) GetHighestScoreIndex(List<Urge> collectionList, float maxUrgeValue, int selectionIndex, int currentIndex)
        {
            float urgeCombination = collectionList[currentIndex].Combined;

            if (urgeCombination > maxUrgeValue)
            {
                maxUrgeValue = urgeCombination;
                selectionIndex = currentIndex;
            }

            return (selectionIndex, maxUrgeValue);
        }
    }
}
