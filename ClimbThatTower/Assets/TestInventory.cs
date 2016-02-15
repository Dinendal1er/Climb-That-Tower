using UnityEngine;
using System.Collections;
using System;

public class Sword : Weapon
{
    public Sword()
    {
        this.Name = "Sword";
        this.describ = "A magnificient sword. Yeah, just that. What did you expect ? A excellent pun ? More information ? Well, guess what : neither one. Now play and stop looking at useless descriptions.";
        this.talent = 2;
    }

    public override void Effect()
    {
        throw new NotImplementedException();
    }
}

public class Potion : Consumable
{
    public Potion()
    {
        this.Name = "Potion";
        this.describ = "Restaure 100HP... JK ! Do nothing";
        this.talent = -1;
    }

    public override void Effect()
    {
        throw new NotImplementedException();
    }
}