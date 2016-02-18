using UnityEngine;
using System.Collections;
using System;

public class FootBruiser : Foot {

	// Use this for initialization
	public override void init() {
        this.st = Resources.LoadAll<Sprite>("Sprites/ItemIcons1");
        this.Id = 7;
        this.Name = "Foot Bruiser";
        this.describ = "Just classic boots";
        this.talent = 7;
        this.s = this.st[198];
    }

    public override void Effect()
    {
        throw new NotImplementedException();
    }
}
