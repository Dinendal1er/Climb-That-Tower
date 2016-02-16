using UnityEngine;
using System.Collections;

public class Thief : AJob {

	// Use this for initialization
	void Start () {
        this._name = "Thief";
    }

    public override void levelUp(AEntity entity)
    {
        entity.MaxHp += 2 + (entity.Lvl * 2);
        entity.Intel += 1;
        entity.Luck += 3;
        entity.MagicResistance += 1;
        entity.MaxMp += entity.Lvl * 0;
        entity.Strenght += 1;
        entity.Stamina += 4;
        entity.Speed += 4;
        entity.Precision += 1;
        entity.Agility += 3;
        entity.Resistance += 1;

        entity.Lvl += 1;
    }

    // Update is called once per frame
    void Update () {
	
	}
}
