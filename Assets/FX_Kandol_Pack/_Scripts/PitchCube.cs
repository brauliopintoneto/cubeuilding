using UnityEngine;
using System.Collections;
using System;

public class PitchCube : MonoBehaviour {
	
	public GameObject cubePrefab;
	public GameObject gameObject;
	private Rigidbody rigidBody;


	private bool created;

	void Awake () {
	
	}

	// Use this for initialization
	void Start () {
		created = false;
		// Create initial cube
		CreateCube ();
	}
	
	// Update is called once per frame
	void Update () {
		// Check if left shift clicked
		if ((Input.GetKeyDown (KeyCode.Space) || Input.touchCount>0) && created) {
			created = false;
			rigidBody.useGravity = true;
			rigidBody.transform.parent = null;
            float direction = GetComponentInParent<ClawMove>().direction;
            Vector3 position = Vector3.right;
            if (direction > 0)
            {
                position = Vector3.right;
            }
            else
            {
                position = Vector3.left;
            }
            rigidBody.AddForce(position * (rigidBody.mass * 100));
            Invoke("CreateCube", 2);
		}

		if (rigidBody != null && !rigidBody.useGravity && 
		    gameObject != null) {
			rigidBody.position = gameObject.transform.position;
		}
	}

	void CreateCube(){

		
		Vector3 position = gameObject.transform.position;
		Quaternion rotation = transform.rotation;
		rotation.x = 0;
		rotation.y = 0;
		rotation.z = 0;
		var obj = Instantiate (cubePrefab, position, rotation) as GameObject;
		rigidBody = obj.GetComponent<Rigidbody> ();
      
           created = true;
	}
}
