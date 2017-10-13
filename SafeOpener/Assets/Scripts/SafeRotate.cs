using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeRotate : MonoBehaviour {

	void Update(){
		Vector2 zeroMouse = new Vector2 (Input.mousePosition.x - Screen.width / 2, Input.mousePosition.y - Screen.height/2+40);
		Vector2 center = new Vector2 (transform.position.x,transform.position.y);
		float angle = Vector2.SignedAngle(center, zeroMouse);
		Quaternion rotation = Quaternion.Euler (0, 0, angle);
		transform.rotation = rotation;

		Debug.Log (angle);
	//	Debug.Log ("X:"+Input.mousePosition.x+" Y: "+Input.mousePosition.y);
	//	Debug.Log("X2:"+(Input.mousePosition.x-Screen.width/2)+" Y2: "+(Input.mousePosition.y-Screen.height/2));
		}


}
