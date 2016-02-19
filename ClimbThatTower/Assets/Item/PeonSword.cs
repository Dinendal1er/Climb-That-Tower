using UnityEngine;
using System.Collections;
using System;

public class PeonSword : RightHand
{
    public override void init()
    {
        this.st = Resources.LoadAll<Sprite>("Sprites/Item Icons/ItemIcons1");
        this.Id = 3;
        this.Name = "PeonSword";
        this.talent = 3;
        this.s = this.st[70];
        this.Stack = false;
    }

    public override void Effect()
    {
        throw new NotImplementedException();
    }
}
