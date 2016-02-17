using UnityEngine;
using System.Collections;

public class PlayerChoice
{
    private Rect _background;
    private AEntity _player;

    public PlayerChoice(float x, float y, float width, float height, AEntity player)
    {
        this._background = new Rect(x, y, width, height);
        this._player = player;
    }

    public bool Draw(bool isChoosingPlayers, GUIStyle style)
    {
        if (!isChoosingPlayers)
            GUI.Label(this._background, this._player.Job, style);
        else
            return (GUI.Button(this._background, this._player.Job, style));
        return (false);
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
