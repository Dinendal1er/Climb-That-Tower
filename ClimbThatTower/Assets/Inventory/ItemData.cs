using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class ItemData : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerDownHandler
{
    public AItem _item;
    public int _slot;
    public int _nbr;

    private Vector2 _offset;
    private Inventory _inv;

    void Start()
    {
        this._inv = GameObject.Find("Inventory").GetComponent<Inventory>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (this._item != null)
        {
            this.transform.SetParent(this.transform.parent.parent);
            this.transform.position = eventData.position - this._offset;
            GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
       if (this._item != null)
        {
            this.transform.position = eventData.position - this._offset;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        this.transform.SetParent(this._inv._slots[_slot].First.transform);
        this.transform.position = this._inv._slots[_slot].First.transform.position;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (this._item != null)
        {
            this._offset = eventData.position - new Vector2(this.transform.position.x, this.transform.position.y);
        }
    }
}
