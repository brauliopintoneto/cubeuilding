﻿using UnityEngine;
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
			rigidBody.transform.rotation.x = 0;
			rigidBody.transform.rotation.y = 0;
			rigidBody.transform.rotation.z = 0;
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
		Quaternion rotation = transform.rotation;
		rotation.x = 0;
		rotation.y = 0;
		rotation.z = 0;
		var obj = Instantiate (randomPrefab, position, rotation) as GameObject;
		rigidBody = obj.GetComponent<Rigidbody> ();
		created = true;
	}
}
