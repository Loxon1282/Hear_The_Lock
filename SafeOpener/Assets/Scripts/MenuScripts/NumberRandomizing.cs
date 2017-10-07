using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberRandomizing : MonoBehaviour {

	string startValue;
	int rand;
	float time,time2;
	// Use this for initialization
	void Start () {
		startValue = gameObject.GetComponent<Text> ().text;
		StartCoroutine ("RandAnim");
		time = 0.005f;
		time2 = Random.Range (0.003f, 0.006f);
	}

	IEnumerator RandAnim(){
		for (int i = 0; i < 20; i++) {
			rand = Random.Range (0, 9);
			gameObject.GetComponent<Text> ().text= rand.ToString();
			yield return new WaitForSeconds (time);
			gameObject.GetComponent<Text> ().text = startValue;
			time = time + time2;

		}

		gameObject.GetComponent<Text> ().text = startValue;
	}
}
