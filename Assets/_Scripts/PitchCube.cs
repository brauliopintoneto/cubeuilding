using UnityEngine;
using System.Collections;
using System;

public class PitchCube : MonoBehaviour {

	public GameObject prefab;
	private Rigidbody rigidBody;
	private float time;
	private int increment;
	private bool created;
	// Use this for initialization
	void Start () {
		time = Time.fixedDeltaTime;
		created = false;
		CreateCube ();
		increment = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.LeftShift) && created) {
			created = false;
			// increment += 1;
			rigidBody.useGravity = true;
			Invoke("CreateCube", 3);
		}
	}

	void CreateCube(){
		// transform.position.y += 100;
		Vector3 position = transform.position;
		// position.y += increment;
		var obj = Instantiate (prefab, position, transform.rotation) as GameObject;
		// Vector3 position = obj.transform.position;
		rigidBody = obj.GetComponent<Rigidbody> ();

		created = true;
	}
}
