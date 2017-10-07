using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour {
	public GameObject panelLeft, panelRight;
	void Start() {
		if (SceneManager.GetActiveScene ().name != "menu" && SceneManager.GetActiveScene ().name != "levelSelection") {
			panelLeft.GetComponent<RectTransform> ().sizeDelta = new Vector2 ( Screen.width /2 , Screen.height/3);
			panelRight.GetComponent<RectTransform> ().sizeDelta = new Vector2 ( Screen.width /2 , Screen.height/3);
		}
	}
	public void SceneController(string str) {
		if (str == "exit") {
			SceneManager.LoadScene ("levelSelection");
		} else {
			SceneManager.LoadScene (str);
		}
	}
	public void LoadNextScene(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}
	public void ReloadLvl() {
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
	}
}
