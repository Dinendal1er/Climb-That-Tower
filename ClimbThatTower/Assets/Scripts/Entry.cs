using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Entry : MonoBehaviour
{
	public GameObject board;

	// Use this for initialization
	void Start ()
	{
		
	}

	public void EnterBattleMode()
	{
		for (int w = 0; w < GameObject.Find("Overworld").transform.GetChildCount(); ++w)
		{
			GameObject.Find("Overworld").transform.GetChild(w).gameObject.SetActive(false);
		}
		for (int w = 0; w < board.transform.GetChildCount(); ++w)
		{
			board.transform.GetChild(w).gameObject.SetActive(true);
		}
	}

	public void LeaveBattleMode()
	{
		for (int w = 0; w < board.transform.GetChildCount(); ++w)
		{
			board.transform.GetChild(w).gameObject.SetActive(false);
		}
		for (int w = 0; w < GameObject.Find("Overworld").transform.GetChildCount(); ++w)
		{
			GameObject.Find("Overworld").transform.GetChild(w).gameObject.SetActive(true);
		}
	}

	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKey(KeyCode.E))
		{
			EnterBattleMode();
		}
		if (Input.GetKey(KeyCode.Escape))
		{
			LeaveBattleMode();
		}
	}
}
