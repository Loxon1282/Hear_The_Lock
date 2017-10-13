using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeRotate1 : MonoBehaviour {
    public Camera camera;

    private void Awake()
    {
        
    }

    void OnMouseDrag(){
		//float rotX = Input.GetAxis ("Mouse X") * 20 * Mathf.Deg2Rad;
		//float rotY = Input.GetAxis ("Mouse Y") * 20 * Mathf.Deg2Rad;
        //Debug.Log(rotX + " " + rotY);

		Quaternion rotation = Quaternion.Euler (0, 0, transform.position.z - Input.mousePosition.z);
		transform.rotation = rotation;
	}
    private void OnMouseOver()
    {
        // GameObject.Find("Safe").transform.LookAt(Input.mousePosition);
        //float stopnie = Mathf.Tan(Input.mousePosition.y / Input.mousePosition.x) * Mathf.Rad2Deg; ;
        float wektor = Vector2.Angle(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), camera.ScreenToWorldPoint(Input.mousePosition));
        gameObject.transform.rotation = Quaternion.Euler(0, 0, wektor);
        Debug.Log(wektor);
    }
}
