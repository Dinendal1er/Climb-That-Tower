using UnityEngine;
using System.Collections;

public class Poison : AState {

    override public void doState(AEntity entity)
    {
        entity.Hp -= 2;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
