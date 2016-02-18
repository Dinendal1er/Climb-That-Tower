using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
/*    GameObject _inventoryPanel;
    GameObject _slotPanel;
    public GameObject _inventorySlot;
    public GameObject _inventoryItem;

    int _slotAmount;
    public List<AItem> _items = new List<AItem>();
    public List<GameObject> _slots = new List<GameObject>();
    // Use this for initialization
    void Start()
    {
        this._database = GetComponent<ItemDatabase>();

        this._slotAmount = 16;
        this._inventoryPanel = GameObject.Find("Inventory Panel");
        this._slotPanel = this._inventoryPanel.transform.FindChild("Slot Panel").gameObject;
        for(int i = 0; i < this._slotAmount;i++)
        {
            this._items.Add(new ItemDatabase());
            this._slots.Add(Instantiate(inventorySlot));
            this._slots[i].transform.SetParent(slotPanel.transform);
        }

        this._items.Add(new Sword());
        this._items.Add(new Potion());
    }

    public void AddItem(int id)
    {
        ItemDatabase itemToAdd = this._database.FetchItemByID(id);
        for (int i = 0; i < this._items.Count; i++)
        {
            if (this_items[i].ID == -1)
            {
                this._items[i] = itemToAdd;
                GameObject itemObj = Instantiate(invotoryItem);
                itemObj.transform.SetParent(this._slots[i].transform);
                itemObj.transform.position = Vector2.zero;
                itemObj.GetComponent<Image>().sprite = itemToAdd.Sprite;
                itemObj.name = itemToAdd.Title;

                break;
            }
        }
    }

    void OnGUI()
    {
        for (int i = 0; i < this._items.Count; i++)
        {
            GUI.Label(new Rect(10, i * 20, 200, 50), this._items[i].Name);
        }
    }*/
}
