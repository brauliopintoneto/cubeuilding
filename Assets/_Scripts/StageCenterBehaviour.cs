using UnityEngine;
using System.Collections;

public class StageCenterBehaviour : MonoBehaviour {

	private ScoreController scoreController;

	void Awake() {
		scoreController = GameObject.FindGameObjectWithTag ("ScoreController")
			.GetComponent<ScoreController>();
	}

	// Use this for initialization
	void Start () {
	
	}

	void OnCollisionEnter (Collision col) {
		Debug.Log("collision: "+col.collider.name);
		if (col.gameObject.tag.Equals ("CubePrefab")) {
			if (this.gameObject.layer.Equals (col.collider.gameObject.layer)) {
				scoreController.AddScore (10);
			} else {
				scoreController.AddScore (-10);
				Destroy (col.gameObject);
			}
		}
	}

	private void OnTriggerEnter(Collider other) {

	}

	// Update is called once per frame
	void Update () {

	}
}
