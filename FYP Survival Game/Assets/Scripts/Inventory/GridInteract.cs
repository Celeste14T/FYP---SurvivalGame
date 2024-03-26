using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(ItemGrid))]
public class GridInteract : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    InventoryController inventoryController;
    ItemGrid itemGrid;

    private void Awake()
    {
        inventoryController = FindAnyObjectByType(typeof(InventoryController)) as InventoryController;
        itemGrid = GetComponent<ItemGrid>();
    }

    // when mouse goes in the grid
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Pointer Enter");

        inventoryController.selectedItemGrid = itemGrid;

    }

    // when mouse goes out of the grid
    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Pointer Exit");

        inventoryController.selectedItemGrid = null;
    }

    
}
