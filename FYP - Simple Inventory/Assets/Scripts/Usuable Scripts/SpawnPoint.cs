using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField]
    public GameObject spawnPoint;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        spawnPoint = GameObject.Find("Start Point");
        player.transform.position = spawnPoint.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

      
    }

}
