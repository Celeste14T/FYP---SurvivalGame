using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SurvivalPropertiesSystem.Scripts
{
    [System.Serializable]
    public class Property
    {
        [Tooltip("The name of the property")]
        public string name;

        [Tooltip("The maximum value of the property")]
        public float max;
        [Tooltip("The minimum value of the property")]
        public float min;

        [Tooltip("The initial value of the property")]
        public float initial;

        public float current
        {
            get { return m_current; }
            set { m_current = Mathf.Clamp(value, min, max); }
        }

        [Tooltip("How fast the property changes (negative numbers decrease the current value, positive numbers increase it, zero keeps it static)")]
        public float decay;

        [Tooltip("Whether to destroy the property once it reaches the minimum value (used for temporary properties)")]
        public bool destroyOnMinimum;

        [Tooltip("List of impacts the property has on other properties")]
        public List<Impact> impacts;

        private float m_current;

        /// <summary>
        /// Creates a new, disconnected copy of the current object
        /// </summary>
        public Property Clone()
        {
            var newProperty = this.MemberwiseClone() as Property;
            newProperty.impacts = impacts.Select(i => i.Clone()).ToList();

            return newProperty;
        }
    }
}
