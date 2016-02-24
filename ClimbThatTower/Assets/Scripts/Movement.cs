using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    private Animator _anime;

	// Use this for initialization
	void Start () {
        _anime = gameObject.GetComponent<Animator>();
	}
	
    void turnoff ()
    {
        _anime.SetBool("Up", false);
        _anime.SetBool("Down", false);
        _anime.SetBool("Left", false);
        _anime.SetBool("Right", false);
        _anime.SetBool("Up-Right", false);
        _anime.SetBool("Up-Left", false);
        _anime.SetBool("Down-Right", false);
        _anime.SetBool("Down-Left",  false);
    }

    // Update is called once per frame
    void Update()
    {
        float Vertical = Input.GetAxisRaw("Vertical");
        float Horizontal = Input.GetAxisRaw("Horizontal");

        turnoff();
        if (Vertical == 1 && Horizontal == 0)
            _anime.SetBool("Up", true);
        if (Vertical == -1 && Horizontal == 0)
            _anime.SetBool("Down", true);
        if (Horizontal == -1 && Vertical == 0)
            _anime.SetBool("Left", true);
        if (Horizontal == 1 && Vertical == 0)
            _anime.SetBool("Right", true);
        if (Vertical == 1 && Horizontal == -1)
            _anime.SetBool("Up-Left", true);
        if (Vertical == 1 && Horizontal == 1)
            _anime.SetBool("Up-Right", true);
        if (Vertical == -1 && Horizontal == -1)
            _anime.SetBool("Down-Left", true);
        if (Vertical == -1 && Horizontal == 1)
            _anime.SetBool("Down-Right", true);
        if (Vertical == 0 && Horizontal == 0)
            _anime.enabled = false;
        if (Vertical != 0 || Horizontal != 0)
            _anime.enabled = true;
    }
}
