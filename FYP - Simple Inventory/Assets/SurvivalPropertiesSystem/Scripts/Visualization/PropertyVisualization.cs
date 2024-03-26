using UnityEngine;
using UnityEngine.UI;

namespace SurvivalPropertiesSystem.Scripts.Visualization
{
    [System.Serializable]
    public class PropertyVisualization
    {
        [Tooltip("The name of the property to visualize")]
        public string propertyName;

        [Tooltip("The container that holds all the game objects used to display the property (used to hide unused properties)")]
        public Transform container;

        [Tooltip("A Text component to display the current value of the property")]
        public Text textObject;

        [Tooltip("Allows displaying properties values as either absolute numbers, or percentage")]
        public ValueDisaply displayType;

        [Tooltip("Optional icon for the property, which will be colored based on the provided gradient")]
        public Image imageObject;

        [Tooltip("Gradient used to colorize the icon of the property")]
        public Gradient gradient;
    }
}