using UnityEngine;
using System.Collections;
using System;

public class HandRogue : Hand {

	// Use this for initialization
	void Start () {
        this.Id = 11;
        this.Name = "Hand Rogue";
        this.describ = "it's sneaky GLOVE";
        this.talent = 7;
        this.init();
        this.s = this.st[204];

    }

    public override void Effect()
    {
        throw new NotImplementedException();
    }
}
