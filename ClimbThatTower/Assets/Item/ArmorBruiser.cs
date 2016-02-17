using UnityEngine;
using System.Collections;
using System;

public class ArmorBruiser : Torso {

	
	void Start () {
        this.Id = 5;
        this.Name = "Armor Bruiser";
        this.describ = "It's heavy and awfull, but cheap armor";
        this.talent = 7;
        this.init();
        this.s = this.st[184];

    }

    public override void Effect()
    {
        throw new NotImplementedException();
    }
}
