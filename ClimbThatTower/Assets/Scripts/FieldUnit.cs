using UnityEngine;
using System.Collections;

public class FieldUnit : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseEnter()
	{
		GetComponent<Renderer> ().material = Resources.Load ("Materials/" + (this.name.Split ('(')) [0] + "hl") as Material;
	}

	void OnMouseExit()
	{
		GetComponent<Renderer> ().material = Resources.Load ("Materials/" + (this.name.Split ('(')) [0]) as Material;
	}
}
