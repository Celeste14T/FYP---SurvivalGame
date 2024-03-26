using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class SelectionManager : MonoBehaviour
{
    [SerializeField] private string treeTag = "Tree";
    [SerializeField] private GameObject chopText; //change to pickup
    [SerializeField] private float chopDamage = 5f; //maybe can remove
 
    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
 
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Transform selection = hit.transform;
            if (selection.CompareTag(treeTag))
            {
                if (hit.distance < 2f)
                {
                    chopText.SetActive(true);//chopText to pickup?
                    if (Input.GetKeyDown(KeyCode.E)) //Press E to pick
                    {
                        selection.GetComponent<TreeManager>().ChopTree(chopDamage);// Change to pickup, now is damage in treeSelectscript

                    }
                }
            }
            else
            {
                chopText.SetActive(false);
            }
        }
    }
}