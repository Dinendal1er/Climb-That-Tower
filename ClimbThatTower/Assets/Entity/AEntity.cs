using UnityEngine;
using System.Collections.Generic;

public abstract class AEntity
{
    private string _name;
    private int _hp;
    private int _maxHp;
    private int _mp;
    private int _maxMp;
    private int _actionPoint;
    private int _maxActionPoint;
    private int _lvl;
    private int _movement;

    private int _exp;
    private int _maxExp;

    private int _strenght;
    private int _defense;
    private int _resistance;
    private int _stamina;
    private int _speed;
    private int _intel;
    private int _agility;
    private int _precision;
    private int _luck;
    private int _magicResistance;
    //TMP
    private string _equipment;

    private AJob _job;
    private List<ASkill> _perso_skill;
    private List<AState> _state;

    public string Name
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

    public int Hp
    {
        get
        {
            return _hp;
        }

        set
        {
            _hp = value;
        }
    }

    public int Strenght
    {
        get
        {
            return _strenght;
        }

        set
        {
            _strenght = value;
        }
    }

    public int Defense
    {
        get
        {
            return _defense;
        }

        set
        {
            _defense = value;
        }
    }

    public int Stamina
    {
        get
        {
            return _stamina;
        }

        set
        {
            _stamina = value;
        }
    }

    public int Speed
    {
        get
        {
            return _speed;
        }

        set
        {
            _speed = value;
        }
    }

    public int Intel
    {
        get
        {
            return _intel;
        }

        set
        {
            _intel = value;
        }
    }

    public int Agility
    {
        get
        {
            return _agility;
        }

        set
        {
            _agility = value;
        }
    }

    public int Precision
    {
        get
        {
            return _precision;
        }

        set
        {
            _precision = value;
        }
    }

    public int Luck
    {
        get
        {
            return _luck;
        }

        set
        {
            _luck = value;
        }
    }

    public int Ap
    {
        get
        {
            return _actionPoint;
        }

        set
        {
            _actionPoint = value;
        }
    }

    public int Lvl
    {
        get
        {
            return _lvl;
        }

        set
        {
            _lvl = value;
        }
    }

    public int MaxHp
    {
        get
        {
            return _maxHp;
        }

        set
        {
            _maxHp = value;
        }
    }

    public int MaxMp
    {
        get
        {
            return _maxMp;
        }

        set
        {
            _maxMp = value;
        }
    }

    public int Movement
    {
        get
        {
            return _movement;
        }

        set
        {
            _movement = value;
        }
    }

    public int MagicResistance
    {
        get
        {
            return _magicResistance;
        }

        set
        {
            _magicResistance = value;
        }
    }

    public int MaxActionPoint
    {
        get
        {
            return _maxActionPoint;
        }

        set
        {
            _maxActionPoint = value;
        }
    }

    public int Exp
    {
        get
        {
            return _exp;
        }

        set
        {
            _exp = value;
        }
    }

    public int MaxExp
    {
        get
        {
            return _maxExp;
        }

        set
        {
            _maxExp = value;
        }
    }

    public int Resistance
    {
        get
        {
            return _resistance;
        }

        set
        {
            _resistance = value;
        }
    }
}
