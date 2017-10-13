using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeRotate1 : MonoBehaviour {
    public Camera camera;



    private void OnMouseOver()
    {
        float rotX = Input.mousePosition.x;
        float rotY = Input.mousePosition.y;
		Debug.Log(Vector3.Angle(transform.position, Input.mousePosition));
		transform.rotation = new Quaternion (0, 0,(rotX+rotY)/2,1);

        // GameObject.Find("Safe").transform.LookAt(Input.mousePosition);
        //float stopnie = Mathf.Tan(Input.mousePosition.y / Input.mousePosition.x) * Mathf.Rad2Deg; ;
        float wektor = Vector2.Angle(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), camera.ScreenToWorldPoint(Input.mousePosition));
        gameObject.transform.rotation = Quaternion.Euler(0, 0, wektor);
        Debug.Log(wektor);

    }
}
