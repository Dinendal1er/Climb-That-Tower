using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public abstract class ABoss : AEntity {
    public List<AItem> _drop;
    public int _pDrop;
}
