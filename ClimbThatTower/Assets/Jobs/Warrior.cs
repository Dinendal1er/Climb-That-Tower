using UnityEngine;
using System.Collections;

public class Warrior : AJob {

	// Use this for initialization
	void Start () {
        this._name = "Warrior";
	}

    public override void levelUp(AEntity entity)
    {
        entity.MaxHp += 5 + (entity.Lvl * 2);
        entity.Intel += 0;
        entity.Luck += 1;
        entity.MagicResistance += 1;
        entity.MaxMp += entity.Lvl * 0;
        entity.Strenght += 3;
        entity.Stamina += 3;
        entity.Speed += 1;
        entity.Precision += 0;
        entity.Agility += 1;
        entity.Resistance += 3;

        entity.Lvl += 1;
    }
    // Update is called once per frame
    void Update () {
	
	}
}
