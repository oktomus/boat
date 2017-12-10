using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waver : MonoBehaviour {

	public float lowDeepness = 0.2f;
	public float lowScale = 9f;
	public float lowWidth;
	public float lowHeight;

	public float highDeepness = 1f;
	public float highScale = 9f;
	public float highWidth;
	public float highHeight;

	public float xOrigin = 0f;
	public float zOrigin = 0f;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		xOrigin += 0.5f * Time.deltaTime;
	}

	public float Low(float x, float z){
		// Noise
		float res = 0;

		float xCoord = xOrigin + x / lowWidth * lowScale;
		float zCoord = zOrigin + z / lowHeight * lowScale;

		res += Mathf.PerlinNoise (xCoord, zCoord) * lowDeepness;
		return res;

		//return Mathf.Sin (Time.frameCount / 50f + x / 4f + z / 2f) * deepness * 1.5f +
		//Mathf.Sin (Time.frameCount / 50f + x * 10 + z * 10) * deepness;

	}

	public float High(float x, float z){
		// Noise
		float res = 0;

		float xCoord = xOrigin + x / highWidth * highScale;
		float zCoord = zOrigin + z / highHeight * highScale;

		res += Mathf.PerlinNoise (xCoord, zCoord) * highDeepness;
		return res;

		//return Mathf.Sin (Time.frameCount / 50f + x / 4f + z / 2f) * deepness * 1.5f +
		//Mathf.Sin (Time.frameCount / 50f + x * 10 + z * 10) * deepness;

	}

	public float Height(float x, float z){

		// Pass 1 
		return Low(x, z) + High(x, z);
	}
}
