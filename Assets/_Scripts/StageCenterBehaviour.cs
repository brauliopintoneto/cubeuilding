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
		//scoreController.AddScore (10);
	}

	// Update is called once per frame
	void Update () {

	}
}
