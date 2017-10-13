using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeRotate1 : MonoBehaviour {

	void OnMouseDrag(){
		float rotX = Input.GetAxis ("Mouse X") * 20 * Mathf.Deg2Rad;
		float rotY = Input.GetAxis ("Mouse Y") * 20 * Mathf.Deg2Rad;

		Quaternion rotation = Quaternion.Euler (transform.position.x - Input.mousePosition.x, transform.position.y - Input.mousePosition.y, transform.position.z - Input.mousePosition.z);
		transform.rotation = rotation;
	}
}
