using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreController : MonoBehaviour {

	public Text scoreText;

	private long score;

	public void AddScore (long scoreToAdd) {
		score += scoreToAdd;
		UpdateScore ();
	}

	public void UpdateScore () {
		scoreText.text = "SCORE: " + score;
	}

}
