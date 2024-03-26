using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    public Slider staminaBar;
    public Stamina playerStamina;
    private void Start()
    {
        playerStamina = GameObject.FindGameObjectWithTag("Player").GetComponent<Stamina>();
        staminaBar = GetComponent<Slider>();
        staminaBar.maxValue = playerStamina.maxStamina;
        staminaBar.value = playerStamina.maxStamina;
    }
    public void SetStamina(float stamina)
    {
        staminaBar.value = stamina;
    }
}

