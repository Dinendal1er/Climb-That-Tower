using UnityEngine;
using System.Collections;

public class Warrior : APlayer
{
	public Warrior(string name)
    {
        this.Job = "Warrior";
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
