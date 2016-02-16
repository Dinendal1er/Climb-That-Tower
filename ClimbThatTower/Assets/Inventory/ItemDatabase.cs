using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;
using System.IO;

public class ItemDatabase : MonoBehaviour {
    private List<AItem> _database = new List<AItem>();
    private JsonData itemData;

    void Start()
    {
        AItem item = new AItem(0, "Ball", 5);
        _database.Add(item);
        itemData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/Items.json"));
    }
    void ConstructionDatabase()
    {
        foreach(JsonData x in this.itemData)
        {
            this._database.Add(new HealPot());// new AItem((int)x["id"], x["title"].ToString(), (int)x["value"]));
        }
    }

    public AItem FetchItemByID(int id)
    {
        foreach(Item x in this._database)
        {
            if (x.Id == id)
                return x;
        }
        return null;
    }
}

}