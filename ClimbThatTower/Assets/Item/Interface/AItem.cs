using UnityEngine;
using System.Collections;

public enum eItemType { WEAPON, HEAD, TORSO, PANTS, FOOT, HAND, CONSUMABLE, ONEHANDED, DOUBLEHANDED, RIGHTHAND, LEFTHAND}


public abstract class AItem
{
    private Sprite[] _st;
    private Sprite   _s;
    private string _name = "Unknown";
    private string _describ = "Maybe a good item";
    private int _talent = 0;
    private eItemType _type;
    private int _id;
    private bool _stack = false;


    public abstract void init();

    public Sprite s
    {
        get { return _s; }
        set { _s = value; }
    }

    public Sprite[] st
    {
        get { return _st; }
        set { _st = value; }
    }

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public string describ
    {
        get { return _describ; }
        set { _describ = value; }
    }

    public int talent
    {
        get { return _talent; }
        set { _talent = value; }
    }

    public eItemType type
    {
        get { return _type; }
        set { _type = value; }
    }

    public int Id
    {
        get
        {
            return _id;
        }

        set
        {
            _id = value;
        }
    }

    public bool Stack
    {
        get
        {
            return _stack;
        }

        set
        {
            _stack = value;
        }
    }

    public abstract void Effect();
}
