using UnityEngine;
using System.Collections;
using System;

public class PitchCube : MonoBehaviour {
	
	public GameObject[] cubePrefabs;
	public GameObject gameObject;
	private Rigidbody rigidBody;


	private bool created;

	void Awake () {
		cubePrefabs = Resources.LoadAll<GameObject> ("_Prefabs") as GameObject[];
	}

	// Use this for initialization
	void Start () {
		created = false;
		// Create initial cube
		CreateCube ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		// Check if left shift clicked
		if (Input.GetKeyDown (KeyCode.Space) && created) {
			created = false;
			rigidBody.useGravity = true;
			rigidBody.transform.parent = null;
			Invoke("CreateCube", 2);
		}

		if (rigidBody != null && !rigidBody.useGravity && 
		    gameObject != null) {
			rigidBody.position = gameObject.transform.position;
		}
	}

	void CreateCube(){
		var randomPrefab = cubePrefabs[UnityEngine.Random.Range(0, cubePrefabs.Length)];
		Vector3 position = gameObject.transform.position;
		var obj = Instantiate (randomPrefab, position, transform.rotation) as GameObject;
		rigidBody = obj.GetComponent<Rigidbody> ();
		created = true;
	}
}
