using UnityEngine;
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
			UIManager.getInstance ().MenuToggle ();
			UIManager.getInstance ().OptionToggle ();
		}
		
	}

}
