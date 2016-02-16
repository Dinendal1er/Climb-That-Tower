using UnityEngine;
using System.Collections;

public abstract class AState {
    
    protected string _name;
    //TODO
    protected string _img;

    public abstract void doState(AEntity entity);

	// Use this for initialization
	void Start () {
	
	}
	// Update is called once per frame
	void Update () {
	
	}
}
