using UnityEngine;
using System.Collections;
using System;

public class HealPot : Consumable
{
    public override void init()
    {
        this.st = Resources.LoadAll<Sprite>("Sprites/Item Icons/ItemIcons1");
        this.Id = 1;
        this.Name = "HealPot";
        this.describ = "heal 25 heath point";
        this.talent = 3;
        this.s = this.st[42];
        this.Stack = true;
    }

    public override void Effect()
    {
        throw new NotImplementedException();
    }
}
