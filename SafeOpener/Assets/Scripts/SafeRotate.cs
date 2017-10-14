using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeRotate : MonoBehaviour {

    float currentDirection;
    int direction = 1;
    float distance;
    public ButtonStates buttonStates = new ButtonStates();
	
    private void Awake()
    {
        currentDirection = this.transform.eulerAngles.z;
    }

    public void Update()
    {
        if (GameObject.Find("GameplayController").GetComponent<GameplayController>().startingTimer <= 0)
        {

            //this.transform.rotation = Quaternion.Euler(0, 0, currentDirection);

            if (!(this.transform.eulerAngles.z >= (currentDirection - 1) && this.transform.eulerAngles.z <= (currentDirection + 1)))
            {
                float currentDistanceA, currentDistanceB, currentSpeed;
                currentDistanceA = Mathf.Abs(currentDirection - this.transform.eulerAngles.z);
                currentDistanceB = 360 - currentDistanceA;
                //Debug.Log(currentDirection);
                //Debug.Log("A: " + currentDistanceA);
                //Debug.Log("B: " + currentDistanceB);
                currentSpeed = (currentDistanceA >= currentDistanceB) ? currentDistanceB : currentDistanceA;
                this.transform.Rotate(new Vector3(0, 0, direction * currentSpeed * 15f * Time.fixedDeltaTime));
            }
            if (buttonStates.leftArrow)
            {
                currentDirection = currentDirection + 5f * Time.fixedDeltaTime;
                CalculateDistance();
            }
            if (buttonStates.rightArrow)
            {
                currentDirection = currentDirection - 5f * Time.fixedDeltaTime;
                CalculateDistance();
            }
        }
    }

    public void CalculatePositions()
    {
        Vector2 zeroMouse = new Vector2(Input.mousePosition.x - Screen.width / 2, Input.mousePosition.y - Screen.height / 2 + 40);
        float angle = Vector2.SignedAngle(Vector2.up, zeroMouse);
        currentDirection = (angle < 0) ? Mathf.Round(360-Mathf.Abs(angle)) : Mathf.Round(angle);
        CalculateDistance();
    }
    public void CalculateDistance()
    {
        distance = currentDirection - this.transform.eulerAngles.z;
        if (Mathf.Abs(distance) < 180 && Mathf.Sign(distance) == -1)
        {
            direction = -1;
        }
        else if (Mathf.Abs(distance) > 180 && Mathf.Sign(distance) == 1)
        {
            direction = -1;
        }
        else
        {
            direction = 1;
        }
    }
    public void RotateLeft()
    {
        buttonStates.leftArrow = true;
    }
    public void RotateRight()
    {
        buttonStates.rightArrow = true;
    }
    public void ResetButtons()
    {
        buttonStates.Reset();
    }
    public struct ButtonStates {
        public bool leftArrow { get; set; }
        public bool rightArrow { get; set; }
        public void Reset()
        {
            this.leftArrow = false;
            this.rightArrow = false;
        }
    }
}
