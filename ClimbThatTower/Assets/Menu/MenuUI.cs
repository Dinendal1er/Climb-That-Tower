using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MenuUI : MonoBehaviour
{
    private bool isShowing = false;
    public List<AItem> items = new List<AItem>();
    private Rect infos = new Rect(4, 4, Screen.width - 8, 30);
    private string infoText = "";
    public List<MenuChoice> menuChoices;
    public GUISkin skin;

    // Use this for initialization
    void Start()
    {
        this.items.Add(new Sword());
        this.items.Add(new Potion());
    }

    void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            this.isShowing = !this.isShowing;
        }
    }

    void OnGUI()
    {
        GUI.skin = this.skin;
        if (this.isShowing)
        {
            uint y = (uint)this.infos.height + 12;
            this.infoText = "";
            for (int i = 0; i < this.menuChoices.Count; i++)
            {
                this.menuChoices[i].rect.x = 25;
                this.menuChoices[i].rect.y = y;
                GUI.Label(this.menuChoices[i].rect, this.menuChoices[i].text, skin.GetStyle("Inventory Windows"));
                if (this.menuChoices[i].rect.Contains(Event.current.mousePosition))
                    this.infoText = this.menuChoices[i].description;
                y += (uint)this.menuChoices[i].rect.height + 10;
            }
            GUI.Label(this.infos, this.infoText, skin.GetStyle("Inventory Windows"));
        }
    }
}
