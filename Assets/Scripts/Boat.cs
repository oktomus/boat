using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour {

	private float velocity = 0.8F;
	private float lastY = -100f;
	private bool firstRun = true;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		

	}

	public void Move(Waver w){		
		transform.position = new Vector3 (
			transform.position.x + (velocity * Time.deltaTime),
				w.Height (transform.position.x, transform.position.z),
				transform.position.z
			);
		if (firstRun) {
			firstRun = false;
			lastY = transform.position.y;
			return;
		}
		float diffY = transform.position.y - lastY;

		velocity += diffY * -20 * Time.deltaTime;
		transform.rotation = new Quaternion (0, 0, 
			transform.rotation.z + (diffY * 10 * Time.deltaTime),
			 1);

		lastY = transform.position.y;
	}
}
