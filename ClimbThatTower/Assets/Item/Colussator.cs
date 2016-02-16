using UnityEngine;
using System.Collections;

public class Colussator : DoubleHanded {


    void Start()
    {
        this.name = "Colussator";
        this.talent = 99;
        this.init();
        foreach (Sprite a in this.st)
            if (a.name == "ItemIcons1_359")
                this.s = a;
    }

    public Colussator()
    {
    }

    public override void Effect()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}
