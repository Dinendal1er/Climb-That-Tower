using UnityEngine;
using System.Collections;
using System;

public class SneakyDagger : Weapon {

	// Use this for initialization
	public override void init() {
        this.st = Resources.LoadAll<Sprite>("Sprites/ItemIcons1");
        this.Id = 14;
        this.Name = "SneakyDagger";
        this.describ = "Little but Sneaky";
        this.talent = 7;
        this.s = this.st[91];

    }

    public override void Effect()
    {
        throw new NotImplementedException();
    }

}
