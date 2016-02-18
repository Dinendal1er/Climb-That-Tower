using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;
using System.IO;

public class ItemDatabase : MonoBehaviour
{
    private List<AItem> _database = new List<AItem>();
    private JsonData itemData;

    void Start()
    {
        itemData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/Items.json"));
        ConstructionDatabase();
    }

    void ConstructionDatabase()
    {
        foreach(JsonData x in this.itemData)
        {
            this._database.Add(new HealPot());//TODO
        }
    }

    public AItem FetchItemByID(int id)
    {
        foreach(AItem x in this._database)
        {
            if (x.Id == id)
                return x;
        }
        return null;
    }
}