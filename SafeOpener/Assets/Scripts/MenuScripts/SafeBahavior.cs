using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeBahavior : MonoBehaviour {

	float speed;
	int positionx;
	// Use this for initialization
	void Start () {
		positionx = Random.Range (-4, 4);
		speed = Random.Range (-4, 4);
		transform.position = new Vector3 (positionx, 10);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (0, 0, speed);
		transform.position =transform.position+  Vector3.down/18;
		if (transform.position.y < -6)
			Destroy (gameObject);
	}
		
}
