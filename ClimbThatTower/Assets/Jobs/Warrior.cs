using UnityEngine;
using System.Collections;

public class Warrior : AEntity
{
	public Warrior()
    {
        this.Job = "Warrior";
	}

    public override void levelUp()
    {
        this.MaxHp += 5 + (this.Lvl * 2);
        this.Intel += 0;
        this.Luck += 1;
        this.MagicResistance += 1;
        this.MaxMp += this.Lvl * 0;
        this.Strenght += 3;
        this.Stamina += 3;
        this.Speed += 1;
        this.Precision += 0;
        this.Agility += 1;
        this.Resistance += 3;

        this.Lvl += 1;
    }
}
