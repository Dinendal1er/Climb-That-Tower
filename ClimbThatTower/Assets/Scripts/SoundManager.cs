using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour {

	[SerializeField]
	private AudioClip[] Musics;
	[SerializeField]
	private AudioClip[] Effects;
	[SerializeField]
	private string[] EffectName;


	private Dictionary<string, AudioClip> Effect;

	private AudioSource MusicPlayer;
	private AudioSource EffectPlayer;

	private static SoundManager instance = null;

	public static SoundManager getInstance()
	{
		if (instance != null)
			return instance;
		return null;
	}

	void Awake()
	{
		if (instance == null) 
		{
			instance = this;
			DontDestroyOnLoad (this.gameObject);
		} 
		else
			Destroy (this.gameObject);
	}

	// Use this for initialization
	void Start ()
	{
		MusicPlayer = gameObject.GetComponents<AudioSource> () [0];
		if (MusicPlayer == null)
			Debug.LogError ("Missing Music Player");
		EffectPlayer = gameObject.GetComponents<AudioSource> () [1];
		if (EffectPlayer == null)
			Debug.LogError ("Missing Effect Player");
		Effect = new Dictionary<string, AudioClip> ();
		for (int i = 0; i < Effects.Length && i < EffectName.Length ; ++i) 
		{
			if (!string.IsNullOrEmpty(EffectName[i]) && Effects[i] != null)
				Effect.Add (EffectName [i], Effects [i]);
		}
		
	
	}

	public void PlayMusic()
	{
		MusicPlayer.clip = Musics [0];
		MusicPlayer.Play();
	}

	public void PlayEffects(string Name)
	{
		if (Effect.ContainsKey (Name)) 
		{
			EffectPlayer.clip = Effect [Name];
			EffectPlayer.Play ();
		}
	}

	public void SetMusicLevel(float lvl)
	{
		MusicPlayer.volume = lvl;
	}

	public void SetEffectLevel(float lvl)
	{
		EffectPlayer.volume = lvl;
	}
}
