using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MenuUI : MonoBehaviour
{
    private bool isShowing = false;
    public List<AItem> items = new List<AItem>();
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
            uint y = 0;

            for (int i = 0; i < this.menuChoices.Count; i++)
            {
                GUI.Label(new Rect(0, y, this.menuChoices[i].width, this.menuChoices[i].length), this.menuChoices[i].text, skin.GetStyle("Inventory Windows"));
                y += this.menuChoices[i].length + 2;
            }
        }
    }
}
