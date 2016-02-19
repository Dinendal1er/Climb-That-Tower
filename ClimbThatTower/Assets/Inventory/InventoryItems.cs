using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class InventoryItems {
    public List<ItemData>_items;

    public AItem findItembySlot(int slot)
    {
        foreach (ItemData x in _items)
        {
            if (x._slot == slot)
            {
                return (x._item);
            }
        }
        return null;
    }

    public InventoryItems()
    {
        this._items = new List<ItemData>();
    }
}

public class Pair<T, U>
{
    public Pair()
    {
    }

    public Pair(T first, U second)
    {
        this.First = first;
        this.Second = second;
    }

    public T First { get; set; }
    public U Second { get; set; }
};
