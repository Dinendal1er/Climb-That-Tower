using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

public class MenuUI : MonoBehaviour
{
    private bool isShowing = false;
    private bool isChoosingPlayer = false;
    private Team team = new Team();
    private List<PlayerChoice> playerChoices = new List<PlayerChoice>();
    private Rect infos = new Rect(4, 4, Screen.width - 8, 30);
    private string infoText = "";
    public List<MenuChoice> menuChoices;
    public GUISkin skin;

    // Use this for initialization
    void Start()
    {
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

    private bool _isMouseMoving()
    {
        return (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("MouseY") != 0);
    }

    private uint _longestChoice()
    {
        uint res = 0;

        for (int i = 0; i < this.menuChoices.Count; i++)
            if (this.menuChoices[i].rect.width > res)
                res = (uint)this.menuChoices[i].rect.width;
        return (res);
    }

    void OnGUI()
    {
        GUI.skin = this.skin;
        if (this.isShowing)
        {
            uint y = (uint)this.infos.height + 15;
            if (!isChoosingPlayer)
                this.infoText = "Choisir une action a faire.";
            else
                this.infoText = "Choisir votre joueur.";
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
                    GUI.Label(this.menuChoices[i].rect, this.menuChoices[i].text, skin.GetStyle("Inventory Windows"));
                y += (uint)this.menuChoices[i].rect.height + 15;
            }
            uint width = ((uint)Screen.width - this._longestChoice()) / 2 - 22;
            uint height = ((uint)Screen.height - (uint)this.infos.height) / 2 - 22;
            for (int i = 0; i < this.team.players.Count; i++)
            {
                if (this.playerChoices.Count <= i)
                    this.playerChoices.Add(new PlayerChoice(this.infos.x + (width + 4) * (i % 2), this.infos.y + this.infos.height + 8 + (height + 4) * (i / 2), width, height, this.team.players[i]));
                this.playerChoices[i].Draw(this.isChoosingPlayer, skin);
                this.infoText = this.playerChoices[i].Hover(this.isChoosingPlayer, this.infoText);
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
