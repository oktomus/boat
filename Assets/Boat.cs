using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour {

	private Waver waver;

	// Use this for initialization
	void Start () {
		waver = GetComponent<Waver> ();
	}
	
	// Update is called once per frame
	void Update () {
		//transform.position.y = waver.height (transform.position.x, transform.position.z);

		transform.position = new Vector3 (
			transform.position.x,
			waver.Height (transform.position.x, transform.position.z),
			transform.position.z
		);

	}
}
