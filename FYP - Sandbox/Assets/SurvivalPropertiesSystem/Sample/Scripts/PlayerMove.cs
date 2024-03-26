using UnityEngine;

namespace SurvivalPropertiesSystem.Sample.Scripts
{
    public class PlayerMove : MonoBehaviour
    {
        private const string c_horizontalInputName = "Horizontal";
        private const string c_verticalInputName = "Vertical";
        private const float c_movementSpeed = 5f;

        private CharacterController m_charController;


        public void Awake()
        {
            m_charController = GetComponent<CharacterController>();
        }

        public void Update()
        {
            float horizontalInput = Input.GetAxis(c_horizontalInputName) * c_movementSpeed;
            float verticalInput = Input.GetAxis(c_verticalInputName) * c_movementSpeed;

            Vector3 forwardMovement = transform.forward * verticalInput;
            Vector3 rightMovement = transform.right * horizontalInput;

            m_charController.SimpleMove(forwardMovement + rightMovement);
        }
    }
}
