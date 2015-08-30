using UnityEngine;
using System.Collections;

[RequireComponent (typeof(MeshFilter))]
public class ShowMeshVertices : MonoBehaviour {

	void OnDrawGizmos () {
		MeshFilter mf = GetComponent<MeshFilter>();
		Mesh mesh = mf.sharedMesh;
		Vector3[] vertices = mesh.vertices;

		Gizmos.matrix = Matrix4x4.TRS (
			transform.position,
			transform.rotation,
			transform.lossyScale
		);

		for (int i = 0; i < vertices.Length; i++) {
			Gizmos.DrawSphere(vertices[i], 0.05f);
		}


		// Show normals
		Vector3[] normals = mesh.normals;
		Vector3 vertex = new Vector3();
		Vector3 normal = new Vector3();

		for (int i = 0; i < normals.Length; i++) {
			normal = normals[i];
			vertex = mesh.vertices[i];
			normal = normal + vertex;

			Gizmos.DrawLine (vertex, normal);
		}
	}
}
