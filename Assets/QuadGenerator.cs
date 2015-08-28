using UnityEngine;
using System.Collections;

[RequireComponent (typeof(MeshFilter))]
[ExecuteInEditMode]
public class QuadGenerator : MonoBehaviour {

	void Update () {
		MeshFilter mf = GetComponent<MeshFilter>();
		mf.mesh = MakeQuad(
			new Vector3 (0,1,0),
			new Vector3 (1,0,0)
		);
	}

	Mesh MakeQuad (Vector3 vectA, Vector3 vectB)
	{
		// Create and define vertices
		Vector3[] vertices = new Vector3[4];
		vertices [0] = new Vector3 (0, 0, 0);
		vertices [1] = vectA;
		vertices [2] = vectA + vectB;
		vertices [3] = vectB;

		// Create and define triangles out of vertices
		int[] triangles = new int[6];
		triangles [0] = 0;
		triangles [1] = 1;
		triangles [2] = 2;
		triangles [3] = 0;
		triangles [4] = 2;
		triangles [5] = 3;

		// Define UV map
		Vector2[] uvs =  {
			new Vector2 (1, 1),
			new Vector2 (1, 0),
			new Vector2 (0, 0),
			new Vector2 (0, 1)
		};

		Mesh mesh = new Mesh ();
		mesh.vertices = vertices;
		mesh.uv = uvs;
		mesh.triangles = triangles;
		mesh.normals = CalculateNormals (mesh);
		mesh.RecalculateBounds ();

		return mesh;
	}

	Vector3[] CalculateNormals (Mesh mesh) {
		Vector3[] vertices = mesh.vertices;
		int[] triangles = mesh.triangles;
		Vector3[] normals = new Vector3[4];

		// Init 
		for (int i = 0; i < vertices.Length; i++) {
			normals [i] = new Vector3 (0, 0, 0);
		}

		// Calculate
		for (int i = 0; i < triangles.Length; i += 3) {
			int indexOfA = triangles [i];
			Vector3 vectA = vertices [indexOfA];
			Vector3 vectB = vertices [triangles [i + 1]];
			Vector3 vectC = vertices [triangles [i + 2]];
			Vector3 normal = Vector3.Cross (vectB - vectA, vectC - vectA);
			normals [indexOfA] += normal;
			normals [triangles [i + 1]] += normal;
			normals [triangles [i + 2]] += normal;
		}

		// Normalize
		for (int i = 0; i < vertices.Length; i++) {
			normals [i] = normals [i].normalized;
		}

		return normals;
	}


}
