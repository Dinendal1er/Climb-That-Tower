using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

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
		Destroy (GameObject.Find ("Main Camera"));
		SceneManager.LoadScene ("AfterMenu", LoadSceneMode.Additive);
	}

}
