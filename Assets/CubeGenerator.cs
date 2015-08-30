using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshFilter))]
[ExecuteInEditMode]
public class CubeGenerator : MonoBehaviour {

	void Start () {
		MeshFilter mf = GetComponent<MeshFilter>();
		Mesh cube = new Mesh();

		// Front
		cube = MeshBuilder.Combine(cube, QuadGenerator.MakeQuad(
			new Vector3 (0,1,0),
			new Vector3 (1,0,0)
		));

		// Left
		cube = MeshBuilder.Combine(cube, QuadGenerator.MakeQuad(
			new Vector3 (0,0,1),
			new Vector3 (0,1,0)
		));

		// Down
		cube = MeshBuilder.Combine(cube, QuadGenerator.MakeQuad(
			new Vector3 (1,0,0),
			new Vector3 (0,0,1)
		));

		// Right
		cube = MeshBuilder.Combine(cube, MeshBuilder.Offset (QuadGenerator.MakeQuad(
			new Vector3 (0,1,0),
			new Vector3 (0,0,1)
			), 
     		new Vector3 (1,0,0) 
         ));

		// Up
		cube = MeshBuilder.Combine(cube, MeshBuilder.Offset (QuadGenerator.MakeQuad(
			new Vector3 (0,0,1),
			new Vector3 (1,0,0)
			), 
         	new Vector3 (0,1,0) 
		));

		// Back
		cube = MeshBuilder.Combine(cube, MeshBuilder.Offset (QuadGenerator.MakeQuad(
			new Vector3 (0,-1,0),
			new Vector3 (1,0,0)
			), 
         	new Vector3 (0,1,1) 
         ));

		cube = MeshBuilder.Offset(cube, new Vector3(-0.5f, -0.5f, -0.5f));
		cube.RecalculateBounds();
		cube.RecalculateNormals();
	
		mf.mesh = cube;
	}

}
