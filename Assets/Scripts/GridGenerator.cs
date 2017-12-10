using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer)), RequireComponent(typeof(MeshCollider))]
public class GridGenerator : MonoBehaviour {

	public int rows;
	public int columns;
	public float width;
	public float height;
	public bool debugVertices = false;
	public bool regenerate = false;

	private float gapX, gapZ, toCenterX, toCenterZ;

	private Vector3[] vertices;
	private Vector2[] uvs;
	private int [] triangles;
	private Mesh mesh;
	public Waver waver;

	void Start () {
		
	}

	private void Awake(){
		Generate();
	}

	private void AddTriangle(Vector3 a, Vector3 b, Vector3 c, int i){
		vertices [i] = a;
		vertices [i + 1] = b;
		vertices [i + 2] = c;

		triangles [i] = i;
		triangles [i + 1] = i + 1;
		triangles [i + 2] = i + 2;

		uvs [i] = new Vector2 (a.x / columns, a.z / rows);
		uvs [i + 1] = new Vector2 (b.x / columns, b.z / rows);
		uvs [i + 2] = new Vector2 (c.x / columns, c.z / rows);	
	}

	private void AddQuad(float x, float z, int i){
		Vector3 bottomLeft = new Vector3 (
			x * gapX + toCenterX, 			0, 	z * gapZ + toCenterZ);
		Vector3 bottomRight = new Vector3 (
			x * gapX + toCenterX + gapX, 	0, 	z * gapZ + toCenterZ);
		Vector3 topRight = new Vector3 (
			x * gapX + toCenterX + gapX, 	0, 	z * gapZ + toCenterZ + gapZ);
		Vector3 topLeft = new Vector3 (
			x * gapX + toCenterX, 			0, 	z * gapZ + toCenterZ + gapZ);

		AddTriangle (bottomLeft, topLeft, topRight, i);
		AddTriangle (bottomLeft, topRight, bottomRight, i + 3);
	}

	private void Generate(){
		regenerate = false;
		GetComponent<MeshFilter> ().mesh = mesh = new Mesh();
		mesh.name = "Flat procedural grid";

		int ptAmount = rows * columns * 6;
		vertices = new Vector3[ptAmount] ;
		uvs = new Vector2[ptAmount];
		triangles = new int[ptAmount];

		gapX = width / columns;
		gapZ = height / rows;

		toCenterX = -width / 2f;
		toCenterZ = -height / 2f;

		//  3     2
		//  O-----O
		//  |\    |
		//  | \   |
		//  |  \  |
		//  |   \ |
		//  O----\O
		//  0     1

		float x = 0f, z = 0f;
		for (int i = 0, ti = 0; z < rows; z += 1f) {
			for (x = 0f; x < columns; x += 1f, i += 4, ti+=6) {
				AddQuad (x, z, ti);
			}		
		}

		mesh.vertices = vertices;
		mesh.uv = uvs;
		mesh.triangles = triangles;
		GetComponent<MeshCollider> ().sharedMesh = mesh;
				
	}

	void Update () {
		if(regenerate) Generate ();
		for (int i = 0; i < vertices.Length; ++i) {
			vertices [i].y = waver.Height (vertices [i].x, vertices [i].z);
		}
		GetComponent<MeshCollider> ().sharedMesh = mesh;
		mesh.vertices = vertices;
		mesh.RecalculateNormals ();
		mesh.RecalculateTangents ();
		mesh.RecalculateBounds ();	

	}

	private void OnDrawGizmos () {
		if (debugVertices && vertices != null) {
			Gizmos.color = Color.black;
			for (int i = 0; i < vertices.Length; i++) {
				Gizmos.DrawSphere(vertices[i], 0.1f);
			}
		}

	}

}
