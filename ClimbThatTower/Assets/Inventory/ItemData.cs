using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class ItemData : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
    public AItem _item;
    public int _slot;
    public int _nbr;

    private Vector2 _offset;
    private ToolTip _tooltip;
    private Inventory _inv;

    void Start()
    {
        this._inv = GameObject.Find("Inventory Panel").GetComponent<Inventory>();
        this._tooltip = this._inv.GetComponent<ToolTip>();
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
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (this._item != null)
        {
            this._offset = eventData.position - new Vector2(this.transform.position.x, this.transform.position.y);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        this._tooltip.Activate(this._item);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        this._tooltip.Desactivate();
    }
}
