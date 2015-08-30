using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(MeshFilter))]
[ExecuteInEditMode]
public class CubeGenerator : MonoBehaviour {

	void Start () {
		MeshFilter mf = GetComponent<MeshFilter>();
		Mesh cube = new Mesh();

		List<Vector2> uvs = new List<Vector2>();

		// Front
		cube = MeshBuilder.Combine(cube, QuadGenerator.MakeQuad(
			new Vector3 (0,1,0),
			new Vector3 (1,0,0)
		));
		uvs.Add(new Vector2(0f   , 1f/3f)); //A
		uvs.Add(new Vector2(0f   , 2f/3f)); //B
		uvs.Add(new Vector2(1f/4f, 2f/3f)); //C
		uvs.Add(new Vector2(1f/4f, 1f/3f)); //D

		// Left
		cube = MeshBuilder.Combine(cube, MeshBuilder.Offset (QuadGenerator.MakeQuad(
			new Vector3 (0,1,0),
			new Vector3 (0,0,-1)
			), new Vector3 (0,0,1)
		));
		uvs.Add(new Vector2(3f/4f, 1f/3f));
		uvs.Add(new Vector2(3f/4f, 2f/3f));
		uvs.Add(new Vector2(1f   , 2f/3f));
		uvs.Add(new Vector2(1f   , 1f/3f));

		// Down
		cube = MeshBuilder.Combine(cube, QuadGenerator.MakeQuad(
			new Vector3 (1,0,0),
			new Vector3 (0,0,1)
		));
		uvs.Add(new Vector2(0f   , 0f   ));
		uvs.Add(new Vector2(0f   , 1f/3f));
		uvs.Add(new Vector2(1f/4f, 1f/3f));
		uvs.Add(new Vector2(1f/4f, 0f   ));

		// Right
		cube = MeshBuilder.Combine(cube, MeshBuilder.Offset (QuadGenerator.MakeQuad(
			new Vector3 (0,1,0),
			new Vector3 (0,0,1)
			), new Vector3 (1,0,0) ));
		uvs.Add(new Vector2(1f/4f, 1f/3f));
		uvs.Add(new Vector2(1f/4f, 2f/3f));
		uvs.Add(new Vector2(1f/2f, 2f/3f));
		uvs.Add(new Vector2(1f/2f, 1f/3f));

		// Up
		cube = MeshBuilder.Combine(cube, MeshBuilder.Offset (QuadGenerator.MakeQuad(
			new Vector3 (0,0,1),
			new Vector3 (1,0,0)
			), new Vector3 (0,1,0) ));
		uvs.Add(new Vector2(0f   , 2f/3f));
		uvs.Add(new Vector2(0f   , 1f   ));
		uvs.Add(new Vector2(1f/4f, 1f   ));
		uvs.Add(new Vector2(1f/4f, 2f/3f));

		// Back
		cube = MeshBuilder.Combine(cube, MeshBuilder.Offset (QuadGenerator.MakeQuad(
			new Vector3 (0,-1,0),
			new Vector3 (1,0,0)
			), new Vector3 (0,1,1) ));
		uvs.Add(new Vector2(3f/4f, 2f/3f)); //C
		uvs.Add(new Vector2(3f/4f, 1f/3f)); //D
		uvs.Add(new Vector2(1f/2f, 1f/3f)); //A
		uvs.Add(new Vector2(1f/2f, 2f/3f)); //B

		cube = MeshBuilder.Offset(cube, new Vector3(-0.5f, -0.5f, -0.5f));
		cube.uv = uvs.ToArray();
		cube.RecalculateBounds();
		cube.RecalculateNormals();
	
		mf.mesh = cube;
	}

}
