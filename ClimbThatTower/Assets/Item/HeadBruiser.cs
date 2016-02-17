using UnityEngine;
using System.Collections;
using System;

public  class HeadBruiser : Head {

	// Use this for initialization
	void Start () {
        this.Id = 4;
        this.Name = "Helmet Bruiser";
        this.talent = 10;
        this.init();
        this.s = this.st[193];

    }
    public override void Effect()
    {
        throw new NotImplementedException();
    }

}
