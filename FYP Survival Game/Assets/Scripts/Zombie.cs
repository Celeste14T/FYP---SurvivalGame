using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public GameObject player;
    public float speed = 1.0f;
    private Transform target;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("FP Camera");
        target = player.transform; // set player as target
    }


    // Update is called once per frame
    void Update()
    {
        
      
       
    }

    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag == "Player"){
            
        }
    }

    private void FollowPlayer(){
        var step =  speed * Time.deltaTime; 
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        transform.LookAt(target);
    }

    void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 2)){
                //if(hit.collider.CompareTag("Player")){
                    FollowPlayer();
                //}
        }
    }
}
