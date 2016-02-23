using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CharacterTurner : MonoBehaviour
{
    public string characterName;
    private GameObject _player;

    void Start()
    {
        this._player = GameObject.Find(this.characterName);
    }

    void Update()
    {
        HasClicked click;
        Animator animator;

        animator = this._player.GetComponent<Animator>();
        foreach (Transform child in this.gameObject.transform)
        {
            click = child.GetComponent<HasClicked>();
            if (click.hasClicked())
            {
                print(child.name);
                animator.SetBool("Up", (child.name == "Up") ? true : false);
                animator.SetBool("Down", (child.name == "Down") ? true : false);
                animator.SetBool("Left", (child.name == "Left") ? true : false);
                animator.SetBool("Right", (child.name == "Right") ? true : false);
                animator.SetBool("Up-Right", (child.name == "Up-Right") ? true : false);
                animator.SetBool("Up-Left", (child.name == "Up-Left") ? true : false);
                animator.SetBool("Down-Right", (child.name == "Down-Right") ? true : false);
                animator.SetBool("Down-Left", (child.name == "Down-Left") ? true : false);
            }
        }
    }
}
