using UnityEngine;
using System.Collections.Generic;

public abstract class AJob {

    protected string _name;
    protected List<ASkill> _skill;

    abstract public void levelUp(AEntity entity);
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
