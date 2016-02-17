using UnityEngine;
using System.Collections;

public class EquipmentSet {
    public Foot _foot;
    public Head _head;
    public Hand _hand;
    public Weapon _weapon;
    public Pants _pants;
    public Torso _torso;

    public EquipmentSet(Foot foot, Head head, Hand hand, Weapon weapon, Pants pants, Torso torso)
    {
        this._foot = foot;
        this._head = head;
        this._hand = hand;
        this._weapon = weapon;
        this._pants = pants;
        this._torso = torso;
    }
}
