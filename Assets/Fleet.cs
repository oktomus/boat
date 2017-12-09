using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fleet : MonoBehaviour {

	public GameObject boat;


	public List<GameObject> boats;
	public Waver waver;


	void Start () {
		boats = new List<GameObject> ();
		boats.Add(Instantiate(boat, new Vector3(0, 0), new Quaternion()));	
	}
	
	void Update () {

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

	}
}
