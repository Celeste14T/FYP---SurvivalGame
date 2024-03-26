using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SurvivalPropertiesSystem.Scripts
{
    [System.Serializable]
    public class PropertiesManager : MonoBehaviour
    {
        [Tooltip("List of properties")]
        public List<Property> properties;

        public void Start()
        {
            foreach (var property in properties)
            {
                property.current = property.initial;
            }
        }

        public void Update()
        {
            // For each property
            foreach (var property in properties)
            {
                // If the property doesn't have a decay, no need to update it
                if (property.decay == 0)
                {
                    continue;
                }

                // Update the current value of the property
                var effect = Time.deltaTime / property.decay;
                property.current += effect;

                // Apply all impacts on other properties
                foreach (var impact in property.impacts)
                {
                    // Check if impact's condition is met
                    bool shouldApply = false;
                    switch (impact.condition)
                    {
                        case Condition.LessThan:
                        {
                            shouldApply = property.current < impact.conditionValue;
                            break;
                        }
                        case Condition.LessOrEqualsTo:
                        {
                            shouldApply = property.current <= impact.conditionValue;
                            break;
                        }
                        case Condition.EqualsTo:
                        {
                            shouldApply = property.current == impact.conditionValue;
                            break;
                        }
                        case Condition.EqualOrGreaterThan:
                        {
                            shouldApply = property.current >= impact.conditionValue;
                            break;
                        }
                        case Condition.GreaterThan:
                        {
                            shouldApply = (property.current > impact.conditionValue);
                            break;
                        }
                    }

                    if (shouldApply)
                    {
                        // Find the relevant property
                        var impactedProperty = properties.FirstOrDefault(p => p.name == impact.impactedProperty);
                        if (impactedProperty != null)
                        {
                            // Apply impact (based on ratio) on the relevant property
                            impactedProperty.current += effect * impact.ratio;
                        }
                    }
                }
            }

            // Ensure all properties are with-in valid values range
            foreach (var property in properties)
            {
                property.current = Mathf.Clamp(property.current, property.min, property.max);
            }

            // Remove all properties that reached minimum value, and are marked with the DestroyOnMinimum flag
            properties.RemoveAll(p => p.destroyOnMinimum && p.current == p.min);
        }

    }
}
