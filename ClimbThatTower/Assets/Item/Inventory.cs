using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    GameObject _slotPanel;

    public GameObject _inventorySlot;
    public GameObject _inventoryItem;

    int _slotAmount;
    public List<Pair<AItem, int> > _items = new List<Pair<AItem, int> >();
    public List<Pair<GameObject, bool> > _slots = new List<Pair<GameObject, bool> >();
    public InventoryItems _iList;

    // Use this for initialization
    public void init(InventoryItems it)
    {
        this._iList = it;
    }

    public void test()
    {
		AItem i;
		i = new HealPot ();
		i.init ();
		this._items.Add(new Pair<AItem, int>(i, 2));

		AItem it;
			it = new HealPot ();
			it.init ();
		this._items.Add(new Pair<AItem, int>(it, 2));

		AItem itt;
		itt = new HealPot ();
		itt.init ();
		this._items.Add(new Pair<AItem, int>(itt, 2));

        this._iList = new InventoryItems();
    }

    void Start()
    {
        this._slotAmount = 45;
        this._slotPanel = this.gameObject.transform.FindChild("Slot Panel").gameObject;

        test(); //TODO

        for(int i = 0; i < this._slotAmount; i++)
        {
            Pair<GameObject, bool> ZIZI = new Pair<GameObject, bool>();
            ZIZI.First = Instantiate(this._inventorySlot);
            ZIZI.Second = true;
            this._slots.Add(ZIZI);
            this._slots[i].First.GetComponent<Slot>()._id = i;
            this._slots[i].First.transform.SetParent(this._slotPanel.transform);
        }
        AffAllItems();
        PeonSword FDP = new PeonSword();
        FDP.init();
        AddItem(FDP);
        HealPot FDP2 = new HealPot();
        FDP2.init();
        AddItem(FDP2);
    }

    public void AffAllItems()
    {
        foreach (Pair<AItem, int> x in this._items)
        {
            GameObject t;
            ItemData tmp;
            if (x.First.Stack == false)
            {
                t = Instantiate(this._inventoryItem);
                t.GetComponent<ItemData>()._slot = x.Second;
                tmp = t.GetComponent<ItemData>();
                tmp._item = x.First;
                tmp._slot = x.Second;
                t.transform.GetChild(0).gameObject.SetActive(false);
                t.transform.SetParent(this._slots[x.Second].First.transform);
                this._slots[x.Second].Second = false;
                t.transform.position = Vector2.zero;
                t.GetComponent<Image>().sprite = x.First.s;
                t.name = x.First.Name;
				this._iList._items.Add (tmp);
            }
            else {
				int pos = 0;
				if ((pos = CheckIfItemIsInInventory (x.First.Id)) != -1) {
					this._iList._items [pos]._nbr += 1;
					this._iList._items [pos].gameObject.transform.GetChild (0).GetChild (0).GetComponent<Text> ().text = this._iList._items [pos]._nbr.ToString ();
				} 
				else 
				{
					t = Instantiate(this._inventoryItem);
					tmp = t.GetComponent<ItemData>();
					tmp._item = x.First;
					tmp._slot = x.Second;
					tmp._nbr = 1;
					t.transform.SetParent(this._slots[x.Second].First.transform);
					this._slots[x.Second].Second = false;
					t.transform.position = Vector2.zero;
					t.GetComponent<Image>().sprite = x.First.s;
					t.name = x.First.Name;
					t.gameObject.transform.GetChild (0).GetChild (0).GetComponent<Text> ().text = tmp._nbr.ToString();
					this._iList._items.Add (tmp);
				}
			}
		}
    }

    public void AddItem(AItem Item)
    {
        int pos;

        if (Item.Stack && ((pos = CheckIfItemIsInInventory(Item.Id)) != -1))
        {
            this._iList._items[pos]._nbr += 1;
			this._iList._items[pos].gameObject.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = this._iList._items[pos]._nbr.ToString();
        }
        else
        {
            for (int i = 0; i < this._slotAmount; i++)
            {
                if (this._slots[i].Second == true)
                {
					GameObject t = Instantiate(this._inventoryItem);
					ItemData tmp = t.GetComponent<ItemData>();
					tmp._item = Item;
					tmp._slot = i;
					tmp._nbr = 1;
					this._iList._items.Add (tmp);
					if (Item.Stack == false)
						t.transform.GetChild (0).gameObject.SetActive (false);
					t.transform.SetParent(this._slots[i].First.transform);
					this._slots[i].Second = false;
					t.transform.position = Vector2.zero;
					t.GetComponent<Image>().sprite = Item.s;
					t.name = Item.Name;

                    break;
                }
            }
        }
    }

    public int CheckIfItemIsInInventory(int id)
    {
        int i = 0;
        foreach (ItemData x in this._iList._items)
        {
            if (x._item.Id == id)
                return i;
            i++;
        }
        return -1;
    }
}
