using UnityEngine;
using System.Collections;
using System;

public class ArmorBruiser : Torso {

	
	public override void init () {
        this.st = Resources.LoadAll<Sprite>("Sprites/ItemIcons1");
        this.Id = 5;
        this.Name = "Armor Bruiser";
        this.describ = "It's heavy and awfull, but cheap armor";
        this.talent = 7;
        this.s = this.st[184];

    }

    public override void Effect()
    {
        throw new NotImplementedException();
    }
}
