﻿using UnityEngine;
using System.Collections;
using System;

public class HealPot : Consumable
{
    public HealPot()
    {
        this.Name = "HealPot";
        this.talent = 3;
        this.init();
        foreach (Sprite a in this.st)
            if (a.name == "ItemIcons1_42")
                this.s = a;
    }

    public override void Effect()
    {
        throw new NotImplementedException();
    }
}
