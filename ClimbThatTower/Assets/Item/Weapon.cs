using UnityEngine;
using System.Collections;

public abstract class Weapon : AItem
{
    public Weapon()
    {
        this.type = eItemType.WEAPON;
    }
}
