using UnityEngine;
using System.Collections;
using System;

public class PantsBruiser : Pants {

	// Use this for initialization
	void Start () {
        this.Id = 6;
        this.Name = "Pants Bruiser";
        this.describ = "sorry we didnt have pants sprite, so you have pepper";
        this.talent = 7;
        this.init();
        this.s = this.st[17];

    }

    public override void Effect()
    {
        throw new NotImplementedException();
    }
}
