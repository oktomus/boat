using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fleet : MonoBehaviour {

	public GameObject boat;
	public float minDistance = 2.0f;

	private List<GameObject> boats;


	void Start () {
		boats = new List<GameObject> ();
		boats.Add(Instantiate(boat, new Vector3(0, 0), new Quaternion()));
	}
	
	void Update () {
		Waver waver = GetComponent<Waver> ();

		foreach (GameObject b in boats) {
			b.transform.position = new Vector3 (
				b.transform.position.x,
				waver.Height (b.transform.position.x, b.transform.position.z),
				b.transform.position.z
			);
		}
	}

	void OnMouseDown()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit)) {
			// Check if the point isnt near other boats
			foreach (GameObject b in boats) {
				Debug.Log ("Distance is " + Vector3.Distance (b.transform.position, hit.point));
				if (Vector3.Distance (b.transform.position, hit.point) <= minDistance)
					return;
			}
			// Add it
			boats.Add(Instantiate(boat, hit.point, new Quaternion()));

		}
			

	}
}
