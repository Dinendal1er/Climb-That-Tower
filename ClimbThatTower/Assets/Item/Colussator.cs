using UnityEngine;
using System.Collections;
using System;

public class Colussator : DoubleHanded
{
    public Colussator()
    {
        this.Name = "Colussator";
        this.talent = 99;
        this.init();
        foreach (Sprite a in this.st)
            if (a.name == "ItemIcons1_359")
                this.s = a;
    }

    public override void Effect()
    {
        throw new NotImplementedException();
    }
}
