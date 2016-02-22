using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class Slot : MonoBehaviour, IDropHandler {

    public int _id;
    public Inventory _inv;

    void Start ()
    {
        this._inv = GameObject.Find("Inventory Panel").GetComponent<Inventory>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        ItemData dropppedItem = eventData.pointerDrag.GetComponent<ItemData>();
//if (eventData.po)
        //Debug.LogError("TEST");
        Debug.LogError(this._inv.name);

        if (this._inv == null || !this._inv.name.Equals("Inventory Panel"))
        {
            //Debug.LogError("Not a Case");
            return;
        }
        else
        {
            if (isEmptyCase())
                dropppedItem._slot = this._id;
            else
            {
                Transform item = this.transform.GetChild(0);
                if (item == null)
                    return;
                if (item.GetComponent<ItemData>() == null)
                    return;
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
    }

    public bool isEmptyCase()
    {
        foreach (ItemData x in this._inv._iList._items)
        {
            if (x._slot == this._id)
                return false;
        }
        return true;
    }
    // Update is called once per frame
    void Update () {
	
	}
}
