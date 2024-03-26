using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class SelectionManager : MonoBehaviour
{
    [SerializeField] private string treeTag = "Tree";
    [SerializeField] private GameObject chopText;
    [SerializeField] private float chopDamage = 5f;

    // [SerializeField] private string rockTag = "Rock";
    // [SerializeField] private GameObject mineText;
    // [SerializeField] private float mineDamage = 5f;
 
 /*
    [SerializeField] private string rockTag = "Rock";
    [SerializeField] private GameObject mineText;
    [SerializeField] private float mineDamage = 5f;
*/

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
            // else if (selection.CompareTag(rockTag))
            // {
            //     if (hit.distance < 2f)
            //     {
            //         mineText.SetActive(true);
            //         if (Input.GetKeyDown(KeyCode.E))
            //         {
            //             selection.GetComponent<RockManager>().MineRock(mineDamage);
            //         }
            //     }

            // } 
            //else if (selection.ComapareTag(WHATEVER MATERIAL))
            else
            {
                chopText.SetActive(false);
               // mineText.SetActive(false);
            }
        }
    }
}