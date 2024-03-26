using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{


    public GameObject player;
    public Transform target;
    Animator animator;
    UnityEngine.AI.NavMeshAgent agent ;
    Rigidbody enemyRB;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        enemyRB = GetComponent<Rigidbody>();
        //agent.autoBraking = false;
        agent.stoppingDistance = 1.5f;
    }


   

    // Update is called once per frame
    void FixedUpdate()
    {
        Ray ray = new Ray((transform.position + Vector3.up * 1.65f), transform.forward); //creates my ray
        if (Physics.Raycast( ray, out RaycastHit hit, 15)){  //ray output of 15 units
                if(hit.collider.gameObject.CompareTag("Player")){ //raycast hits player tag
                    target = player.transform; // set player as target
                    agent.speed = 5.0f;
                    animator.ResetTrigger("Walk");
                    animator.SetTrigger("Run");
                    FollowPlayer();
                    Debug.Log("Hit object: " + hit.collider.gameObject.name);
                    Debug.DrawRay((transform.position + Vector3.up * 1.65f) , transform.forward, Color.red);
                    
                }

                else if (hit.collider.gameObject.CompareTag("enemy")){ //prevents zombies from being stuck on each other
                    agent.SetDestination(RandomNavmeshLocation(10f)); //random location based on a radius in a sphere
                }
                
        }

   
        else
        {
            if(hit.collider == null){ //if raycast hits nothing
                Debug.Log("Hit object: " + hit.collider);
                Debug.DrawRay((transform.position + Vector3.up * 1.65f) , transform.forward, Color.red);
                agent.speed = 3.5f;
                animator.ResetTrigger("Run");
                animator.SetTrigger("Walk");
                agent.SetDestination(RandomNavmeshLocation(20f));  //random location in 10 radius
            }
        }
    
    }

    void OnCollisionStay(Collision collision){
        if(collision.gameObject.tag == "Player"){ // if zombie hits the player
            animator.SetTrigger("Attack"); //set trigger of attack to true which then changes animation state to Z_Attack
            agent.speed = 0.0f;
        }
        else{
            animator.ResetTrigger("Attack"); //set trigger of attack to false which then changes animation state to Z_Walk
        
        }
    }
    

    private void FollowPlayer(){  //better navigation to follow player. Allows slight turning 
        Vector3 lookPos = target.transform.position; // player position
        lookPos.y = transform.position.y; // prevent enemy from falling over
        transform.LookAt(lookPos); //better turning
        agent.destination = target.position; //set player postion as destination for navmeshagent to follow 
    }

    public Vector3 RandomNavmeshLocation(float radius) { // to wander randomly
        Vector3 randomDirection = Random.insideUnitSphere * radius; //random location based on a radius in a sphere
        randomDirection += transform.position;
        UnityEngine.AI.NavMeshHit hit;
        Vector3 finalPosition = Vector3.zero;
        if (UnityEngine.AI.NavMesh.SamplePosition(randomDirection, out hit, radius, UnityEngine.AI.NavMesh.AllAreas)) {
            finalPosition = hit.position;            
        }
        return finalPosition;
    }


}
