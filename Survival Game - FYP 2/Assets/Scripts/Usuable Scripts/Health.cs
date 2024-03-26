using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float curHealth = 0;
    public float maxHealth = 100;


    public HealthBar healthBar;
    void Start()
    {
        curHealth = maxHealth;
    }
    void Update()
    {
        
    }
    public void DamagePlayer( float damage )
    {
        curHealth -= damage;
        healthBar.SetHealth( curHealth );
    }

    void OnCollisionStay(Collision collision){
        if(collision.gameObject.name == "Zombie1"){
            DamagePlayer(1);
        }
    }
}

