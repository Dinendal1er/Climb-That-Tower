using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;
using System.IO;

public class ItemDatabase : MonoBehaviour {
    private List<Item> _database = new List<Item>();
    private JsonData itemData;

    void Start()
    {
        Item item = new Item(0, "Ball", 5);
        _database.Add(item);
        itemData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/Items.json"));
    }
    void ConstructionDatabase()
    {
        foreach(JsonData x in this.itemData)
        {
            this._database.Add(new Item((int)x["id"], x["title"].ToString(), (int)x["value"]));
        }
    }
}

public class Item
{
    private int _id;
    private string _name;
    private int _value;

    public Item(int id, string name, int value)
    {
        this._id = id;
        this._name = name;
        this._value = value;
    }

    public int Id
    {
        get
        {
            return _id;
        }

        set
        {
            _id = value;
        }
    }

    public string Name
    {
        get
        {
            return _name;
        }

        set
        {
            _name = value;
        }
    }
}