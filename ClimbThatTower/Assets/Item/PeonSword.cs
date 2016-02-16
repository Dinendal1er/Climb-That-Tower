using UnityEngine;
using System.Collections;
using System;

public class PeonSword : RightHand
{
    public PeonSword()
    {
        this.Name = "PeonSword";
        this.talent = 3;
        this.init();
        foreach (Sprite a in this.st)
            if (a.name == "ItemIcons1_70")
                this.s = a;
    }

    public override void Effect()
    {
        throw new NotImplementedException();
    }
}
