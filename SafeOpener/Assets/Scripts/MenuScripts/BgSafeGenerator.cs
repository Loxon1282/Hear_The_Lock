using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BgSafeGenerator : MonoBehaviour {
	GameObject[] musics;
	public GameObject safe;

	// Use this for initialization
	void Start () {
		if (SceneManager.GetActiveScene ().buildIndex == 0)
			StartCoroutine ("startDeley");
		else
			startGen ();

	}
	void Update(){
		
	}
	void Generate(){
		Instantiate (safe);
	}
	void startGen(){
		InvokeRepeating ("Generate", 1, 0.15f);
	}
	IEnumerator startDeley(){
		yield return new WaitForSeconds (1);
		InvokeRepeating ("Generate", 1, 0.15f);
	}
	void Awake(){
		musics = GameObject.FindGameObjectsWithTag("BgMusic");
		if (musics.Length > 1)
			Destroy (musics [1]);
	}
}