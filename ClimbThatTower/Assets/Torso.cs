using UnityEngine;
using System.Collections;

public abstract class Torso : AItem
{
    public Torso()
    {
        this.type = eItemType.TORSO;
    }
}
