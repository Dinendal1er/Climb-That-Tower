using UnityEngine;
using System.Collections;

public class EntityFollow : MonoBehaviour {

	public GameObject toFollow;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (this.transform.position.x != toFollow.transform.position.x
		    || this.transform.position.x != toFollow.transform.position.y)
			this.transform.position = new Vector3 (toFollow.transform.position.x, toFollow.transform.position.y, -10);
	}
}
