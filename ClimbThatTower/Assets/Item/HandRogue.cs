using UnityEngine;
using System.Collections;
using System;

public class HandRogue : Hand {

	// Use this for initialization
	public override void init() {
        this.st = Resources.LoadAll<Sprite>("Sprites/ItemIcons1");
        this.Id = 11;
        this.Name = "Hand Rogue";
        this.describ = "it's sneaky GLOVE";
        this.talent = 7;
        this.s = this.st[204];

    }

    public override void Effect()
    {
        throw new NotImplementedException();
    }
}
