using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SlotClass : MonoBehaviour
{
    [SerializeField]
    private ItemClass item;

    [SerializeField]
    private int quantity;

    public SlotClass()
    {
        item = null;
        quantity = 0;
    }

    public SlotClass(ItemClass _item, int _quantity) 
    { 
        item = _item;
        quantity = _quantity;
    }

    public ItemClass GetItem()
    {
        return item;
    }

    public int GetQuantity()
    {
        return quantity;
    }

    //public void SetItem(ItemClass _item)
    //{
    //    item = _item;
    //}

    public void AddQuantity(int _quantity)
    {
        quantity += _quantity;
    }
}
