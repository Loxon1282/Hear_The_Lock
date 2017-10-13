using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeRotate1 : MonoBehaviour {

	void OnMouseDrag(){
		//float rotX = Input.GetAxis ("Mouse X") * 20 * Mathf.Deg2Rad;
		//float rotY = Input.GetAxis ("Mouse Y") * 20 * Mathf.Deg2Rad;
        //Debug.Log(rotX + " " + rotY);

		Quaternion rotation = Quaternion.Euler (0, 0, transform.position.z - Input.mousePosition.z);
		transform.rotation = rotation;
	}
    private void OnMouseOver()
    {
        float rotX = Input.mousePosition.x;
        float rotY = Input.mousePosition.y;
        Debug.Log(rotX + " " + rotY);
    }
}
