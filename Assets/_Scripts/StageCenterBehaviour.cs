using UnityEngine;
using System.Collections;

public class StageCenterBehaviour : MonoBehaviour {

	private ScoreController scoreController;
	private GameObject lastObject;
	private bool countValue = false;

	void Awake() {
		scoreController = GameObject.FindGameObjectWithTag ("ScoreController")
			.GetComponent<ScoreController>();
	}

	// Use this for initialization
	void Start () {
	
	}

	void OnCollisionEnter (Collision col) {
		Debug.Log ( "countValue: " + gameObject.layer + 
		            "gameObject: " + col.gameObject);

		if (this.gameObject.layer.Equals (col.gameObject.layer)) 
		{
			if (!countValue && !gameObject.tag.Equals ("floor")) 
			{
				countValue = true;
				scoreController.AddScore (10);
			} 
		}
		else 
		{
			DestroyCube (gameObject);
			// DestroyCube (this.gameObject);
		}
	}


	void DestroyCube(GameObject _gameObject) 
	{
		if (!_gameObject.layer.Equals ("floor")) 
		{
			scoreController.AddScore (-10);
			Destroy (_gameObject);
		}
	}
	// Update is called once per frame
	void Update () {

	}
}
