using UnityEngine;
using System.Collections;
using System;

public class PitchCube : MonoBehaviour {
	
	public GameObject[] cubePrefabs;
	public GameObject gameObject;
	public Color[] colors;
	public float thrust;

	private Rigidbody rigidBody;
	private bool created;

	void Awake () {
		cubePrefabs = Resources.LoadAll<GameObject> ("_Prefabs") as GameObject[];
	}

	// Use this for initialization
	void Start () {
		created = false;
		CreateCube ();
	}

	void Update() {
		// Check if left shift clicked

//#if UNITY_ANDROID
//		if (Input.touchCount > 0 && created) {
//#else
		if (Input.GetKeyUp (KeyCode.Space) && created) {
//#endif		
			created = false;
			rigidBody.useGravity = true;
			rigidBody.transform.parent = null;
			AudioSource shootCube = GetComponent<AudioSource> ();
			shootCube.Play ();
			Invoke("CreateCube", 0.2f);
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
		obj.name = "LaunchedCube";
		rigidBody = obj.GetComponent<Rigidbody> ();
		rigidBody.AddForce(transform.up * -thrust);
		rigidBody.useGravity = false;
		created = true;
	}
}
