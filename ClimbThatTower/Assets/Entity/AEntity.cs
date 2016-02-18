using UnityEngine;
using System.Collections.Generic;

public abstract class AEntity
{
    private string _name = "Not named";
    private int _hp = 0;
    private int _maxHp = 0;
    private int _mp = 0;
    private int _maxMp = 0;
    private int _actionPoint = 0;
    private int _maxActionPoint = 0;
    private int _lvl = 1;
    private int _movement = 0;

    private int _exp = 0;
    private int _maxExp = 0;

    private int _strenght = 0;
    private int _defense = 0;
    private int _resistance = 0;
    private int _stamina = 0;
    private int _speed = 0;
    private int _intel = 0;
    private int _agility = 0;
    private int _precision = 0;
    private int _luck = 0;
    private int _magicResistance = 0;

    private EquipmentSet _equipment = null;

    private Sprite _sprite = null;
	public Sprite Sprite {
		get {
			return this._sprite;
		}
		set {
			_sprite = value;
		}
	}
    private string _job = "Unemployed";
    protected List<ASkill> _skills = new List<ASkill>();
    private List<AState> _state = new List<AState>();
    abstract public void levelUp();

	public List<ASkill> Skills {
		get {
			return this._skills;
		}
		set {
			_skills = value;
		}
	}
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

    public string Job
    {
        get
        {
            return _job;
        }

        set
        {
            _job = value;
        }
    }

    public EquipmentSet Equipment
    {
        get
        {
            return _equipment;
        }

        set
        {
            _equipment = value;
        }
    }
}
