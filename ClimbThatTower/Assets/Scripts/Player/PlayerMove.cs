using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour 
{
	Quaternion rotation;

	[SerializeField]
	private float speed;

	// Use this for initialization
	void Start () {
		rotation = Quaternion.identity;
		rotation.eulerAngles = new Vector3 (45F, 0, 45F);
		this.transform.position = rotation * new Vector3 (8, 8, -1);
		Quaternion pos = Quaternion.identity;
		pos.eulerAngles = new Vector3 (310F, 0, 0);
		this.transform.rotation = pos;
	}
	
	// Update is called once per frame
	void Update () {
		float moveHorizontal = Input.GetAxisRaw ("Horizontal");
		float moveVertical = Input.GetAxisRaw ("Vertical");
		float Vc = 0;
		float Hc = 0;
		bool hit;
		bool hitL;


		Quaternion rot = Quaternion.identity;
		rot.eulerAngles = new Vector3(45F, 0 , 45F) - new Vector3 (310F, 0, 45F);


		//Vector3 move = rotation * new Vector3 (moveVertical, -moveHorizontal, 0);
		Vector3 move = rot * new Vector3 (moveHorizontal, moveVertical, 0);
		Hc = (moveHorizontal > 0) ? 0.5f : (moveHorizontal < 0)  ? -0.5f : 0;
		Vc = (moveVertical > 0) ? 0.65f : (moveVertical < 0) ? -0.65f : 0;


		//Start raycasting
		//Start point to raycasting.
		Vector3 start = transform.position;
		Vector3 startL = transform.position + (rot * new Vector3(0.5f, 0f, 0f));

		//End point of raycasting.
		//Vector3 end = (start + move);
		Vector3 end = start + (rot * new Vector3(Hc, Vc, 0f));
		Vector3 endL = startL + (rot * new Vector3(Hc, Vc, 0f));

		hit = Physics.Linecast (start, end);
		hitL = Physics.Linecast (startL, endL);
		if (hit == true || (hitL == true && moveHorizontal == 0)) {
			Debug.Log ("Collision");
			//rotation * new Vector3 (moveVertical, moveHorizontal, 0);
		} 
		else
		{
			this.transform.Translate (move * speed * Time.deltaTime);
			Debug.Log ("Pas Collision");
		}
	}
}
