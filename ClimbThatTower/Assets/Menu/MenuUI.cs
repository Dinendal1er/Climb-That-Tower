using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

public class MenuUI : MonoBehaviour
{
    private bool isShowing = false;
    private Team team = new Team();
    private List<PlayerChoice> playerChoices = new List<PlayerChoice>();
    private PlayerChoice cursor = null;
    public GameObject playerChoice;
    public GameObject menu;
    private GameObject _menuInstantiated;

    void Start()
    {
        this._menuInstantiated = Instantiate(this.menu, new Vector3(408, Screen.height - 8, 0), new Quaternion()) as GameObject;
        this._menuInstantiated.transform.SetParent(GameObject.Find("MenuUI").transform);
    }

    void OnEnable()
    {
		if (_menuInstantiated != null)
			this._menuInstantiated.gameObject.SetActive(true);
        for (int i = 0; i < this.playerChoices.Count; i++)
            this.playerChoices[i].SetActive(true);
    }

    void OnDisable()
    {
		if (_menuInstantiated != null)
        this._menuInstantiated.gameObject.SetActive(false);
        for (int i = 0; i < this.playerChoices.Count; i++)
            this.playerChoices[i].SetActive(false);
    }

    private void changeCursor(PlayerChoice newPlayer)
    {
        if (this.cursor == newPlayer)
            return;
        this.cursor = newPlayer;
        foreach (Transform child in this._menuInstantiated.transform)
        {
            switch (child.name)
            {
                case "Equipment Panel":
                    foreach(Transform lChild in child)
                    {
                        Text txt = null;
                        switch (lChild.name)
                        {
                            case "Name":
                                txt = lChild.GetComponent<Text>();
                                txt.text = this.cursor.Player.Name;
                                break;
                            case "Job Name":
                                txt = lChild.GetComponent<Text>();
                                txt.text = this.cursor.Player.Job;
                                break;
                            default:
                                break;
                        }
                    }
                    break;
                case "Stats Panel":
                    foreach (Transform lChild in child)
                    {
                        Text txt = null;
                        Slider bar = null;
                        switch (lChild.name)
                        {
                            case "HP":
                                bar = lChild.GetComponent<Slider>();
                                bar.maxValue = this.cursor.Player.MaxHp;
                                bar.value = this.cursor.Player.Hp;
                                foreach (Transform obj in lChild)
                                {
                                    if (obj.name == "HP Value")
                                    {
                                        txt = obj.GetComponent<Text>();
                                        txt.text = this.cursor.Player.Hp.ToString() + "/" + this.cursor.Player.MaxHp.ToString();
                                    }
                                }
                                break;
                            case "Mana":
                                bar = lChild.GetComponent<Slider>();
                                bar.maxValue = this.cursor.Player.MaxMp;
                                bar.value = this.cursor.Player.Mp;
                                foreach (Transform obj in lChild)
                                {
                                    if (obj.name == "Mana Value")
                                    {
                                        txt = obj.GetComponent<Text>();
                                        txt.text = this.cursor.Player.Mp.ToString() + "/" + this.cursor.Player.MaxMp.ToString();
                                    }
                                }
                                break;
                            case "Exp":
                                bar = lChild.GetComponent<Slider>();
                                bar.maxValue = this.cursor.Player.MaxExp;
                                bar.value = this.cursor.Player.Exp;
                                foreach (Transform obj in lChild)
                                {
                                    if (obj.name == "Exp Value")
                                    {
                                        txt = obj.GetComponent<Text>();
                                        txt.text = this.cursor.Player.Exp.ToString() + "/" + this.cursor.Player.MaxExp.ToString();
                                    }
                                }
                                break;
                            case "Strength":
                                txt = lChild.GetComponent<Text>();
                                txt.text = "Force : " + this.cursor.Player.Strenght.ToString();
                                break;
                            case "Defense":
                                txt = lChild.GetComponent<Text>();
                                txt.text = "Armure : " + this.cursor.Player.Defense.ToString();
                                break;
                            case "Resistance":
                                txt = lChild.GetComponent<Text>();
                                txt.text = "Resistance : " + this.cursor.Player.Resistance.ToString();
                                break;
                            case "Stamina":
                                txt = lChild.GetComponent<Text>();
                                txt.text = "Stamina : " + this.cursor.Player.Stamina.ToString();
                                break;
                            case "Speed":
                                txt = lChild.GetComponent<Text>();
                                txt.text = "Vitesse : " + this.cursor.Player.Speed.ToString();
                                break;
                            case "Intelligence":
                                txt = lChild.GetComponent<Text>();
                                txt.text = "Intelligence : " + this.cursor.Player.Intel.ToString();
                                break;
                            case "Agility":
                                txt = lChild.GetComponent<Text>();
                                txt.text = "Agilite : " + this.cursor.Player.Agility.ToString();
                                break;
                            case "Precision":
                                txt = lChild.GetComponent<Text>();
                                txt.text = "Precision : " + this.cursor.Player.Precision.ToString();
                                break;
                            case "Luck":
                                txt = lChild.GetComponent<Text>();
                                txt.text = "Chance : " + this.cursor.Player.Luck.ToString();
                                break;
                            case "MagicResistance":
                                txt = lChild.GetComponent<Text>();
                                txt.text = "Def magic : " + this.cursor.Player.MagicResistance.ToString();
                                break;
                            default:
                                break;
                        }
                    }
                    break;
                default:
                    break;
            }
        }
    }

    void Update()
    {
        for (int i = 0; i < this.playerChoices.Count; i++)
        {
            if (this.playerChoices[i].hasClicked())
                this.changeCursor(this.playerChoices[i]);
        }
    }

    void OnGUI()
    {
        for (int i = 0; i < this.team.players.Count; i++)
        {
            if (this.playerChoices.Count <= i)
                {
                    this.playerChoices.Add(new PlayerChoice(this.playerChoice, 4, Screen.height - (i + 1) * PlayerChoice.getHeight() + 4, this.team.players[i]));
                    if (this.playerChoices.Count == 1)
                        this.changeCursor(this.playerChoices[i]);
                }
        }
    }
}
