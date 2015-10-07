using UnityEngine;
using System.Collections;
using System;

public class PitchCube : MonoBehaviour {
	
	public GameObject prefab;
	public GameObject gameObject;
	private Rigidbody rigidBody;


	private bool created;

	// Use this for initialization
	void Start () {
		created = false;
		// Create initial cube
		CreateCube ();
	}
	
	// Update is called once per frame
	void Update () {
		// Check if left shift clicked
		if (Input.GetKeyDown (KeyCode.Space) && created) {
			created = false;
			rigidBody.useGravity = true;
			rigidBody.transform.parent = null;
			Invoke("CreateCube", 3);
		}
	}

	void CreateCube(){
		Vector3 position = gameObject.transform.position;
		var obj = Instantiate (prefab, position, transform.rotation) as GameObject;
		rigidBody = obj.GetComponent<Rigidbody> ();
		created = true;
		obj.transform.parent = gameObject.transform.parent;
	}
}
