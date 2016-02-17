using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Team : MonoBehaviour
{
    public List<AEntity> players = new List<AEntity>();
    public Inventory inventory;

    public Team()
    {
        this.players.Add(new Warrior("Garrosh"));
        this.players.Add(new Mage("Jaina"));
        this.players.Add(new Thief("Valeera"));
    }
}
