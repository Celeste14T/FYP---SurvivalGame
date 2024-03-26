using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        // make sure player is tagged with "Player" tag
        if (collider.gameObject.tag == "Player")
        {
            //print("Picked up");
            Destroy(gameObject);
        }
    }
}
