using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextMenuAnim : MonoBehaviour {
 

	Text title;
	int liczba,a=111111111,b=999999999;
	// Use this for initialization
	void Start () {
		title = gameObject.GetComponent<Text> ();
		StartCoroutine ("TitleAnim");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator TitleAnim(){
		for (int i = 0; i < 140; i++) {
			if (i % 10==0&&i!=0) {
				a = a / 10;
				b = b / 10;
			}
			liczba = Random.Range (a, b);
			//title.text =liczba.ToString();
			yield return new WaitForSeconds (0.01f);

			if (i < 11) {
				title.text = liczba.ToString ();
			} else if (i > 10 && i < 20) {
				title.text = "H" + liczba.ToString ();
			} else if (i > 20 && i < 30) {
				title.text = "HE" + liczba.ToString ();
			} else if (i > 30 && i < 40) {
				title.text = "HEA" + liczba.ToString ();
			} else if (i > 40 && i < 50) {
				title.text = "HEAR" + liczba.ToString ();
			} else if (i > 50 && i < 60) {
				title.text = "HEAR " + liczba.ToString ();
			} else if (i > 60 && i < 70) {
				title.text = "HEAR T" + liczba.ToString ();
			} else if (i > 70 && i < 80) {
				title.text = "HEAR TH" + liczba.ToString ();
			} else if (i > 80 && i < 90) {
				title.text = "HEAR THE" + liczba.ToString ();
			} else if (i > 90 && i < 100) {
				title.text = "HEAR THE " + liczba.ToString ();
			} else if (i > 100 && i < 110) {
				title.text = "HEAR THE L" + liczba.ToString ();
			} else if (i > 110 && i < 120) {
				title.text = "HEAR THE LO" + liczba.ToString ();
			} else if (i > 120 && i < 130) {
				title.text = "HEAR THE LOC" + liczba.ToString ();
			} else if(i>130){
				title.text = "HEAR THE LOCK";
			}

		}
	}
}
