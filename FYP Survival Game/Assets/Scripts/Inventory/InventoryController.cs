using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [HideInInspector]
    public ItemGrid selectedItemGrid;

    InventoryItem selectedItem;
    RectTransform rectTransform;
    InventoryItem overlapItem;

    [SerializeField] List<ItemData> items;
    [SerializeField] GameObject itemPrefab;
    [SerializeField] Transform canvasTransform;

    InventoryHighlight inventoryHighlight;

    private void Awake()
    {
        inventoryHighlight = GetComponent<InventoryHighlight>();
    }

    // Update is called once per frame
    void Update()
    {
        ItemIconDrag();

        // for testing, create item
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // DELETE ONCE FINISH
            CreateRandomItem();
        }

        // TODO: Change to pickup
        if (Input.GetKeyDown(KeyCode.P))
        {
            AddToInventory();
            
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            RotateItem();
        }

        if (selectedItemGrid == null)
        {
            return;
        }

        //HandleHighlight();

        // pick up object on click
        if (Input.GetMouseButtonDown(0))
        {
            LeftMouseButtonPress();
            Debug.Log("LMB Pressed");
        }

    }

    private void RotateItem()
    {
        if (selectedItem == null)
        {
            return; 
        }

        selectedItem.Rotate();
    }

    // when you pick up, it should auto find a place in inventory
    private void AddToInventory()
    {
        CreateRandomItem();

        InventoryItem itemToInsert = selectedItem;
        selectedItem = null;
        InsertItem(itemToInsert);
        //Debug.Log("auto sort Pressed");
    }

    private void InsertItem(InventoryItem itemToInsert)
    {
        Vector2Int? posOnGrid = selectedItemGrid.FindSpaceForObject(itemToInsert);

        if (posOnGrid == null)
        {
            return;
        }

        selectedItemGrid.PlaceItem(itemToInsert, posOnGrid.Value.x, posOnGrid.Value.y);
    }

    InventoryItem itemToHighlight;

    // highlight selected objects
    private void HandleHighlight()
    {
        Vector2Int positiononGrid = GetTileGridPosition();

        if (selectedItem == null)
        {
            itemToHighlight = selectedItemGrid.GetItem(positiononGrid.x, positiononGrid.y);

            if (itemToHighlight != null) 
            {
                inventoryHighlight.SetSize(itemToHighlight);
                inventoryHighlight.SetPosition(selectedItemGrid, itemToHighlight);
            }
        }
        else
        {

        }
    }

    // for testing
    private void CreateRandomItem()
    {
        InventoryItem inventoryItem = Instantiate(itemPrefab).GetComponent<InventoryItem>();
        selectedItem = inventoryItem;

        rectTransform = inventoryItem.GetComponent<RectTransform>();
        rectTransform.SetParent(canvasTransform);

        int selectedItemID = UnityEngine.Random.Range(0, items.Count);
        inventoryItem.Set(items[selectedItemID]);
    }

    private void LeftMouseButtonPress()
    {
        Vector2Int tileGridPosition = GetTileGridPosition();

        if (selectedItem == null)
        {
            PickUpItem(tileGridPosition);
        }
        else
        {
            PlaceItem(tileGridPosition);
        }
    }

    private Vector2Int GetTileGridPosition()
    {
        Vector2 position = Input.mousePosition;

        if (selectedItem != null)
        {
            position.x -= (selectedItem.WIDTH - 1) * ItemGrid.tileSizeWidth / 2;
            position.y += (selectedItem.HEIGHT - 1) * ItemGrid.tileSizeHeight / 2;
        }

        return selectedItemGrid.GetTileGridPosition(position); ;
    }

    private void PlaceItem(Vector2Int tileGridPosition)
    {
        bool complete = selectedItemGrid.PlaceItem(selectedItem, tileGridPosition.x, tileGridPosition.y, ref overlapItem);

        if (complete)
        {
            selectedItem = null;

            if (overlapItem != null)
            {
                selectedItem = overlapItem;
                overlapItem = null;
                rectTransform = selectedItem.GetComponent<RectTransform>();
            }
        }
    }

    private void PickUpItem(Vector2Int tileGridPosition)
    {
        selectedItem = selectedItemGrid.PickUpItem(tileGridPosition.x, tileGridPosition.y);

        if (selectedItem != null)
        {
            rectTransform = selectedItem.GetComponent<RectTransform>();
        }
    }

    private void ItemIconDrag()
    {
        if (selectedItem != null)
        {
            // position of mouse to selected item
            rectTransform.position = Input.mousePosition;
        }
    }
}
