using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {

	public GameObject menuUI;
	public GameObject optionUI;

	private CanvasGroup menuGroup;
	private CanvasGroup optionGroup;

	private bool menuToggle = true;
	private bool optionToggle = true;

	private static UIManager instance = null;

	static public UIManager getInstance()
	{
		if (instance != null)
			return instance;
		else
			return null;
			
	}

	void Awake()
	{
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad (this.gameObject);
		} 
		else
			Destroy (this.gameObject);
	}
		

	// Use this for initialization
	void Start () 
	{

		menuGroup = menuUI.GetComponent<CanvasGroup> ();
		if (menuGroup == null)
			Debug.LogError ("Missing MenuUI");
		optionGroup = optionUI.GetComponent<CanvasGroup> ();
		if (optionGroup == null)
			Debug.LogError ("Missing OptionUI");
		OptionToggle ();
	}

	public void MenuToggle()
	{
		menuToggle = !menuToggle;
		menuGroup.alpha = (menuToggle == true) ? 1f : 0f;
		menuUI.SetActive (menuToggle);
	}

	public void OptionToggle()
	{
		optionToggle = !optionToggle;
		optionGroup.alpha = (optionToggle == true) ? 1f : 0f;
		optionUI.SetActive (optionToggle);
	}
}
