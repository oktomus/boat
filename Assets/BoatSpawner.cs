using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Fleet))]
public class BoatSpawner : MonoBehaviour {

	public GameObject indicator;
	public float minDistance = 1.2f;
	public GameObject boat;
	public Waver waver;
	public int rayLayerMask;

	private Vector3 spawnPosition;
	private bool spawn = false;
	private Fleet fleet;
	private SpriteRenderer spRender;
	private int layerMask;

	// Use this for initialization
	void Start () {
		//indicator.getC
		fleet = GetComponent<Fleet>();
		spRender = indicator.GetComponent<SpriteRenderer> ();
		layerMask = 1 << rayLayerMask;
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit, layerMask)) {			
			spRender.enabled = true;
			spawn = true;
			// Check if the point isnt near other boats
			foreach (GameObject b in fleet.boats) {
				if (Vector3.Distance (b.transform.position, hit.point) <= minDistance) {
					spawn = false;
					break;
				}
			}
			// Add it

			spawnPosition = hit.point;
//			fleet.boats.Add(Instantiate(boat, hit.point, new Quaternion()));
			if (spawn) {
				spRender.color = new Color (1, 1, 1);
			} else {
				spRender.color = new Color (1, 0, 0);
			}
			indicator.transform.position = new Vector3 (
				spawnPosition.x,
				waver.Height(spawnPosition.x, spawnPosition.z) + 0.05f,
				spawnPosition.z);

			if (spawn && Input.GetMouseButtonUp (0)) {
				GameObject b = Instantiate (boat, spawnPosition, boat.transform.rotation);
				fleet.boats.Add (b);
			}
		} else {
			spRender.enabled = false;
		}

	}
}
