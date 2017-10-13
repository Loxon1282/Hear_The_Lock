using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeRotate1 : MonoBehaviour {
    public Camera camera;
    Vector3 safePos = new Vector3();
    Vector3 mousePos = new Vector3();

<<<<<<< HEAD
    private void Awake()
    {
        safePos = gameObject.transform.position;
        
    }

    private void OnMouseOver()
    {
        mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
        mousePos = mousePos - safePos;
        //Debug.Log("X: " + mousePos.x + " " + " Y: " + mousePos.y);
        if (mousePos.x > 0 && mousePos.y > 0)
        {
            float tangent = mousePos.y / mousePos.x;
            //Debug.Log(Mathf.Tan(and * Mathf.Deg2Rad));
            //Debug.Log(and);

        }
        if (mousePos.x < 0 && mousePos.y > 0)
        {
            Debug.Log("2 ćw");
        }
        if (mousePos.x < 0 && mousePos.y < 0)
        {
            Debug.Log("3 ćw");
        }
        if (mousePos.x > 0 && mousePos.y < 0)
        {
            Debug.Log("4 ćw");
        }
=======


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

>>>>>>> a6b1a21b1243d4ac3a00cc94772b61fad839f6f3
    }
}
