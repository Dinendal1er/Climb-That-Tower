using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuUIManager : MonoBehaviour 
{

	void Start()
	{
		if (SoundManager.getInstance () != null) 
		{
			SoundManager.getInstance ().PlayMusic ();
		}
	}

	public void toOption()
	{
		if (UIManager.getInstance () != null) 
		{
			UIManager.getInstance ().MainMenuToggle ();
			UIManager.getInstance ().OptionToggle ();
		}
		
	}

	public void Play()
	{
		UIManager.getInstance ().MainMenuToggle ();
		SceneManager.LoadScene ("AfterMenu", LoadSceneMode.Additive);
		Destroy (GameObject.Find ("Main Camera"));
	}

}
