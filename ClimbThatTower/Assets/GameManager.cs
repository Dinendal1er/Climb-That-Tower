using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	private bool inFight = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (inFight == false && Input.GetButtonDown ("Inventory"))
			UIManager.getInstance ().MenuToggle ();
	}
}
