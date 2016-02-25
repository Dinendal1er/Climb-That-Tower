using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	private bool inFight = false;
	private bool placed = false;
	private MapGenerator.FieldInfo[] grid;

	[SerializeField]
	private Movement player;

	// Use this for initialization
	void Start () {
	
	}

	void SwitchToFight(Entry enter)
	{
		inFight = true;
		player.GetComponent<Movement> ().enabled = false;
		enter.EnterBattleMode ();
		grid = enter.grid;
		player.gameObject.SetActive (false);

	}

	void OverWorldBehaviour()
	{
		Entry enter;

		if (Input.GetButtonDown ("Inventory"))
		UIManager.getInstance ().MenuToggle ();
		if (!UIManager.getInstance ().menuToggle) 
		{
			player.Move ();
			if ((enter = player.ToFight ()) != null)
				SwitchToFight (enter);
		}
	}

	void FightBehaviour()
	{
		//Temporaire pour le  déplacement.
		if (Input.GetButtonDown ("Submit")) {
			RaycastHit hit;

			Quaternion rotation = Quaternion.identity;
			rotation.eulerAngles = new Vector3 (45F, 0, 45F);

			Vector3 start = player.transform.position;
			Vector3 end = start + (rotation * new Vector3 (0f, 0f, 2f));
			Debug.DrawLine (start, end, Color.cyan);
			if (Physics.Linecast (start, end, out hit)) 
			{
				/*Vector3 Begin = hit.collider.transform.position;
				Begin = Quaternion.Inverse (rotation) * Begin;
				Debug.Log ((int)Begin.x + " " + (int)Begin.y + " " + Begin.z);*/
			
				RaycastHit hitInfo = new RaycastHit ();

				if (Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out hitInfo) && !hitInfo.transform.CompareTag ("Bounds")) {
					start = hitInfo.transform.position;
					end = start + (rotation * new Vector3 (0f, 0f, -2f));
					if (!Physics.Linecast (start, end)) {

						if (GameObject.Find ("stone2") != null)
							Debug.Log ("OKKKKK");

						/*Vector3 Finish = Quaternion.Inverse (rotation) * hitInfo.collider.transform.position;
						Debug.Log ((int)Finish.x + " " + (int)Finish.y);*/
						int y = 34; //GameObject.Find ("MapGenerator").GetComponent<MapGenerator> ().columns;
						int x = 34; //GameObject.Find ("MapGenerator").GetComponent<MapGenerator> ().rows;
						//var map = GameObject.Find ("MapGenerator").GetComponent<MapGenerator> ().grid;
						int a = hit.collider.gameObject.GetComponent<FieldUnit> ().info.index; //(int)Begin.y * y + (int)Begin.x;
						int b = hitInfo.collider.gameObject.GetComponent<FieldUnit> ().info.index; //(int)Finish.y * y + (int)Finish.x;
						Debug.Log ("Limite Y = " + y + " Limite X = " + x + " pos a = " + a + "pos b= " + b);
						Debug.Log (grid.Length);
						List<AStarBitch.AStarNode> t = AStarBitch.Astarfct (grid, y, x, a, b);
						if (t != null) {
							Debug.Log ("Ici");
							foreach (AStarBitch.AStarNode k in t) {
								Debug.Log (grid [k.pos].height);
								RaycastHit hitInfo2 = new RaycastHit ();

								Vector3 s = rotation * new Vector3 (k.x, k.y, -(grid [k.pos].height + 1));
								Vector3 e = s + (rotation) * new Vector3 (0F, 0f, 10f);
								if (Physics.Linecast (s, e, out hitInfo2)) 
								{
									hitInfo2.collider.gameObject.GetComponent<Renderer> ().material = Resources.Load ("Materials/" + (this.name.Split ('(')) [0] + "hl") as Material;
								}
								Debug.Log ("Pos = " + k.pos);
							}
						}
					}
				}
			}
		}
	}

	void PlaceForFight()
	{
			//Temporaire pour le placement
		if (Input.GetMouseButtonDown (0)) {
			RaycastHit hitInfo = new RaycastHit ();

			bool hit = Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out hitInfo);
			if (hit && !hitInfo.transform.CompareTag("Bounds")) {
				Quaternion rotation = Quaternion.identity;
				rotation.eulerAngles = new Vector3 (45F, 0, 45F);

				Vector3 start = hitInfo.transform.position;
				Vector3 end = start + (rotation * new Vector3 (0f, 0f, -2f));
				if (!Physics.Linecast (start, end)) {
					player.transform.position = hitInfo.transform.position + (rotation * new Vector3 (0f, 0f, -2.32f + ((1 - hitInfo.transform.localScale.z) / 2)));
					player.gameObject.SetActive (true);
					placed = true;
				}
			}
		}
	}

	// Update is called once per frame
	void Update () {
		if (inFight == false) {
			OverWorldBehaviour ();
		} else 
		{
			if (placed == false)
				PlaceForFight ();
			else
			FightBehaviour ();
		}
	}
}
