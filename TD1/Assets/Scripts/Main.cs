using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

[RequireComponent(typeof(MeshFilter))]
public class Main : MonoBehaviour {

	public int size = 100;
	public float rotSpeed = 20;


	private MeshFilter mFilter;

    public void BtnClick(){
		mFilter = GetComponent<MeshFilter> ();
		mFilter.mesh = generateMesh ();
	}

	void Update(){

		if (Input.GetMouseButton (0)) {
			float rotX = Input.GetAxis ("Mouse X") * rotSpeed * Mathf.Deg2Rad;
			float rotY = Input.GetAxis ("Mouse Y") * rotSpeed * Mathf.Deg2Rad;

			transform.RotateAround (Vector3.up, -rotX);
			transform.RotateAround (Vector3.right, rotY);
		}
	}

	public void GetPolyhedraFromFile(){
		string path = EditorUtility.OpenFilePanel("Choose polyhedra description", "", "txt");
		if (path.Length != 0)
			print ("Well done!");
	}

	Mesh generateMesh(){
		Mesh mesh = new Mesh ();
		mesh.SetVertices(new List<Vector3>(){

			new Vector3(1*size,0,0),		//0
			new Vector3(0,0,1*size),		//1
			new Vector3(0,1*size,0),		//2

			new Vector3(0,0,0),		//3 
		});

		mesh.SetTriangles (new List<int> () {
			0,2,1,
			3,0,1,
			3,1,2,
			3,2,0
		},0);

		mesh.RecalculateNormals ();

		return mesh;
	}

}
