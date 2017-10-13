using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeRotate : MonoBehaviour {

    float currentDirection;
    int direction = 1;
    float distance;
	
    private void Awake()
    {
        currentDirection = 0f;
    }

    void Update()
    {
        if(!((currentDirection - 1f) < this.transform.eulerAngles.z && (currentDirection + 1f) > this.transform.eulerAngles.z))
        {
            float currentDistance = Mathf.Abs(this.transform.rotation.eulerAngles.z - currentDirection) * 1.5f;
            this.transform.Rotate(new Vector3(0, 0, direction) * Time.deltaTime * currentDistance);
            Debug.Log(distance);
        }
    }

    private void OnMouseDown()
    {
        Vector2 zeroMouse = new Vector2(Input.mousePosition.x - Screen.width / 2, Input.mousePosition.y - Screen.height / 2 + 40);
        float angle = Vector2.SignedAngle(Vector2.up, zeroMouse);
        currentDirection = (angle < 0) ? 360-Mathf.Abs(angle) : angle;
        //Debug.Log(currentDirection);
        if(currentDirection < this.transform.rotation.eulerAngles.z)
        {
            distance = Mathf.Abs(this.transform.rotation.eulerAngles.z - currentDirection) + 360;
        } else
        {
            distance = Mathf.Abs(this.transform.rotation.eulerAngles.z - currentDirection);
        }
        if(distance > 200)
        {
           direction = -1;
        } else
        {
            direction = 1;
        }
    }

}
