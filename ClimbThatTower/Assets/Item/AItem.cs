using UnityEngine;
using System.Collections;

public enum eItemType { WEAPON, HEAD, TORSO, PANTS, FOOT, HAND, CONSUMABLE, ONEHANDED, DOUBLEHANDED, RIGHTHAND, LEFTHAND}


public abstract class AItem : MonoBehaviour
{
    private Sprite[] _st;
    private Sprite   _s;
    private string _name;
    private string _describ;
    private Texture2D _sprite;
    private int _talent;
    private eItemType _type;
    private int _id;

    public void init()
    {
       _st = Resources.LoadAll<Sprite>("Sprites/ItemIcons1");
    }

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

    public Texture2D sprite
    {
        get { return _sprite; }
        set { _sprite = value; }
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

    public abstract void Effect();
}
