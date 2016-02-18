using UnityEngine;
using System.Collections;
using System.Reflection;
using UnityEngine.UI;

public class PlayerChoice
{
    private GameObject _obj;
    private AEntity _player;

    public void JobIcon(Transform obj)
    {

    }

    public void Name(Transform obj)
    {
        Text txt = obj.GetComponent<Text>();
        txt.text = this._player.Name;
    }

    public void Job(Transform obj)
    {
        Text txt = obj.GetComponent<Text>();
        txt.text = this._player.Job;
    }

    public void HP(Transform obj)
    {
        Slider bar = obj.GetComponent<Slider>();
        bar.maxValue = this._player.MaxHp;
        bar.value = this._player.Hp;
        foreach (Transform child in obj)
        {
            if (child.name == "HP Value")
            {
                Text txt = child.GetComponent<Text>();
                txt.text = this._player.Hp.ToString() + "/" + this._player.MaxHp.ToString();
            }
        }
    }

    public void Mana(Transform obj)
    {
        Slider bar = obj.GetComponent<Slider>();
        bar.maxValue = this._player.MaxMp;
        bar.value = this._player.Mp;
        foreach (Transform child in obj)
        {
            if (child.name == "Mana Value")
            {
                Text txt = child.GetComponent<Text>();
                txt.text = this._player.Mp.ToString() + "/" + this._player.MaxMp.ToString();
            }
        }
    }

    public void Exp(Transform obj)
    {
        Slider bar = obj.GetComponent<Slider>();
        bar.maxValue = this._player.MaxExp;
        bar.value = this._player.Exp;
        foreach (Transform child in obj)
        {
            if (child.name == "Exp Value")
            {
                Text txt = child.GetComponent<Text>();
                txt.text = this._player.Exp.ToString() + "/" + this._player.MaxExp.ToString();
            }
        }
    }

    public void PlayerSprite(Transform obj)
    {
    }

    public PlayerChoice(GameObject obj, float x, float y, AEntity player)
    {
        this._obj = MonoBehaviour.Instantiate(obj, new Vector3(x, y, 0), new Quaternion()) as GameObject;
        this._obj.gameObject.transform.SetParent(GameObject.Find("Canvas").transform);
        this._player = player;
        foreach(Transform child in this._obj.transform)
        {
            Object[] args = new Object[1];
            args[0] = child;
            System.Type thisType = this.GetType();
            MethodInfo theMethod = thisType.GetMethod(child.name);
            if (theMethod != null)
                theMethod.Invoke(this, args);
        }
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

    public void Update()
    {

    }
}
