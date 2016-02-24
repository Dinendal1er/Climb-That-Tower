using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {

	public GameObject mainMenuUI;
	public GameObject optionUI;
	public GameObject menuUI;

	private CanvasGroup mainMenuGroup;
	private CanvasGroup optionGroup;
	private CanvasGroup menuGroup;

	private bool mainMenuToggle = true;
	private bool optionToggle = true;
	private bool menuToggle = true;

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

		mainMenuGroup = mainMenuUI.GetComponent<CanvasGroup> ();
		if (mainMenuGroup == null)
			Debug.LogError ("Missing mainMenuUI");
		optionGroup = optionUI.GetComponent<CanvasGroup> ();
		if (optionGroup == null)
			Debug.LogError ("Missing OptionUI");
		menuGroup = menuUI.GetComponent<CanvasGroup> ();
		if (optionGroup == null)
			Debug.LogError ("Missing MenuUI");
		OptionToggle ();
		MenuToggle ();
	}

	public void MenuToggle ()
	{
		menuToggle = !menuToggle;
		menuGroup.alpha = (menuToggle == true) ? 1f : 0f;
		menuUI.SetActive(menuToggle);
	}

	public void MainMenuToggle()
	{
		mainMenuToggle = !mainMenuToggle;
		mainMenuGroup.alpha = (mainMenuToggle == true) ? 1f : 0f;
		mainMenuUI.SetActive (mainMenuToggle);
	}

	public void OptionToggle()
	{
		optionToggle = !optionToggle;
		optionGroup.alpha = (optionToggle == true) ? 1f : 0f;
		optionUI.SetActive (optionToggle);
	}
}
