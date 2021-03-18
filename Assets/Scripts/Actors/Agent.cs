using System.Collections;
using System.Collections.Generic;
using Urge = Intention.Urge;
using Selectors;
using System.Linq;

namespace Actors
{
    public class Agent : IAgent
    {
        public string NameId { get; set; }
        List<Urge> _urges { get; set; }
        ISelector _selector;

        /// <summary>
        ///     Gets or sets the selector
        /// </summary>
        public ISelector Selector { get => _selector; set => _selector = value ?? _selector; }

        /// <summary>
        ///     Gets or sets the Urges
        /// </summary>
        public List<Urge> Urges { get => _urges; set => _urges = value; }

        /// <summary>
        ///     Initialize the agent
        /// </summary>
        void Awake() {
            Urges = new List<Urge>();
            Selector = new HighestScoreSelector();
        }

        /// <summary>
        ///     Initializes a new instance of the Agent class
        /// </summary>
        public Agent(string nameId) {
            if (string.IsNullOrEmpty(nameId)) {
                throw new System.Exception("Check Params");
            }
            NameId = nameId;
            Awake();
        }

        /// <summary>
        ///     Initializes a new instance of the Agent class
        /// </summary>
        public Agent(string nameId, ICollection<Urge> urges) {
            if (string.IsNullOrEmpty(nameId) || urges == null) {
                throw new System.Exception("Check Params");
            }
            NameId = nameId;
            Urges = urges.ToList();
            Awake();
        }

        /// <summary>
        ///     
        /// </summary>
        /// <returns></returns>
        internal (int, string) Act() {
            int selectedIndex = Selector.Select(_urges);
            string nameId = _urges[selectedIndex].NameId;
            //_urges[selectedIndex].Value = 0f;
            return (selectedIndex, nameId);
        }

        /// <summary>
        ///     Adds the urge the the list if it does not already exist
        /// </summary>
        /// <param name="urge">The urge to add</param>
        /// <returns></returns>
        internal void AddUrge(Urge urge) {
            int urgeFoundIndex = _urges.FindIndex(x => x.NameId == urge.NameId);

            if (urgeFoundIndex != -1) {
                _urges[urgeFoundIndex] = urge;
            } 
            else {
                _urges.Add(urge);
            }
        }

        /// <summary>
        ///     Adds or update the urges
        /// </summary>
        /// <param name="urges">Add each urge to collection</param>
        /// <returns></returns>
        internal void AddUrges(ICollection<Urge> urges)
        {
            List<Urge> collectionList = urges.ToList();

            for (int i = 0; i < collectionList.Count(); i++) {
                AddUrge(collectionList[i]);
            };
        }

        /// <summary>
        ///     Removes the given urge if exist in list
        /// </summary>
        /// <param name="urge">The urge to be removed</param>
        /// <returns></returns>
        internal bool RemoveUrge(Urge urge) {
            if (_urges.Contains(urge) == false) {
                return false;
            }
            _urges.Remove(urge);
            return true;
        }
    }
}
