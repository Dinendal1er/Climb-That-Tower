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


		Quaternion rot = Quaternion.identity;
		rot.eulerAngles = new Vector3 (45F, 0, 45F) - new Vector3 (310F, 0, 45F);

		Vector3 move = rot * new Vector3 (moveHorizontal, moveVertical, 0);
		Hc = (moveHorizontal > 0) ? 0.5f : (moveHorizontal < 0) ? -0.5f : 0;
		Vc = (moveVertical > 0) ? 0.65f : (moveVertical < 0) ? -0.65f : 0;



		//Start point of raycasting.
		Vector3 start = transform.position;

		//End point of raycasting.
		Vector3 end = start + (rot * new Vector3 (0f, Vc, 0f)) + new Vector3 (Hc, 0f, 0f);

		//Start raycasting
		hit = Physics.Linecast (start, end);
		if (!hit)
			this.transform.Translate (move * speed * Time.deltaTime);
	}
}