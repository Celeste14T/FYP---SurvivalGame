using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SurvivalPropertiesSystem.Scripts.Visualization
{
    [System.Serializable]
    public class PropertiesVisualizer : MonoBehaviour
    {
        public PropertiesManager propertiesManager;
        public List<PropertyVisualization> visualizations;

        public void Update()
        {
            HashSet<string> availableProperties = new HashSet<string>();
            // For each of the available propeties
            foreach (var property in propertiesManager.properties)
            {
                availableProperties.Add(property.name);

                // Find the relevant visualization for the property
                var visualization = visualizations.FirstOrDefault(v => v.propertyName == property.name);
                if (visualization == null)
                {
                    continue;
                }

                // Calculate the property's percentage
                var percentage = property.current / property.max;
                // Display the current value of the property...
                if (visualization.textObject != null)
                {
                    // ... as an absolute number
                    if (visualization.displayType == ValueDisaply.Absolute)
                    {
                        visualization.textObject.text = property.current.ToString("0");
                    }
                    // ... or as a percentage
                    else
                    {
                        visualization.textObject.text = (percentage * 100).ToString("0") + "%";
                    }
                }

                // If we also have an icon for the property, and a gradient
                if (visualization.imageObject != null &&
                    visualization.gradient != null)
                {
                    // Evaluate the color based on the gradient...
                    var color = visualization.gradient.Evaluate(percentage);
                    // ... and apply it to the icon
                    visualization.imageObject.color = color;
                }
            }

            // For each visualization
            foreach (var visualization in visualizations)
            {
                // Update the display status of the visualization based on the existence of the property - hide unused properties
                if (visualization.container != null)
                {
                    visualization.container.gameObject.SetActive(availableProperties.Contains(visualization.propertyName));
                }
            }
        }
    }
}