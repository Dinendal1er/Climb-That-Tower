using UnityEngine;
using System.Collections;
using System;

public class ArmorRogue :Torso {

	// Use this for initialization
	public override void init () {
        this.st = Resources.LoadAll<Sprite>("Sprites/ItemIcons1");
        this.Id = 9;
        this.Name = "Armor Rogue";
        this.describ = "It's a sneaky Armor";
        this.talent = 7;
        this.s = this.st[183];
    }

    public override void Effect()
    {
        throw new NotImplementedException();
    }
}
