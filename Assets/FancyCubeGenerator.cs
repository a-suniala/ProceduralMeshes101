using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshFilter))]
[ExecuteInEditMode]
public class FancyCubeGenerator : MonoBehaviour {

	void Start () {
		// This code leads to faulty calculation of normals for a flat surface object
		// It's only here as an example

		Mesh mesh = new Mesh();

		Vector3[] vertices = {
			new Vector3(-0.5f,-0.5f,-0.5f),//A 0
			new Vector3(-0.5f, 0.5f,-0.5f),//B 1
			new Vector3( 0.5f, 0.5f,-0.5f),//C 2
			new Vector3( 0.5f,-0.5f,-0.5f),//D 3
			new Vector3(-0.5f,-0.5f, 0.5f),//E 4
			new Vector3(-0.5f, 0.5f, 0.5f),//F 5
			new Vector3( 0.5f, 0.5f, 0.5f),//G 6
			new Vector3( 0.5f,-0.5f, 0.5f),//H 7
		};

		int[] triangles = {
			0,1,2, 0,2,3, // Front
			4,5,1, 4,1,0, // Left
			3,2,6, 3,6,7, // Right
			4,0,3, 4,3,7, // Down
			1,5,6, 1,6,2, // Up
			7,6,5, 7,5,4  // Back
		};

		mesh.vertices = vertices;
		mesh.triangles = triangles;
		mesh.RecalculateNormals();
		mesh.RecalculateBounds();

		MeshFilter mf = GetComponent<MeshFilter>();
		mf.sharedMesh = mesh;

	}
}
