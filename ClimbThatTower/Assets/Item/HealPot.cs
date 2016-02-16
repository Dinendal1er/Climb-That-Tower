using UnityEngine;
using System.Collections;

public class HealPot : Consumable {

    void Start()
    {
        this.name = "HealPot";
        this.talent = 3;
        this.init();
        foreach (Sprite a in this.st)
            if (a.name == "ItemIcons1_42")
                this.s = a;
    }

    public HealPot()
    {
    }

    public override void Effect()
    {
    }
}
