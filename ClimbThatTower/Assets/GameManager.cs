using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	private bool _inFight = false;

	public bool InFight {
		get {
			return this._inFight;
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (!InFight && Input.GetKeyDown (KeyCode.I)) 
		{
			UIManager.getInstance ().MenuToggle ();
		}
	}
}
