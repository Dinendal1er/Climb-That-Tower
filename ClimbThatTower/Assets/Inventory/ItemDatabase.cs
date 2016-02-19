using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;
using System.IO;

public class ItemDatabase : MonoBehaviour
{
    private List<AItem> _database = new List<AItem>();
    private JsonData _itemData;

    void Start()
    {
        _itemData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/Items.json"));
        ConstructionDatabase();

        Debug.Log(this._database[0].Name);
        Debug.Log(this._database[0].Id);
    }

    void ConstructionDatabase()
    {
        for(int i = 0; i < _itemData.Count; i++)
        {
            Debug.Log("test2");
            AItem item = new HealPot();
            item.init();
            this._database.Add(item);//TODO
        }
    }

    public AItem FetchItemByID(int id)
    {
        for (int i = 0; i < this._database.Count; i++)
        {
            if (this._database[i].Id == id)
                return this._database[i];
        }
        return null;
    }
}