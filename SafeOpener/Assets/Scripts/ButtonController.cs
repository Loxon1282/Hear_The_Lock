﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour {
//	public GameObject panelLeft, panelRight;

	void Start() {
	//	if (SceneManager.GetActiveScene ().name != "menu" && SceneManager.GetActiveScene ().name != "levelSelection") {
	//		panelLeft.GetComponent<RectTransform> ().sizeDelta = new Vector2 ( Screen.width /2 , Screen.height/3);
	//		panelRight.GetComponent<RectTransform> ().sizeDelta = new Vector2 ( Screen.width /2 , Screen.height/3);
	//	}
	}
	void Update(){
		if (SceneManager.GetActiveScene ().name == "menu") {
			if (Input.GetKey (KeyCode.Escape)) {
				Application.Quit ();
			}

		} else if (SceneManager.GetActiveScene ().name == "levelSelection") {
			if (Input.GetKey (KeyCode.Escape)) {
				SceneManager.LoadScene ("menu");
			}
		} else if (SceneManager.GetActiveScene ().name == "levelSelection2") {
			if (Input.GetKey (KeyCode.Escape)) {
				SceneManager.LoadScene ("levelSelection");
			}
		} else if (SceneManager.GetActiveScene ().buildIndex > 0 && SceneManager.GetActiveScene ().buildIndex < 12) {
			if (Input.GetKey (KeyCode.Escape)) {
				SceneManager.LoadScene ("levelSelection");
			}
		} else {
			if (Input.GetKey (KeyCode.Escape)) {
				SceneManager.LoadScene ("levelSelection2");
			}
		}
	}
	public void SceneController(string str) {
		if (str == "exit") {
			SceneManager.LoadScene ("levelSelection");
		} else if(str == "levelSelection" || str == "levelSelection2" || str == "menu")
		{
			SceneManager.LoadScene(str);
		} else {
			if(PlayerPrefs.GetInt("canLaunch" + str) == 1)
			{
				SceneManager.LoadScene(str);
			}
		}
	}
	public void LoadNextScene(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}
	public void ReloadLvl() {
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
	}
	public void ExitGame(){
		Application.Quit ();
	}
	public void Link(string link){
		if(link=="KindOfStudio"){
		Application.OpenURL ("http://KindOfStudio.pl/");
		}
		else
		Application.OpenURL ("https://web.facebook.com/KindOfStudio/");
	
	}
	public void Donate_Click()
	{
		string url = "";

		string business     = "lukasz.kot1282@gmail.com";  // your paypal email
		string description  = "Wspieraj%20inne%20projekty!";            // '%20' represents a space. remember HTML!
		string country      = "PL";                  // AU, US, etc.
		string currency     = "PLN";                 // AUD, USD, etc.

		url += "https://www.paypal.com/cgi-bin/webscr" +
			"?cmd=" + "_donations" +
			"&business=" + business +
			"&lc=" + country +
			"&item_name=" + description +
			"&currency_code=" + currency +
			"&bn=" + "PP%2dDonationsBF";

		Application.OpenURL (url);
	}
}
