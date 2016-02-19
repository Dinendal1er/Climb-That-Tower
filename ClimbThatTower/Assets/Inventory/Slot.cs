using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class Slot : MonoBehaviour, IDropHandler {

    public int _id;
    private Inventory _inv;
    void Start ()
    {
        this._inv = GameObject.Find("Inventory").GetComponent<Inventory>();
	}

    public void OnDrop(PointerEventData eventData)
    {
        ItemData dropppedItem = eventData.pointerDrag.GetComponent<ItemData>();
        
        if (this._inv._items[this._id].First.Id == -1)
        {
            this._inv._items[this._id].First = new HealPot(); //TODO
            this._inv._items[this._id].First = dropppedItem._item;
            dropppedItem._slot = this._id;
        }
        else
        {
            Transform item = this.transform.GetChild(0);
            item.GetComponent<ItemData>()._slot = dropppedItem._slot;
            item.transform.SetParent(this._inv._slots[dropppedItem._slot].First.transform);
            item.transform.position = this._inv._slots[dropppedItem._slot].First.transform.position;

            dropppedItem._slot = this._id;
            dropppedItem.transform.SetParent(this.transform);
            dropppedItem.transform.position = this.transform.position;

            this._inv._items[dropppedItem._slot].First = item.GetComponent<ItemData>()._item;
            this._inv._items[this._id].First = dropppedItem._item;
        }
    }

    // Update is called once per frame
    void Update () {
	
	}
}
