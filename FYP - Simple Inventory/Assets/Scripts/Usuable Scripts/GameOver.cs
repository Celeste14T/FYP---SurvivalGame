using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{

    [SerializeField]
    private GameManager gameManager = null;
    public Text GameOverText = null;
    public Health Health;
  
    // Start is called before the first frame update
    void Start()
    {
        Health = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>(); //calls the health script
        GameOverText.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
         if(Health.curHealth <= 0){
            GameOverText.enabled = true;
            gameManager.GameOver(); //calls game over function to set gameover as true
            PlayerDeath(); //calls function
           
        }
    }

     public void PlayerDeath(){
        Camera.main.transform.parent=null; //unbinds camera from player so that camera doesnt gets destroy
        Destroy(this.gameObject); //destroys player object
    }
}
