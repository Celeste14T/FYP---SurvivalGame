using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public Item newItemType;
    public List<ItemInstance> items = new();
    public RectTransform Panel;
    bool showInventory = false;
    public Text InventoryText;
    // Start is called before the first frame update
    void Start()
    {
        items.Add(new ItemInstance(newItemType));
        Panel.localScale = new Vector3(0,0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            showInventory = !showInventory;
            ToggleInventory();
           
        }
    }

    void ToggleInventory (){
        if (showInventory)
        {
            Panel.localScale = new Vector3(1,1);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            InventoryText.enabled = true;
        }
        else
        {
            Panel.localScale = new Vector3(0,0);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            InventoryText.enabled = false;
        }
    }

    public void AddItem(ItemInstance itemToAdd)
    {
        items.Add(itemToAdd);
    }
  
    public void RemoveItem(ItemInstance itemToRemove)
    {
        items.Remove(itemToRemove);
    }
   
}