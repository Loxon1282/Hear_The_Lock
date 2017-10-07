using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockSmoothRotate : MonoBehaviour {

	bool start=false;
	float x;
	float y=-1;
	public GameObject pstrykObj,infoPanel;
	public GameObject headPhones;
	AudioSource pstryk;
	// Use this for initialization
	void Start () {
		pstryk = pstrykObj.gameObject.GetComponent<AudioSource> ();
		start = false;
		StartCoroutine ("xd");
		StartCoroutine ("startDeley");
		x = 0;
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (x);
		if (start) {
			transform.Rotate (0, 0, x);

			x = Mathf.PingPong (Time.time,1) * y;

		}
	}
	IEnumerator xd(){
		yield return new WaitForSeconds (3.0f);
		InvokeRepeating ("fak", 1, 2);
		InvokeRepeating ("pstrykanie", 1, 2);
		StartCoroutine ("headphonesAnim");
	}
	void fak(){
		y = -y;
	}
	void pstrykanie(){
		StartCoroutine ("pstrykMeth");
	}
	IEnumerator startDeley(){
		yield return new WaitForSeconds (3.0f);
		start = true;
	}
	IEnumerator headphonesAnim(){
		headPhones.gameObject.SetActive (true);
		yield return new WaitForSeconds (0.1f);
		headPhones.gameObject.SetActive (false);
		yield return new WaitForSeconds (0.3f);
		headPhones.gameObject.SetActive (true);
		yield return new WaitForSeconds (0.1f);
		headPhones.gameObject.SetActive (false);
		yield return new WaitForSeconds (0.6f);
		headPhones.gameObject.SetActive (true);
	}
	IEnumerator pstrykMeth(){
		pstryk.Play ();
		yield return new WaitForSeconds (0.80f);
		pstryk.Play ();
		yield return new WaitForSeconds (0.1f);
		pstryk.Play ();
		yield return new WaitForSeconds (0.1f);
		pstryk.Play ();


	}
	public void infoActive(){


		if (infoPanel.gameObject.activeSelf)
			infoPanel.SetActive (false);
		else
			infoPanel.SetActive (true);
	}
}
