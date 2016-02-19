using UnityEngine;
using System.Collections;
using System;

public class Mage : APlayer
{

	// Use this for initialization
	public Mage(String name)
    {
        this.Job = "Mage";
        //this._skills.Add(new Fireball());
		this.Skills.Add(new Fireball());
        this.Agility = 1;
        this.Ap = 1;
        this.Defense = 1;
        this.Exp = 0;
        this.Hp = 30;
        this.Intel = 1;
        this.Luck = 1;
        this.Lvl = 1;
        this.MagicResistance = 1;
        this.MaxActionPoint = 2;
        this.MaxExp = 100;
        this.MaxHp = 30;
        this.MaxMp = 30;
        this.Mp = 30;
        this.Movement = 5;
        this.Name = name;
        this.Precision = 45;
        this.Resistance = 0;
        this.Speed = 1;
        this.Stamina = 1;
        this.Strenght = 1;

        //TODO
        this.Equipment = new EquipmentSet(new FootBruiser(), new HeadBruiser(), new HandsBruiser(), new Colussator(), new PantsBruiser(), new ArmorBruiser());

    }

    public override void levelUp()
    {
        this.MaxHp += 2 + (this.Lvl * 2);
        this.Intel += 3;
        this.Luck += 1;
        this.MagicResistance += 3;
        this.MaxMp += this.Lvl * 2;
        this.Strenght += 0;
        this.Stamina += 0;
        this.Speed += 0;
        this.Precision += 0;
        this.Agility += 1;
        this.Resistance += 1;

        this.Lvl += 1;
}

    // Update is called once per frame
    void Update () {
	
	}
}
