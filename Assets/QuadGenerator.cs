using UnityEngine;
using System.Collections;

[RequireComponent (typeof(MeshFilter))]
public class QuadGenerator : MonoBehaviour {

	void Start () {
		Vector3[] vertices = new Vector3[4];

		vertices[0] = new Vector3(0,0,0);
		vertices[1] = new Vector3(0,1,0);
		vertices[2] = new Vector3(1,1,0);
		vertices[3] = new Vector3(1,0,0);

		int[] triangles = new int[6];
		triangles[0] = 0;
		triangles[1] = 1;
		triangles[2] = 2;
		triangles[3] = 0;
		triangles[4] = 2;
		triangles[5] = 3;

		Mesh mesh = new Mesh();
		mesh.vertices = vertices;
		mesh.triangles = triangles;
		mesh.RecalculateBounds();

		MeshFilter mf = GetComponent<MeshFilter>();
		mf.mesh = mesh;
	}

}
