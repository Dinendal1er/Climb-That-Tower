using UnityEngine;
using System.Collections;
using System;

public  class HeadBruiser : Head {

	// Use this for initialization
	public override void init() {
        this.st = Resources.LoadAll<Sprite>("Sprites/ItemIcons1");
        this.Id = 4;
        this.Name = "Helmet Bruiser";
        this.talent = 10;
        this.s = this.st[193];

    }
    public override void Effect()
    {
        throw new NotImplementedException();
    }

}
