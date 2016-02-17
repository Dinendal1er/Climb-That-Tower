using UnityEngine;
using System.Collections;
using System;

public class FootRogue : Foot {

	// Use this for initialization
	void Start () { 
        this.Id = 12;
        this.Name = "Foot Rogue";
        this.describ = "Sneaky boots";
        this.talent = 7;
        this.init();
        this.s = this.st[202];
	
	}

public override void Effect()
{
    throw new NotImplementedException();
}

}
