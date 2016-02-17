using UnityEngine;
using System.Collections;

public class Thief : AEntity
{
	public Thief()
    {
        this.Job = "Thief";
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
