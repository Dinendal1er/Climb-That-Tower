using UnityEngine;
using System.Collections;
using System;

public class Mage : AEntity
{

	// Use this for initialization
	void Start () {
        this.Job = "Mage";
        this._skills.Add(new Fireball());
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
