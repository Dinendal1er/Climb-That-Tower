using UnityEngine;
using System.Collections;

public class PlayerChoice
{
    private Rect _background;
    private Rect _name;
    private AEntity _player;

    public PlayerChoice(float x, float y, float width, float height, AEntity player)
    {
        this._background = new Rect(x, y, width, height);
        this._name = new Rect(x + 8, y + 8, width - 12, height - 12);
        this._player = player;
    }

    public bool Draw(bool isChoosingPlayers, GUISkin skin)
    {
        bool hasClicked = false;
        if (!isChoosingPlayers)
            GUI.Label(this._background, "", skin.GetStyle("Inventory Windows"));
        else
            hasClicked = GUI.Button(this._background, "", skin.GetStyle("Inventory Windows"));
        GUI.Label(this._name, this._player.Job, skin.GetStyle("Player Job Windows"));
        return (hasClicked);
    }

    public string Hover(bool isChoosingPlayer, string infoText)
    {
        if (!isChoosingPlayer)
            return (infoText);
        if (this._background.Contains(Event.current.mousePosition))
            return ("Choisir le joueur " + this._player.Name + ".");
        return (infoText);
    }
}
