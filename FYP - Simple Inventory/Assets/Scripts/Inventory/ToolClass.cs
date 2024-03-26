using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

[CreateAssetMenu(fileName = "New Tool Class", menuName = "Inventory Item/Tool")]
public class ToolClass : ItemClass
{
    [Header("Item")]
    public ToolType toolType;

    public enum ToolType
    {
        weapon,
        pickaxe,
        axe
    }

    public override ItemClass GetItem() { return this; }
    public override ToolClass GetTool() { return this; }
    public override MiscClass GetMisc() { return null; }
    public override ConsumableClass GetConsumable() { return null; }
}
