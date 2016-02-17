using UnityEngine;
using System.Collections;
using System;

public class HandsBruiser : Hand {

	// Use this for initialization
	void Start () {
        this.Id = 8;
        this.Name = "Hand Bruiser";
        this.talent = 7;
        this.init();
        this.s = this.st[205];
    }

    public override void Effect()
    {
        throw new NotImplementedException();
    }
}
