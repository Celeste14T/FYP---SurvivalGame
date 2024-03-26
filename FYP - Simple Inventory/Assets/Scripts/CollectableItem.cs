using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableItem : MonoBehaviour
{
    public Item item;

    public Item CollectItem()
    {
        // returns the item type and destroys the game object
        Destroy(gameObject);
        return item;
    }

}
