using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    GameObject _inventoryPanel;
    GameObject _slotPanel;
    ItemDatabase _database;

    public GameObject _inventorySlot;
    public GameObject _inventoryItem;

    int _slotAmount;
    public List<AItem> _items = new List<AItem>();
    public List<GameObject> _slots = new List<GameObject>();

    // Use this for initialization
    void Start()
    {
        this._database = GetComponent<ItemDatabase>();

        this._slotAmount = 24;
        this._inventoryPanel = GameObject.Find("Inventory");
        this._slotPanel = this._inventoryPanel.transform.FindChild("Slot Panel").gameObject;
        
        for(int i = 0; i < this._slotAmount; i++)
        {
            //TODO
            AItem item = new HealPot();
            item.init();
            this._items.Add(item);

            this._slots.Add(Instantiate(this._inventorySlot));
            this._slots[i].transform.SetParent(this._slotPanel.transform);
        }

        AddItem(109090);
        //this._items.Add(new Sword());
        //this._items.Add(new Potion());
    }

    public void AddItem(int id)
    {

        //AItem itemToAdd = this._database.FetchItemByID(id);
        AItem item = new HealPot();
        item.init();
        for (int i = 0; i < this._items.Count; i++)
        {
            //if (this._items[i].Id == -1)
            //{
                this._items[i] = item;
                GameObject itemObj = Instantiate(this._inventoryItem);
                itemObj.transform.SetParent(this._slots[i].transform);
                itemObj.transform.position = Vector2.zero;
                itemObj.GetComponent<Image>().sprite = item.s;
                itemObj.name = item.Name;

                break;
            //}
        }
    }

    void OnGUI()
    {
        for (int i = 0; i < this._items.Count; i++)
        {
            GUI.Label(new Rect(10, i * 20, 200, 50), this._items[i].Name);
        }
    }
}
