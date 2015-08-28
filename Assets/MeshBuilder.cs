using UnityEngine;
using System.Collections;

public class MeshBuilder : MonoBehaviour {

	public static Mesh Combine(Mesh A, Mesh B) {

		Mesh combined = new Mesh();

		combined.vertices = CombineVertices (A, B);
		combined.triangles = CombineTriangles (A, B);
		combined.RecalculateBounds();
		combined.RecalculateNormals();

		return combined;
	}

	static Vector3[] CombineVertices (Mesh A, Mesh B) {

		Vector3[] vertices = new Vector3[A.vertices.Length + B.vertices.Length];

		A.vertices.CopyTo (vertices, 0);
		B.vertices.CopyTo (vertices, A.vertices.Length);

		return vertices;
	}

	static int[] CombineTriangles (Mesh A, Mesh B) {

		int[] triangles = new int[A.triangles.Length + B.triangles.Length];
		int trianglesOffset = A.triangles.Length;
		int verticesOffset = A.vertices.Length;

		A.triangles.CopyTo (triangles, 0);
		for (int i = 0; i < B.triangles.Length; i++) {
			triangles [i + trianglesOffset] = B.triangles [i] + verticesOffset;
		}

		return triangles;
	}


	public static Mesh Offset (Mesh A, Vector3 offset) {
		Mesh result = new Mesh();
		Vector3[] vertices = new Vector3[A.vertices.Length];

		for (int i = 0; i < A.vertices.Length; i++) {
			vertices[i] = A.vertices[i] + offset;
		}

		result.vertices = vertices;
		result.triangles = A.triangles;
		result.uv = A.uv;
		result.RecalculateBounds();
		result.normals = A.normals;

		return result;
	}
}
