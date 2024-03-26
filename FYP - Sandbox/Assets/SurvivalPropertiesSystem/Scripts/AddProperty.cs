using UnityEngine;

namespace SurvivalPropertiesSystem.Scripts
{
    /// <summary>
    /// Script to add properties to the properties manager
    /// </summary>
    public class AddProperty : MonoBehaviour
    {
        [Tooltip("The property to add to the properties manager")]
        public Property property;

        public void Apply(PropertiesManager propertiesManager)
        {
            propertiesManager.properties.Add(property.Clone());
        }
    }
}