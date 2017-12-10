using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Renderer), typeof(MeshFilter), typeof(MeshRenderer))]
public class WaveDebugger : MonoBehaviour {
		
	private Texture2D noiseTex;
	private Color[] pix;
	private Renderer rend;
	public Waver waver;
	public GridGenerator grid;
	public MeshFilter gridMesh;
	public int resolutionFactor = 10;

	void Start() {
		//gridMesh.mesh;
		rend = GetComponent<Renderer>();
		noiseTex = new Texture2D(
			(int)(grid.width * resolutionFactor), 
			(int)(grid.height * resolutionFactor));
		pix = new Color[noiseTex.width * noiseTex.height];
		rend.material.mainTexture = noiseTex;
	}
			
	void CalcNoise() {
		int y = 0;
		while (y < noiseTex.height) {
			int x = 0;
			while (x < noiseTex.width) {
					/*
				float xCoord = xOrg + x / noiseTex.width * scale;
				float yCoord = yOrg + y / noiseTex.height * scale;
				float sample = Mathf.PerlinNoise(xCoord, yCoord);
				pix[
					(int)(y * noiseTex.width + x)
				] = 
					new Color(sample, sample, sample);
				*/
				float val = waver.Height (
					(float) x / (float) resolutionFactor, 
					(float) y / (float) resolutionFactor);
				pix [y * noiseTex.width + x] = new Color (val, val, val);
				x++;
			}
			y++;
		}
		noiseTex.SetPixels(pix);
		noiseTex.Apply();
	}
	void Update() {
		CalcNoise();
	}
}