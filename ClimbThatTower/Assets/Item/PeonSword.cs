using UnityEngine;
using System.Collections;
using System;

public class PeonSword : RightHand
{
    void Start()
    {
        this.name = "PeonSword";
        this.talent = 3;
        this.init();
        foreach (Sprite a in this.st)
            if (a.name == "ItemIcons1_70")
                this.s = a;
    }

    public PeonSword()
    {

    }

    public override void Effect()
    {
    }
}
