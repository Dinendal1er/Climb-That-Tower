using UnityEngine;
using System.Collections;

public enum eItemType { WEAPON, HEAD, TORSO, PANTS, FOOT, HAND, CONSUMABLE, ONEHANDED, DOUBLEHANDED, RIGHTHAND, LEFTHAND}

public class AItem {
    private string _name;
    private string _describ;
    private Texture2D _sprite;
    private int _talent;

    public string name
    {
        get
        {
            return _name;
        }
        set
        {
            _name = value;
        }
    }

    public string describ
    {
        get
        {
            return _describ;
        }
        set
        {
            _describ = value;
        }
    }

    public Texture2D sprite
    {
        get
        {
            return _sprite;
        }
        set
        {
            _sprite = value;
        }
    }

    public int talent
    {
        get
        {
            return _talent;
        }
        set
        {
            _talent = value;
        }
    }
}
