using UnityEngine;
using System.Collections;

public class Cube : MonoBehaviour {

	public GameObject cube;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		MoveClaw ();

		if (Input.GetKeyDown(KeyCode.Space)) {
			ReleaseCube();
		}
	}

	void ReleaseCube () {
		cube.transform.parent = null;
		
		Rigidbody rigidbody = cube.AddComponent<Rigidbody>();
		rigidbody.mass = 1;
	}

	void MoveClaw () {
		transform.Translate (new Vector3(
			-Input.GetAxis("Horizontal") * Time.deltaTime * 1,
			0,
			-Input.GetAxis("Vertical") * Time.deltaTime * 1));
	}
}
