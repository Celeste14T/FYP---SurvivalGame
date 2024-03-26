using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PauseGame : MonoBehaviour

{
    public static bool gameIsPaused;
    public Text PausedText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameIsPaused = !gameIsPaused;
            GamePaused();
        }
    }
    void GamePaused ()
    {
        if(gameIsPaused)
        {
            Time.timeScale = 0f;
            PausedText.enabled = true;
            Cursor.lockState = CursorLockMode.Confined; //sets lockstate to confined 
            Cursor.visible = true;     //shows cursor
        }
        else 
        {
            Time.timeScale = 1;
            PausedText.enabled = false; 
            Cursor.lockState = CursorLockMode.Locked; //locks cursor
            Cursor.visible = false;   //hides cursor
        }
    }
}
