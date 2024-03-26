using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextScene : MonoBehaviour
{

    [SerializeField]
    private GameManager gameManager;
    private bool isCollide;
    
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        if(isCollide == true){
           gameManager.reachEnd(); 
        }
    }

    private void OnTriggerEnter(Collider collision){
        if (collision.CompareTag("Player"))
        {
            isCollide = true;
        }
    }
}
