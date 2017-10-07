using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundMusic : MonoBehaviour {

	AudioSource audio2;
//	static bool AudioBegin = false; 
	void Start(){
		audio2 = gameObject.GetComponent<AudioSource> ();

	}

	void Awake()
	{
		audio2 = gameObject.GetComponent<AudioSource> ();
		DontDestroyOnLoad (gameObject);
		if (!audio2.isPlaying)
			audio2.Play ();
	}

	void Update(){


	}
//	void Update () {
//		if(Application.loadedLevelName == "Upgraded")
//		{
//			audio.Stop();
//			AudioBegin = false;
//		}
//	}
}
