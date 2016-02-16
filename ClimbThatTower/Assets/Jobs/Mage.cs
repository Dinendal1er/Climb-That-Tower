using UnityEngine;
using System.Collections;
using System;

public class Mage : AJob {

	// Use this for initialization
	void Start () {
        this._name = "Mage";
        this._skill.Add(new Fireball());
    }

    public override void levelUp(AEntity entity)
    {
        entity.MaxHp += 2 + (entity.Lvl * 2);
        entity.Intel += 3;
        entity.Luck += 1;
        entity.MagicResistance += 3;
        entity.MaxMp += entity.Lvl * 2;
        entity.Strenght += 0;
        entity.Stamina += 0;
        entity.Speed += 0;
        entity.Precision += 0;
        entity.Agility += 1;
        entity.Resistance += 1;

        entity.Lvl += 1;
}

    // Update is called once per frame
    void Update () {
	
	}
}
