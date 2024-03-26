using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stamina : MonoBehaviour
{
    
    public float curStamina = 0;
    public float maxStamina = 100f;
    public StaminaBar staminaBar;
    

    public float StaminaTimeToRegen = 10f;
    public float StaminaTimeToDrain = 40f;

    [HideInInspector]
    public bool isCrouching = false;
    //public playerMovement PM;
    CharacterController characterController;
    void Start()
    {
        curStamina = maxStamina;
        characterController = GetComponent<CharacterController>();

        
    }
    void Update()
    {
       // Debug.Log(characterController.velocity.x);
        if( Input.GetKey( KeyCode.LeftShift ) && curStamina != 0 && characterController.velocity.x != 0 ) //sprinting &( stamina & velocity is not 0)
        {
            ReduceStamina(StaminaTimeToDrain * Time.deltaTime);   
        } 

        if(Input.GetKeyDown(KeyCode.C)) //is crouching
        {
            isCrouching = !isCrouching;
            if (isCrouching)
            {
                StaminaTimeToDrain = 0f;
                ReduceStamina(StaminaTimeToDrain);
            }
            else
            {
                StaminaTimeToDrain = 40f;
                ReduceStamina(StaminaTimeToDrain * Time.deltaTime); 
            }
            
        }        

   
    IncreaseStamina();
    }

    public void ReduceStamina( float reduce )
    {
        curStamina -= reduce;
        staminaBar.SetStamina( curStamina );
    }

    public void IncreaseStamina ()
    {
        if(curStamina < maxStamina)
        {
            curStamina += StaminaTimeToRegen * Time.deltaTime;
            curStamina = Mathf.Clamp(curStamina, 0f, maxStamina);
            staminaBar.SetStamina(curStamina);
        }
    }


}
   
    


