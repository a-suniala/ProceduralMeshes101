using UnityEngine;
using System.Collections;

[RequireComponent (typeof(MeshFilter))]
[ExecuteInEditMode]
public class QuadGenerator : MonoBehaviour {

	void Update () {

		// Create and define vertices
		Vector3[] vertices = new Vector3[4];
		vertices[0] = new Vector3(0,0,0);
		vertices[1] = new Vector3(0,1,0);
		vertices[2] = new Vector3(1,1,0);
		vertices[3] = new Vector3(1,0,0);

		// Create and define triangles out of vertices
		int[] triangles = new int[6];
		triangles[0] = 0;
		triangles[1] = 1;
		triangles[2] = 2;
		triangles[3] = 0;
		triangles[4] = 2;
		triangles[5] = 3;

		// Define UV map
		Vector2[] uvs = {
			new Vector2(1,1),
			new Vector2(1,0),
			new Vector2(0,0),
			new Vector2(0,1)
		};

		// Define normals
		Vector3[] normals = new Vector3[4];
		// Init normals
		for (int i = 0; i < vertices.Length; i++) {
			normals[i] = new Vector3(0,0,0);
		}
		// Calculate normals
		for (int i = 0; i < triangles.Length; i += 3) {
			int indexOfA = triangles[i];
			Vector3 vectA = vertices[indexOfA];
			Vector3 vectB = vertices[triangles[i + 1]];
			Vector3 vectC = vertices[triangles[i + 2]];
			Vector3 normal = Vector3.Cross(vectB - vectA, vectC - vectA);
			normals[indexOfA] += normal;
			normals[triangles[i+1]] += normal;
			normals[triangles[i+2]] += normal;
		}
		// Normalize normals
		for (int i = 0; i < vertices.Length; i++) {
			normals[i] = normals[i].normalized;
		}


		Mesh mesh = new Mesh();
		mesh.vertices = vertices;
		mesh.uv = uvs;
		mesh.normals = normals;
		mesh.triangles = triangles;
		mesh.RecalculateBounds();

		MeshFilter mf = GetComponent<MeshFilter>();
		mf.mesh = mesh;
	}


}
