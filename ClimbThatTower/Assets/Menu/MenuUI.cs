using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

public class MenuUI : MonoBehaviour
{
    private bool isShowing = false;
    private Team team = new Team();
    private List<PlayerChoice> playerChoices = new List<PlayerChoice>();
    public GameObject playerChoice;
    public GameObject menu;
    private GameObject _menuInstantiated;

    // Use this for initialization
    void Start()
    {
        this._menuInstantiated = Instantiate(this.menu, new Vector3(408, Screen.height - 8, 0), new Quaternion()) as GameObject;
        this._menuInstantiated.transform.SetParent(GameObject.Find("MenuUI").transform);
        this._menuInstantiated.gameObject.SetActive(false);
    }

    public void TestButton(GameObject button)
    {
        Debug.Log(button.name);
    }

    void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            this.isShowing = !this.isShowing;
            for (int i = 0; i < this.playerChoices.Count; i++)
                this.playerChoices[i].SetActive(this.isShowing);
            this._menuInstantiated.SetActive(this.isShowing);
        }
        if (Input.GetButtonDown("Cancel"))
        {
            this.isShowing = false;
            for (int i = 0; i < this.playerChoices.Count; i++)
                this.playerChoices[i].SetActive(false);
            this._menuInstantiated.SetActive(false);
        }
    }

    private bool _isMouseMoving()
    {
        return (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("MouseY") != 0);
    }

    void OnGUI()
    {
        if (this.isShowing)
        {
            for (int i = 0; i < this.team.players.Count; i++)
            {
                if (this.playerChoices.Count <= i)
                    this.playerChoices.Add(new PlayerChoice(this.playerChoice, 4, Screen.height - (i + 1) * PlayerChoice.getHeight() + 4, this.team.players[i]));
            }
        }
    }

    public void returnButton()
    {
        this.isShowing = !this.isShowing;
    }
}
