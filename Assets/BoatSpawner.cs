using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Fleet))]
public class BoatSpawner : MonoBehaviour {

	public GameObject indicator;
	public float minDistance = 1.2f;
	public GameObject boat;
	public GameObject grid;
	public Waver waver;

	private Vector3 spawnPosition;
	private bool spawn = false;
	private Fleet fleet;
	private Renderer spRender;
	private Collider gridCollider;
	private Color matColor;

	// Use this for initialization
	void Start () {
		//indicator.getC
		fleet = GetComponent<Fleet>();
		spRender = indicator.GetComponent<Renderer> ();
		gridCollider = grid.GetComponent<Collider> ();
		matColor = new Color (1, 1, 1, 1);
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {		
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (gridCollider.Raycast (ray, out hit, 100.0F)) {			
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
			//spawnPosition.y = waver.Height (spawnPosition.x, spawnPosition.z);
//			fleet.boats.Add(Instantiate(boat, hit.point, new Quaternion()));
			if (spawn) {
				matColor.r = matColor.g = matColor.b = 1;
			} else {
				matColor.g = matColor.b = 0;
				matColor.r = 1;
			}
			indicator.transform.position = spawnPosition;

			if (spawn && Input.GetMouseButtonUp (0)) {
				fleet.AddBoat (spawnPosition);
			}
		} else {
			spRender.enabled = false;
		}
		spRender.material.SetColor ("_Color", matColor);

	}
}
