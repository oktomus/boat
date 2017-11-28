using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fleet : MonoBehaviour {

	public GameObject boat;

	private List<GameObject> boats;

	void Start () {
		boats = new List<GameObject> ();
		
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
		if (Physics.Raycast(ray, out hit))
			boats.Add(Instantiate(boat, hit.point, new Quaternion()));

	}
}
