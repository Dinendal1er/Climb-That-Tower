using UnityEngine;
using System.Collections;

public class Viewer : MonoBehaviour {

	public float speed = 7F;


	// Use this for initialization
	void Start ()
	{
	
	}
		
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKey (KeyCode.RightArrow) )//|| Input.mousePosition.x == Screen.width)
		{
			transform.Translate(Vector3.right * Time.deltaTime * speed);
		}
		if (Input.GetKey (KeyCode.LeftArrow) )//|| Input.mousePosition.x == 0)
		{
			transform.Translate(Vector3.left * Time.deltaTime * speed);
		}
		if (Input.GetKey (KeyCode.DownArrow) )//|| Input.mousePosition.y == 0)
		{
			transform.Translate(Vector3.down * Time.deltaTime * speed);
		}
		if (Input.GetKey (KeyCode.UpArrow) )//|| Input.mousePosition.y == Screen.height)
		{
			transform.Translate(Vector3.up * Time.deltaTime * speed);
		}
	}
}
