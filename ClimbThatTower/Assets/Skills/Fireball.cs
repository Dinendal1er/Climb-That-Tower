using UnityEngine;
using System.Collections;

public class Fireball : ASkill {

	// Use this for initialization
	void Start () {
        this._dmg = 5;
        this._portée = 5;
        this._precision = 100;
        this._state = null;
        this._type = 0; //TODO
        this._zone = 2;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
