using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeRotate1 : MonoBehaviour {

	void OnMouseDrag(){
		float rotX = Input.GetAxis ("Mouse X") * 10 * Mathf.Deg2Rad;
		float rotY = Input.GetAxis ("Mouse Y") * 10 * Mathf.Deg2Rad;

		transform.RotateAround (Vector3.back, rotX);
	}
}
