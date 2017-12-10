using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fleet : MonoBehaviour {

	public GameObject boat;


	public List<GameObject> boats;
	public Waver waver;
	public float initialXVelocity = 0.02F;


	void Start () {
		boats = new List<GameObject> ();
		AddBoat (new Vector3 (0, 0));
	}

	public void AddBoat(Vector3 pos){
		GameObject b = Instantiate (boat, pos, new Quaternion ());
		b.AddComponent<Boat>();
		boats.Add(b);	
		
	}
	
	void FixedUpdate () {
		for(int i = boats.Count - 1; i >= 0; --i)
		{
			GameObject b = boats [i];
			b.GetComponent<Boat> ().Move (waver);
			if (b.transform.position.x > 5) {
				boats.RemoveAt (i);
				Destroy (b);
			}
		}
	}
		
}
