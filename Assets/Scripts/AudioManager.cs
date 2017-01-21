using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	public AudioClip BGM;
	public AudioClip WaveSFX;

	public AudioClip YouWinSFX;
	public AudioClip YouLoseSFX;
	public AudioClip ClickSFX;

	AudioSource audio;

	public static AudioManager Instance = null;

	void Awake()
	{
		//Check if instance already exists
		if (Instance == null)

			//if not, set instance to this
			Instance = this;

		//If instance already exists and it's not this:
		else if (Instance != this)

			//Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
			Destroy(gameObject);    

		//Sets this to not be destroyed when reloading scene
		DontDestroyOnLoad(gameObject);
	}


	void Start() {
		audio = GetComponent<AudioSource>();
	}

	public void PlayBGM() {
//		audio.PlayOneShot (BGM, 0.5f);
	}

	public void PlayWaveSFX () {
//		audio.PlayOneShot (WaveSFX, 0.75f);
	}

	public void PlayBallSFX () {
//		audio.PlayOneShot ();
	}

	public void PlayYouWin () {
		audio.PlayOneShot (YouWinSFX);
	}

	public void PlayYouLose () {
		audio.PlayOneShot (YouLoseSFX);
	}

	public void PlayClickSFX () {
		audio.PlayOneShot (ClickSFX);
	}
}
