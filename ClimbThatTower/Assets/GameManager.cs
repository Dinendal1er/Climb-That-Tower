using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	private bool inFight = false;

	// Use this for initialization
	void Start () {
	
	}

	void OverWorldBehaviour()
	{
		if (Input.GetButtonDown ("Inventory"))
		UIManager.getInstance ().MenuToggle ();
	}

	// Update is called once per frame
	void Update () {
		if (inFight == false)
			OverWorldBehaviour ();
	}
}
