using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionUIManager : MonoBehaviour {

	[SerializeField]
	private Slider musicSlide;
	[SerializeField]
	private Slider effectSlide;

	// Use this for initialization
	void Start () {
		if (OptionManager.getInstance () != null) 
		{
			musicSlide.value = OptionManager.getInstance ().getMusicLevel ();
			SoundManager.getInstance ().SetMusicLevel (musicSlide.value);
			effectSlide.value = OptionManager.getInstance ().getEffectLevel ();
			SoundManager.getInstance ().SetEffectLevel (effectSlide.value);
		}
	
	}

	public void MusicSlide(Slider slider)
	{
		if (OptionManager.getInstance () != null && SoundManager.getInstance () != null) 
		{
			OptionManager.getInstance ().setMusicLevel (slider.value);
			SoundManager.getInstance ().SetMusicLevel (slider.value);
		}
	}

	public void EffectSlide(Slider slider)
	{
		if (OptionManager.getInstance () != null && SoundManager.getInstance () != null) {
			OptionManager.getInstance ().setEffectLevel (slider.value);
			SoundManager.getInstance ().SetEffectLevel (slider.value);
		}
	}

	public void Back()
	{
		if (UIManager.getInstance () != null) 
		{
			UIManager.getInstance ().OptionToggle ();
			UIManager.getInstance ().MenuToggle ();
		}
	}
}
