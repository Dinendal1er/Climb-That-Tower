using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

public class MenuUI : MonoBehaviour
{
    private bool isShowing = false;
    private bool isChoosingPlayer = false;
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
            if (this.isShowing == false)
                this.isChoosingPlayer = false;
        }
        if (Input.GetButtonDown("Cancel"))
        {
            if (this.isChoosingPlayer)
                this.isChoosingPlayer = false;
            else
                this.isShowing = false;
        }
    }

    void OnGUI()
    {
        GUI.skin = this.skin;
        /*if (Input.GetAxis("Mouse X") < 0)
        {
            //Code for action on mouse moving left
            print("Mouse moved left");
        }
        else if (Input.GetAxis("Mouse X") > 0)
        {
            //Code for action on mouse moving right
            print("Mouse moved right");
        }
        else
        {
            print("Not moving");
        }*/
        if (this.isShowing)
        {
            uint y = (uint)this.infos.height + 15;
            this.infoText = "";
            for (int i = 0; i < this.menuChoices.Count; i++)
            {
                this.menuChoices[i].rect.x = Screen.width - this.menuChoices[i].rect.width - 25;
                this.menuChoices[i].rect.y = y;
                if (!this.isChoosingPlayer)
                {
                    if (GUI.Button(this.menuChoices[i].rect, this.menuChoices[i].text, skin.GetStyle("Inventory Windows")))
                    {
                        System.Type thisType = this.GetType();
                        MethodInfo theMethod = thisType.GetMethod(this.menuChoices[i].invoke);
                        if (theMethod != null)
                            theMethod.Invoke(this, null);
                    }
                    if (this.menuChoices[i].rect.Contains(Event.current.mousePosition))
                         this.infoText = this.menuChoices[i].description;
                }
                else
                {
                    GUI.Label(this.menuChoices[i].rect, this.menuChoices[i].text, skin.GetStyle("Inventory Windows"));
                }
                y += (uint)this.menuChoices[i].rect.height + 15;
            }
            GUI.Label(this.infos, this.infoText, skin.GetStyle("Inventory Windows"));
        }
    }
    public void inventoryButton()
    {
        print("Inventory");
    }
    public void equipmentButton()
    {
        this.isChoosingPlayer = true;
    }
    public void skillButton()
    {
        this.isChoosingPlayer = true;
    }
    public void stateButton()
    {
        this.isChoosingPlayer = true;
    }
    public void returnButton()
    {
        this.isShowing = !this.isShowing;
    }
}
