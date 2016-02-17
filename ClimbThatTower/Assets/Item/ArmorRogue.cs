using UnityEngine;
using System.Collections;
using System;

public class ArmorRogue :Torso {

	// Use this for initialization
	void Start () {
        this.Id = 9;
        this.Name = "Armor Rogue";
        this.describ = "It's a sneaky Armor";
        this.talent = 7;
        this.init();
        this.s = this.st[183];
    }

    public override void Effect()
    {
        throw new NotImplementedException();
    }
}
