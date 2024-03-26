using System.Linq;
using UnityEngine;

namespace SurvivalPropertiesSystem.Scripts
{
    /// <summary>
    /// Script to update the value of a property in the properties manager
    /// </summary>
    public class AddPropertyValue : MonoBehaviour
    {
        [Tooltip("The name of the property to update")]
        public string propertyName;

        [Tooltip("The value to add to the selected property")]
        public float value;

        public void Apply(PropertiesManager propertiesManager)
        {
            var property = propertiesManager.properties.FirstOrDefault(p => p.name == propertyName);
            if (property != null)
            {
                property.current += value;
            }
        }
    }
}