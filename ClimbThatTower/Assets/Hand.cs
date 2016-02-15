using UnityEngine;
using System.Collections;

public abstract class Hand : AItem
{
    public Hand()
    {
        this.type = eItemType.HAND;
    }
}