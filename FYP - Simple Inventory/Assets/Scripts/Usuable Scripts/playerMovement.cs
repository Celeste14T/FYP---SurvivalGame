using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerMovement : MonoBehaviour
{

    public float walkingSpeed = 7.5f;
    public float runningSpeed = 15.5f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;

    public bool isCrouching = false;
    public bool isInventory = false;
    public bool isShopInventory = false;
    public float crouchHeight = 0.5f;
    public float crouchSpeed = 3.5f;
    public float crouchTransitionSpeed = 5f; //adjust this to determine speed at which transition between crouching and standing camera, higher value results in faster transistion
    private float originalHeight;
    public float crouchCameraOffset = -0.5f;
    private Vector3 cameraStandPosition;
    private Vector3 cameraCrouchPosition;


    //public Image ShopInventory;
    //public Image Inventory;

    public GameObject Inventory;
    public GameObject ShopInventory;

    public Camera playerCamera;
    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;
    public bool canMove = true;


    [HideInInspector]
    //public Merchant merchant;
    public PauseGame pausegame; //calls the pause script
    public Stamina stamina; //calls the stamina script

    void Start()
    {

        characterController = GetComponent<CharacterController>();
        stamina = GameObject.FindGameObjectWithTag("Player").GetComponent<Stamina>(); //gets the component in player. allows me to get curStamina
        //Inventory.enabled = false;
        //ShopInventory.enabled = false;
        Inventory.SetActive(true);
        ShopInventory.SetActive(false);
        // Lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        originalHeight = characterController.height;

    }

    void Update()
    {
        // We are grounded, so recalculate move direction based on axes
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        // Press Left Shift to run
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        //Jumping
        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpSpeed;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        //Crouching
        if (Input.GetKeyDown(KeyCode.C) && canMove)
        {
            isCrouching = !isCrouching;

            if (isCrouching)
            {
                characterController.height = crouchHeight;
                walkingSpeed = crouchSpeed;
                runningSpeed = crouchSpeed;
            }
            else
            {
                characterController.height = originalHeight;
                walkingSpeed = 7.5f;
                runningSpeed = 15.5f;
            }
        }

        if (stamina.curStamina <= 0 && !isCrouching) //checks if curStamina is less than or equal 0 && character is not crouching
        {
            runningSpeed = 0; //player can no longer run
            //Debug.Log(runningSpeed);
        }
        else if (stamina.curStamina > 0 && !isCrouching)
        { //checks if curStamina more than 0 && character is not crouching
            runningSpeed = 15.5f;  // else restore player speed
            // Debug.Log(runningSpeed);
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            isInventory = !isInventory;
            if (isInventory)
            {
                // unlock curser
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;

                Inventory.SetActive(true);
            }
            else
            { 
                // unlock curser
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = true;

            Inventory.SetActive(false);
            }

        }

        //if (Input.GetKeyDown(KeyCode.E) && Merchant.merchantInRange)
        //{ //if press E and merchant in range
        //    isShopInventory = !isShopInventory; //toggle bool
        //    if (isShopInventory)
        //    {
        //        ShopInventory.enabled = true; //enable shop menu
        //    }

        //    else
        //    { //when press e and merchat isnt in range
        //        ShopInventory.enabled = false; //disable shop menu
        //    }

        //}

        //else if (!Merchant.merchantInRange)
        //{  //if merchant isnt in range
        //    ShopInventory.enabled = false; //disable shop menu

        //}


        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);

        // Player and Camera rotation
        if (canMove && !PauseGame.gameIsPaused) //enables camera to move when not paused
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }




    }
}