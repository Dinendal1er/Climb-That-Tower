using UnityEngine;
using System.Collections;
using System;

public class HandsBruiser : Hand {

	// Use this for initialization
	public override void init()  {
        this.st = Resources.LoadAll<Sprite>("Sprites/ItemIcons1");
        this.Id = 8;
        this.Name = "Hand Bruiser";
        this.describ = "it's GLOVE";
        this.talent = 7;
        this.s = this.st[205];
    }

    public override void Effect()
    {
        throw new NotImplementedException();
    }
}
