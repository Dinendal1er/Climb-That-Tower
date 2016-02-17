using UnityEngine;
using System.Collections;
using System;

public class Colussator : DoubleHanded
{
    public Colussator()
    {
        this.Id = 2;
        this.Name = "Colussator";
        this.talent = 99;
        this.init();
        this.s = this.st[359];
    }

    public override void Effect()
    {
        throw new NotImplementedException();
    }
}
