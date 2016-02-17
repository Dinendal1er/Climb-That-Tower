using UnityEngine;
using System.Collections;
using System;

public class HealPot : Consumable
{
    public HealPot()
    {
        this.Id = 1;
        this.Name = "HealPot";
        this.describ = "heal 25 heath point";
        this.talent = 3;
        this.init();
        this.s = this.st[42];
    }

    public override void Effect()
    {
        throw new NotImplementedException();
    }
}
