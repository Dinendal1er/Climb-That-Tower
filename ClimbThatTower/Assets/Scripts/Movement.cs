using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	[SerializeField]
	private float speed;
    private Animator _anime;

	// Use this for initialization
	void Start () {
        _anime = gameObject.GetComponent<Animator>();
		Quaternion rotation = Quaternion.identity;
		rotation.eulerAngles = new Vector3 (45F, 0, 45F);
		this.transform.position = rotation * new Vector3 (1f, 1f, -2.35f);
		Quaternion pos = Quaternion.identity;
		pos.eulerAngles = new Vector3 (315F, 0f, 0f);
		this.transform.rotation = pos;
		this.transform.localScale = new Vector3 (2.7f, 4f, 2f);
	}
	
    void turnoff ()
    {
        _anime.SetBool("Up", false);
        _anime.SetBool("Down", false);
        _anime.SetBool("Left", false);
        _anime.SetBool("Right", false);
        _anime.SetBool("Up-Right", false);
        _anime.SetBool("Up-Left", false);
        _anime.SetBool("Down-Right", false);
        _anime.SetBool("Down-Left",  false);
    }

	public Entry ToFight()
	{
		if (Input.GetButtonDown("Submit")) 
		{
			RaycastHit hit;

			Quaternion rotation = Quaternion.identity;
			rotation.eulerAngles = new Vector3 (45F, 0, 45F);

			Vector3 start = this.transform.position;
			Vector3 end = start + (rotation * new Vector3 (0f, 0f, 2f));

			Debug.DrawLine (start, end, Color.cyan);

			if (Physics.Linecast (start, end, out hit)) 
			{
				Debug.Log ("Collision");
				Entry enter;
				enter = hit.collider.gameObject.GetComponent<Entry> ();
				if (enter != null) 
				{
					return enter;
				}
			}
		}
		return null;
	}

    public void Move()
    {
        float Vertical = Input.GetAxisRaw("Vertical");
        float Horizontal = Input.GetAxisRaw("Horizontal");

        turnoff();
        if (Vertical == 1 && Horizontal == 0)
            _anime.SetBool("Up", true);
        if (Vertical == -1 && Horizontal == 0)
            _anime.SetBool("Down", true);
        if (Horizontal == -1 && Vertical == 0)
            _anime.SetBool("Left", true);
        if (Horizontal == 1 && Vertical == 0)
            _anime.SetBool("Right", true);
        if (Vertical == 1 && Horizontal == -1)
            _anime.SetBool("Up-Left", true);
        if (Vertical == 1 && Horizontal == 1)
            _anime.SetBool("Up-Right", true);
        if (Vertical == -1 && Horizontal == -1)
            _anime.SetBool("Down-Left", true);
        if (Vertical == -1 && Horizontal == 1)
            _anime.SetBool("Down-Right", true);
        if (Vertical == 0 && Horizontal == 0)
            _anime.enabled = false;
        if (Vertical != 0 || Horizontal != 0)
            _anime.enabled = true;

		if (Vertical != 0 || Horizontal != 0) {
			float Vc = 0;
			float Hc = 0;
			bool hitr;
			bool hitl;


			Quaternion rot = Quaternion.identity;
			rot.eulerAngles = new Vector3 (45F, 0, 45F) - new Vector3 (315F, 0, 45F);

			Quaternion rota = Quaternion.identity;
			rota.eulerAngles = new Vector3 (45F, 0, 0F);

			Vector3 move = rot * new Vector3 (Horizontal, Vertical, 0);
			Hc = (Horizontal > 0) ? 0.5f : (Horizontal < 0) ? -0.5f : 0;
			Vc = (Vertical > 0) ? 0.5f : (Vertical < 0) ? -0.3f : 0;

			Quaternion rotation = Quaternion.identity;
			rotation.eulerAngles = new Vector3 (45F, 0, 45F);

			//Start point of raycasting.
			Vector3 startr = (transform.position - (rotation * new Vector3 (0f, 0f, -1.32f))) + new Vector3 (0.35f, 0f, 0f);
			Vector3 startl = (transform.position - (rotation * new Vector3 (0f, 0f, -1.32f))) + new Vector3 (-0.35f, 0f, 0f);

			//End point of raycasting.
			Vector3 endr;
			Vector3 endl;

			if (Vc == 0 || Hc == 0) {
				endr = startr + (rota * new Vector3 (0f, Vc, 0f)) + new Vector3 (Hc, 0f, 0f);
				endl = startl + (rota * new Vector3 (0f, Vc, 0f)) + new Vector3 (Hc, 0f, 0f);
			} else {
				endr =	startr + ((rota * new Vector3 (0f, Vc, 0f))) + (new Vector3 (Hc, 0f, 0f) / 2);
				endl =	startl + ((rota * new Vector3 (0f, Vc, 0f))) + (new Vector3 (Hc, 0f, 0f) / 2);
			}

			Debug.DrawLine (startr, endr, Color.cyan);
			Debug.DrawLine (startl, endl, Color.cyan);
			//Start raycasting
			hitr = Physics.Linecast (startr, endr);
			hitl = Physics.Linecast (startl, endl);
			if (!hitr && !hitl)
				this.transform.Translate (move * speed * Time.deltaTime);
		}
    }
}
