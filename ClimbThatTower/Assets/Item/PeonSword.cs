﻿using UnityEngine;
using System.Collections;
using System;

public class PeonSword : RightHand
{
    public PeonSword()
    {
        this.Id = 3;
        this.Name = "PeonSword";
        this.talent = 3;
        this.init();
        this.s = this.st[70];
    }

    public override void Effect()
    {
        throw new NotImplementedException();
    }
}
