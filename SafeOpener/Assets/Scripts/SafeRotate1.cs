using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeRotate1 : MonoBehaviour {

	void OnMouseDrag(){
		float rotX = Input.GetAxis ("Mouse X") * 20 * Mathf.Deg2Rad;
		float rotY = Input.GetAxis ("Mouse Y") * 20 * Mathf.Deg2Rad;
		Vector2 pos = new Vector2 (transform.position.x, transform.position.y);
		Vector2 mousePos = Input.mousePosition;

	}
}
