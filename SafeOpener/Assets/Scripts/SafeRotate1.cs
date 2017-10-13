using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeRotate1 : MonoBehaviour {

	void OnMouseDrag(){
<<<<<<< HEAD
		float rotX = Input.GetAxis ("Mouse X") * 20 * Mathf.Deg2Rad;
		float rotY = Input.GetAxis ("Mouse Y") * 20 * Mathf.Deg2Rad;
		Vector2 pos = new Vector2 (transform.position.x, transform.position.y);
		Vector2 mousePos = Input.mousePosition;

=======
		//float rotX = Input.GetAxis ("Mouse X") * 20 * Mathf.Deg2Rad;
		//float rotY = Input.GetAxis ("Mouse Y") * 20 * Mathf.Deg2Rad;
        //Debug.Log(rotX + " " + rotY);

		Quaternion rotation = Quaternion.Euler (0, 0, transform.position.z - Input.mousePosition.z);
		transform.rotation = rotation;
>>>>>>> a1aa32ca4ee11076dd447d554ed7afd62f630aae
	}
    private void OnMouseOver()
    {
        float rotX = Input.mousePosition.x;
        float rotY = Input.mousePosition.y;
        Debug.Log(rotX + " " + rotY);
    }
}
