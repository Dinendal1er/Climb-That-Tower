using UnityEngine;
using System.Collections;
using System.Reflection;
using UnityEngine.UI;

public class PlayerChoice
{
    private GameObject _obj;
    private APlayer _player;
    private HasClicked _button;

    public APlayer Player
    {
        get
        {
            return _player;
        }

        set
        {
            _player = value;
        }
    }

    public void JobIcon(Transform obj)
    {

    }

    public void Name(Transform obj)
    {
        Text txt = obj.GetComponent<Text>();
        txt.text = this.Player.Name;
    }

    public void Job(Transform obj)
    {
        Text txt = obj.GetComponent<Text>();
        txt.text = this.Player.Job;
    }

    public void HP(Transform obj)
    {
        Slider bar = obj.GetComponent<Slider>();
        bar.maxValue = this.Player.MaxHp;
        bar.value = this.Player.Hp;
        foreach (Transform child in obj)
        {
            if (child.name == "HP Value")
            {
                Text txt = child.GetComponent<Text>();
                txt.text = this.Player.Hp.ToString() + "/" + this.Player.MaxHp.ToString();
            }
        }
    }

    public void Mana(Transform obj)
    {
        Slider bar = obj.GetComponent<Slider>();
        bar.maxValue = this.Player.MaxMp;
        bar.value = this.Player.Mp;
        foreach (Transform child in obj)
        {
            if (child.name == "Mana Value")
            {
                Text txt = child.GetComponent<Text>();
                txt.text = this.Player.Mp.ToString() + "/" + this.Player.MaxMp.ToString();
            }
        }
    }

    public void Exp(Transform obj)
    {
        Slider bar = obj.GetComponent<Slider>();
        bar.maxValue = this.Player.MaxExp;
        bar.value = this.Player.Exp;
        foreach (Transform child in obj)
        {
            if (child.name == "Exp Value")
            {
                Text txt = child.GetComponent<Text>();
                txt.text = this.Player.Exp.ToString() + "/" + this.Player.MaxExp.ToString();
            }
        }
    }

    public void Level(Transform obj)
    {
        Text txt = obj.GetComponent<Text>();
        txt.text = "Niveau : " + this.Player.Lvl.ToString();
    }

    public void PlayerSprite(Transform obj)
    {
    }

    public PlayerChoice(GameObject obj, float x, float y, APlayer player)
    {
        this._obj = MonoBehaviour.Instantiate(obj, new Vector3(x, y, 0), new Quaternion()) as GameObject;
        this._obj.gameObject.transform.SetParent(GameObject.Find("MenuUI").transform);
        this.Player = player;
        foreach(Transform child in this._obj.transform)
        {
            Object[] args = new Object[1];
            args[0] = child;
            System.Type thisType = this.GetType();
            MethodInfo theMethod = thisType.GetMethod(child.name);
            if (theMethod != null)
                theMethod.Invoke(this, args);
        }
        this._button = this._obj.GetComponent<HasClicked>();
    }

    public static float getWidth()
    {
        return (Screen.width / 5);
    }

    public static float getHeight()
    {
        return (Screen.height / 4);
    }

    public void SetActive(bool active)
    {
        this._obj.SetActive(active);
    }

    public bool hasClicked()
    {
        return (this._button.hasClicked());
    }
}
