using UnityEngine;
using System.Collections;
using System;

public class SneakyDagger :Weapon {

	// Use this for initialization
	void Start () {
        this.Id = 14;
        this.Name = "SneakyDagger";
        this.describ = "Little but Sneaky";
        this.talent = 7;
        this.init();
        this.s = this.st[91];

    }

    public override void Effect()
    {
        throw new NotImplementedException();
    }

}
