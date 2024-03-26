using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Health : MonoBehaviour
{
    public float curHealth = 0;
    public float maxHealth = 100;

    public HealthBar healthBar;
    public Food food;
    public Water water;
  
   
    void Start()
    {
        curHealth = maxHealth;
       
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            restoreHealth(10);
        }

        if(food.curHunger <= 0){
            DamagePlayer(0.01f);
        }

        if(water.curWater <= 0){
            DamagePlayer(0.01f);
        }

    }
    public void DamagePlayer( float damage )
    {
        curHealth -= damage;
        healthBar.SetHealth( curHealth );
    }

    void OnCollisionStay(Collision collision){
        if(collision.gameObject.tag == "enemy"){
            DamagePlayer(1);
        }
    }

    public void restoreHealth(float restore)
    {
        curHealth += restore;
        healthBar.SetHealth(curHealth);
    }
   
}

