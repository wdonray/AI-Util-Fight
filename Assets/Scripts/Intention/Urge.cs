using System;

namespace Intention
{
    [Serializable]
    public class Urge
    {
        string _nameId;
       
        public float _value, _weight;

        #region Constructor 
        public Urge(string nameId)
        {
            _nameId = nameId;
            _value = 1.0f;
            _weight = 1.0f;
        }

        public Urge(string nameId, float value = 1.0f)
        {
            _nameId = nameId;
            _value = value;
            _weight = 1.0f;
        }

        public Urge(string nameId, float value = 1.0f, float weight = 1.0f)
        {
            _nameId = nameId;
            _value = value;
            _weight = weight;
        }
        #endregion

        public string NameId { get => _nameId; set => _nameId = value; }

        /// <summary>
        ///     The value associated with this urge
        /// </summary>
        public float Value { get => _value; set => _value = value; }

        /// <summary>
        ///     The weight associated with this urge
        /// </summary>
        public float Weight { get => _weight; set => _weight = value; }

        /// <summary>
        ///     Returns the Value * Weight
        /// </summary>
        public float Combined { get => Value * Weight; }

        /// <summary>
        ///     Gets a value indicating wheter the combined urge is zero
        /// </summary>
        public bool IsZero { get => Math.Abs(Combined) == 0f; }

        /// <summary>
        ///     Gets a value indicating wheter the combined urge is one
        /// </summary>
        public bool IsOne { get => Math.Abs(Combined) == 1.0f; }


        /// <summary>
        ///     Determines whether the specified urge is equal to the current
        /// </summary>
        /// <param name="other">The urge to compare with the current</param>
        /// <returns></returns>
        public bool Equals(Urge other) { return Value == other.Value && Weight == other.Weight; }

        #region Overrides
        public static bool operator >(Urge a, Urge b) { return a.Combined > b.Combined; }

        public static bool operator <(Urge a, Urge b) { return a.Combined < b.Combined; }

        public static bool operator >=(Urge a, Urge b) { return a.Combined >= b.Combined; }

        public static bool operator <=(Urge a, Urge b) { return a.Combined <= b.Combined; }

        public override string ToString() { return string.Format("[Urge: Value={0}, Weight={1}, Combined={2}]", Value, Weight, Combined); }
        #endregion
    }
}