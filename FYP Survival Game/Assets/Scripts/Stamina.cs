using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stamina : MonoBehaviour
{
    public float curStamina = 0;
    public float maxStamina = 100;
    public StaminaBar staminaBar;

    private float StaminaRegenTimer = 0.0f;

    private const float StaminaDecreasePerFrame = 1.0f;
    private const float StaminaIncreasePerFrame = 5.0f;
    private const float StaminaTimeToRegen = 3.0f;
   

    void Start()
    {
        curStamina = maxStamina;
    }
    void Update()
    {
        if( Input.GetKeyDown( KeyCode.LeftShift ) )
        {
            ReduceStamina(10);
        }

        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
             if (StaminaRegenTimer >= StaminaTimeToRegen)
             {
                IncreaseStamina(10);
             }
 
        }

    }
    public void ReduceStamina( float reduce )
    {
        curStamina -= reduce;
        staminaBar.SetStamina( curStamina );
    }

    public void IncreaseStamina (float increase)
    {
        if(curStamina < maxStamina)
        {
            curStamina += increase;
            staminaBar.SetStamina(curStamina);
        }
    }
    
}

