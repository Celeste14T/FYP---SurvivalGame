using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickItems : MonoBehaviour
{
    public string itemName = "Some Item"; //Each item must have an unique name
    public Texture itemPreview;

    void Start()
    {
        //Change item tag to Respawn to detect when we look at it
        gameObject.tag = "Respawn";
    }

    public void PickItem()
    {
        Destroy(gameObject);
    }
}
