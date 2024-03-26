using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private bool isGameOver = false;
    private bool reachEndPoint = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(isGameOver && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0); //reloads the tutorial
        }

        if(reachEndPoint)
        {
           SceneManager.LoadScene(1); // reload stage
        }
    }

    public void GameOver(){
        isGameOver = true;
    }

    public void reachEnd(){
        reachEndPoint = true;
        Debug.Log(reachEndPoint);
    }

}
