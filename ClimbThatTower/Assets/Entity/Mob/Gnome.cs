using UnityEngine;
using System.Collections;

public class Gnome : AMob {
    
    public Gnome(int etage)
    {
        this.Agility = 1 * etage;
        this.Ap = 0;
        this.Defense = 1 * etage;
        this._drop.Add(new HealPot());
        this._pDrop = 50;
        this.Exp = 0;
        this.Hp = 10 * etage;
        this.Intel = 0;
        this.Job = null;
        this.Luck = 1;
        this.Lvl = 1 * etage;
        this.MagicResistance = 1 * etage;
        this.MaxActionPoint = 2;
        this.MaxExp = ((100 + etage) * Lvl);
        this.MaxHp = 10 * etage;
        this.MaxMp = 0;
        this.Movement = 5;
        this.Name = "Gnome";
        this.Precision = 25 + etage;
        this.Resistance = 0;
        this.Speed = 1 * etage;
        this.Stamina = 0;
        this.Strenght = 1 * etage;

        this.Equipment = new EquipmentSet(new FootBruiser(), new HeadBruiser(), new HandsBruiser(), new Colussator(), new PantsBruiser(), new ArmorBruiser());
    }
    override public void levelUp()
    {
        //TODO
    }
}
