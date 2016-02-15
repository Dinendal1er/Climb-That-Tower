using UnityEngine;
using System.Collections;

public abstract class Consumable : AItem
{
    public Consumable()
    {
        this.type = eItemType.CONSUMABLE;
    }
}
