using UnityEngine;
using System.Collections;

public class Cube : MonoBehaviour {

	private ScoreController scoreController;

	void Awake ()
	{
		scoreController = GameObject.FindGameObjectWithTag ("ScoreController")
			.GetComponent<ScoreController> ();
	}

	void Start () 
	{
		scoreController.IncrementCubeCount ();
	}

	void OnDestroy () 
	{
		scoreController.DecrementCubeCount ();
	}

	void FixedUpdate ()
	{

	}

	void OnCollisionEnter (Collision col) 
	{
		if (col.gameObject.name == "LaunchedCube" && 
				col.gameObject.tag == gameObject.tag) {
			Destroy (gameObject);
			Destroy (col.gameObject);
			scoreController.AddScore (10);
			scoreController.IncrementMultiplier ();
		} else if (col.gameObject.name == "LaunchedCube" && 
		           col.gameObject.tag != gameObject.tag)
		{
			col.gameObject.name = "DroppedCube";
			scoreController.ResetMultiplier ();
		}
	}

}
