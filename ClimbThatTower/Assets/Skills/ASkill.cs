using UnityEngine;
using System.Collections;

public abstract class ASkill {

    protected string _name;
    protected int _dmg;
    protected int _type;
    protected int _portée;
    protected int _zone;

    protected int _precision;
    protected AState _state;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
