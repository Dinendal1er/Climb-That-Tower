using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {

	public GameObject menuUI;
	public GameObject mainMenuUI;
	public GameObject optionUI;

	private CanvasGroup menuGroup;
	private CanvasGroup mainMenuGroup;
	private CanvasGroup optionGroup;

	private bool _menuToggle = true;
	private bool _mainMenuToggle = true;
	private bool _optionToggle = true;

	private static UIManager instance = null;

	public bool menuToggle {
		get {
			return this._menuToggle;
		}
	}

	public bool mainMenuToggle {
		get {
			return this._mainMenuToggle;
		}
	}

	public bool optionToggle {
		get {
			return this._optionToggle;
		}
	}

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
		mainMenuGroup = mainMenuUI.GetComponent<CanvasGroup> ();
		if (mainMenuGroup == null)
			Debug.LogError("Missing mainMenuUI");
		OptionToggle ();
		MenuToggle ();
	}

	public void MenuToggle()
	{
		_menuToggle = !_menuToggle;
		menuGroup.alpha = (_menuToggle == true) ? 1f : 0f;
		menuUI.SetActive (_menuToggle);
	}

	public void OptionToggle()
	{
		_optionToggle = !_optionToggle;
		optionGroup.alpha = (_optionToggle == true) ? 1f : 0f;
		optionUI.SetActive (_optionToggle);
	}

	public void MainMenuToggle()
	{
		_mainMenuToggle = !_mainMenuToggle;
		mainMenuGroup.alpha = (_mainMenuToggle == true) ? 1f : 0f;
		mainMenuUI.SetActive (_mainMenuToggle);
	}
}
