using UnityEngine;
using System.Collections;

public class Player : APlayer{
    public Player(string name, AJob job)
    {
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
        this.Job = null;
    }
    override public void levelUp()
    {
        //TODO
    }
}
