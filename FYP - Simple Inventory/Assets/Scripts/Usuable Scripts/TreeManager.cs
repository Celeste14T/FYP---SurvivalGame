using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class TreeManager : MonoBehaviour
{
    public float treeHealth = 1f;
    //[SerializeField] Image foreground = null;
 
    public void ChopTree(float damage)
    {
        treeHealth -= damage;
 
        //foreground.fillAmount = treeHealth / 1f;
 
        if (treeHealth <= 0f)
        {
            Destroy(gameObject);

           // DropItem(Wood);

        }
    }
}