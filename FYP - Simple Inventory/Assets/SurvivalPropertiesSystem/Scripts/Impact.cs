using System;
using UnityEngine;

namespace SurvivalPropertiesSystem.Scripts
{
    [Serializable]
    public class Impact
    {
        [Tooltip("When to trigger the impact")]
        public Condition condition;
        [Tooltip("The value of the impact")]
        public float conditionValue;

        [Tooltip("The property affected by the impact")]
        public string impactedProperty;
        [Tooltip("The ratio between the current property's change and the impacted property change")]
        public float ratio;

        /// <summary>
        /// Creates a new, disconnected copy of the current object
        /// </summary>
        public Impact Clone()
        {
            return this.MemberwiseClone() as Impact;
        }
    }
}
