using UnityEngine;
using System.Collections;
using System;

public class HeadRogue : Head {

	// Use this for initialization
	void Start () {
        this.Id = 10;
        this.Name = "Head Rogue";
        this.describ = "Sneaky balaclava";
        this.talent = 7;
        this.init();
        this.s = this.st[189];

    }

    public override void Effect()
    {
        throw new NotImplementedException();
    }
}
