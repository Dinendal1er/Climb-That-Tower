using UnityEngine;
using System.Collections;

public abstract class APlayer : AEntity {
    private InventoryItems _invItems;

    public InventoryItems InvItems
    {
        get
        {
            return _invItems;
        }

        set
        {
            _invItems = value;
        }
    }
}
