using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    public List<AItem> items = new List<AItem>();

    // Use this for initialization
    void Start()
    {
        this.items.Add(new Sword());
        this.items.Add(new Potion());
    }

    void OnGUI()
    {
        for (int i = 0; i < this.items.Count; i++)
        {
            GUI.Label(new Rect(10, i * 20, 200, 50), this.items[i].Name);
        }
    }
}
