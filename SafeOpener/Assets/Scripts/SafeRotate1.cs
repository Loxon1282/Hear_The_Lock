using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeRotate1 : MonoBehaviour {
    public Camera camera;

<<<<<<< HEAD
    private void Awake()
    {
        
    }

    void OnMouseDrag(){
=======
	void OnMouseDrag(){
<<<<<<< HEAD
		float rotX = Input.GetAxis ("Mouse X") * 20 * Mathf.Deg2Rad;
		float rotY = Input.GetAxis ("Mouse Y") * 20 * Mathf.Deg2Rad;
		Vector2 pos = new Vector2 (transform.position.x, transform.position.y);
		Vector2 mousePos = Input.mousePosition;

=======
>>>>>>> 864fc57eebba7d37f40a0196ba38c481e2d76849
		//float rotX = Input.GetAxis ("Mouse X") * 20 * Mathf.Deg2Rad;
		//float rotY = Input.GetAxis ("Mouse Y") * 20 * Mathf.Deg2Rad;
        //Debug.Log(rotX + " " + rotY);

		Quaternion rotation = Quaternion.Euler (0, 0, transform.position.z - Input.mousePosition.z);
		transform.rotation = rotation;
>>>>>>> a1aa32ca4ee11076dd447d554ed7afd62f630aae
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
