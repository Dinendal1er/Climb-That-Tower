﻿using UnityEngine;
using System.Collections;

public class Thief : APlayer
{
	public Thief(string name)
    {
        this.Job = "Thief";
        this.Agility = 1;
        this.Ap = 1;
        this.Defense = 1;
        this.Exp = 0;
        this.Hp = 30;
        this.Intel = 1;
        this.Job = null;
        this.Luck = 1;
        this.Lvl = 1;
        this.MagicResistance = 1;
        this.MaxActionPoint = 2;
        this.MaxExp = 100;
        this.MaxHp = 30;
        this.MaxMp = 30;
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
        this.Intel += 1;
        this.Luck += 3;
        this.MagicResistance += 1;
        this.MaxMp += this.Lvl * 0;
        this.Strenght += 1;
        this.Stamina += 4;
        this.Speed += 4;
        this.Precision += 1;
        this.Agility += 3;
        this.Resistance += 1;

        this.Lvl += 1;
    }
}
