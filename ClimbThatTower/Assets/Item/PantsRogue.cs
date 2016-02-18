using UnityEngine;
using System.Collections;
using System;

public class PantsRogue : Pants {

	// Use this for initialization
	public override void init() {
        this.st = Resources.LoadAll<Sprite>("Sprites/ItemIcons1");
        this.Id = 9;
        this.Name = "Pants Rogue";
        this.describ = "it's sneaky pants";
        this.talent = 7;
        this.s = this.st[20];

    }

    public override void Effect()
    {
        throw new NotImplementedException();
    }
}
