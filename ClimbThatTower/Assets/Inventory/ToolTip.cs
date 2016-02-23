using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ToolTip : MonoBehaviour {

    private AItem _item;
    private string _data;
    private GameObject _tooltip;

	// Use this for initialization
	void Start () {
        this._tooltip = GameObject.Find("ToolTip");
        this._tooltip.SetActive(false);
	}
	
    public void Activate(AItem item)
    {
        this._item = item;
        ConstructDataString();
        this._tooltip.SetActive(true);
    }

    public void Desactivate()
    {
        this._tooltip.SetActive(false);
    }

    public void ConstructDataString()
    {
        this._data = "<color=#000000>" + this._item.Name + "</color>" + "\n\n" + this._item.describ + "\nPrix : " + this._item.talent;
        this._tooltip.transform.GetChild(0).GetComponent<Text>().text = this._data;
    }

	// Update is called once per frame
	void Update () {
	    if (this._tooltip.activeSelf)
        {
            this._tooltip.transform.position = Input.mousePosition;
        }
	}
}
