using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour {

	private static float initialVelocity = 0.02F;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		

	}

	public void Move(Waver w){
		transform.position = new Vector3 (
			transform.position.x + initialVelocity,
				w.Height (transform.position.x, transform.position.z),
				transform.position.z
			);
	}
}
