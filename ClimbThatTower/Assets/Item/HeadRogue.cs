using UnityEngine;
using System.Collections;
using System;

public class HeadRogue : Head {

	// Use this for initialization
	public override void init() {
        this.st = Resources.LoadAll<Sprite>("Sprites/ItemIcons1");
        this.Id = 10;
        this.Name = "Head Rogue";
        this.describ = "Sneaky balaclava";
        this.talent = 7;
        this.s = this.st[189];

    }

    public override void Effect()
    {
        throw new NotImplementedException();
    }
}
