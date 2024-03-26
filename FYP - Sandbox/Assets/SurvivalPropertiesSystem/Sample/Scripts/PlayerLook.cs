using SurvivalPropertiesSystem.Scripts;
using UnityEngine;
using UnityEngine.UI;

namespace SurvivalPropertiesSystem.Sample.Scripts
{
    public class PlayerLook : MonoBehaviour
    {
        private const string c_mouseXInputName = "Mouse X";
        private const string c_mouseYInputName = "Mouse Y";
        private const float c_mouseSensitivity = 50f;

        public PropertiesManager propertiesManager;
        public Transform playerBody;
        public Text selectedObject;

        private float xAxisClamp;

        private void Awake()
        {
            LockCursor();
            xAxisClamp = 0.0f;
        }


        private void LockCursor()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void Update()
        {
            CameraRotation();
        }

        private void CameraRotation()
        {
            float mouseX = Input.GetAxis(c_mouseXInputName) * c_mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis(c_mouseYInputName) * c_mouseSensitivity * Time.deltaTime;

            xAxisClamp += mouseY;

            if(xAxisClamp > 90.0f)
            {
                xAxisClamp = 90.0f;
                mouseY = 0.0f;
                ClampXAxisRotationToValue(270.0f);
            }
            else if (xAxisClamp < -90.0f)
            {
                xAxisClamp = -90.0f;
                mouseY = 0.0f;
                ClampXAxisRotationToValue(90.0f);
            }

            transform.Rotate(Vector3.left * mouseY);
            playerBody.Rotate(Vector3.up * mouseX);


            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            // Check if we have any object in front of us
            if (Physics.Raycast(ray, out hit, 20.0f))
            {
                // If this is an "unknown" object, hide the object display
                if (hit.transform.tag == "Untagged")
                {
                    if (selectedObject != null)
                    {
                        selectedObject.text = "";
                    }
                }
                else
                {
                    // Display the "name" of the object
                    if (selectedObject != null)
                    {
                        selectedObject.text = hit.transform.tag;
                    }

                    // If the user pressed a button
                    if (Input.GetMouseButton(0))
                    {
                        // Interact with the object - add value to a property 
                        var addPropertyValue = hit.transform.GetComponent<AddPropertyValue>();
                        if (addPropertyValue != null)
                        {
                            addPropertyValue.Apply(propertiesManager);
                        }

                        // Interact with the object - add new properties
                        var addProperty = hit.transform.GetComponent<AddProperty>();
                        if (addProperty != null)
                        {
                            addProperty.Apply(propertiesManager);
                        }
                    }
                }
            }
            else
            {
                selectedObject.text = "";
            }
        }

        private void ClampXAxisRotationToValue(float value)
        {
            Vector3 eulerRotation = transform.eulerAngles;
            eulerRotation.x = value;
            transform.eulerAngles = eulerRotation;
        }
    }
}