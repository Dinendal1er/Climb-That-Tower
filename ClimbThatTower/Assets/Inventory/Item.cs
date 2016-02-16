using UnityEngine;
using System.Collections;

[System.Serializable]
public class Item
{
    public string _itemName;
    public int _itemID;
    public string _itemDesc;
    public Texture2D _itemIcon;
    public ItemType _itemType;

    public enum ItemType
    {
        Weapon,
        Consumable,
        Quest
    }

}