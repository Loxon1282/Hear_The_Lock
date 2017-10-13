using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeRotate1 : MonoBehaviour {
    public Camera camera;
    Vector3 safePos = new Vector3();
    Vector3 mousePos = new Vector3();
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



}
}
