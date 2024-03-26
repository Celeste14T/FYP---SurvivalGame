using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{


    public GameObject player;
    private Transform target;
    Animator animator;

    public float speed = 1.0f;

   
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

    }


   

    // Update is called once per frame
    void FixedUpdate()
    {
        Ray ray = new Ray((transform.position + Vector3.up * 1.65f), transform.forward);
        if (Physics.Raycast( ray, out RaycastHit hit, 15)){
                if(hit.collider.gameObject.CompareTag("Player")){
                    //player = GameObject.Find("FP Camera");
                    target = player.transform; // set player as target
                    animator.SetTrigger("Walk");
                    FollowPlayer();
                    Debug.Log("Hit object: " + hit.collider.gameObject.name);
                    Debug.DrawRay((transform.position + Vector3.up * 1.65f) , transform.forward, Color.red);
                    
                }
                
        }
        else
        {
            if(hit.collider == null){
                Debug.Log("Hit object: " + hit.collider);
                Debug.DrawRay((transform.position + Vector3.up * 1.65f) , transform.forward, Color.red);
                animator.ResetTrigger("Walk");
                animator.SetTrigger("Idle");
                //wanderRandomly();
            }
        }
    
    }

    void OnCollisionStay(Collision collision){
        if(collision.gameObject.tag == "Player"){ // if zombie hits the player
            animator.SetTrigger("Attack"); //set trigger of attack to true which then changes animation state to Z_Attack

        }
        else{
            animator.ResetTrigger("Attack"); //set trigger of attack to false which then changes animation state to Z_Walk
        
        }
    }
    

    private void FollowPlayer(){  
        var step =  speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        Vector3 lookPos = target.transform.position;
        lookPos.y = transform.position.y; 
        transform.LookAt(lookPos);
    }




}
