using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreController : MonoBehaviour {

	public Text timerText;
	public Text scoreText;
	public Text multiplierText;

	private long score;
	private long cubeCount;
	private int multiplier = 1;
	private float endTime;
	
	public void IncrementMultiplier ()
	{
		this.multiplier += 1;
		UpdateMultiplierText ();
	}

	public void ResetMultiplier ()
	{
		this.multiplier = 1;
		UpdateMultiplierText ();
	}

	public void AddScore (long scoreToAdd) 
	{
		score += scoreToAdd * multiplier;
		UpdateScore ();
	}

	public void UpdateMultiplierText () 
	{
		multiplierText.text = "x" + multiplier;
	}

	public void UpdateScore () 
	{
		scoreText.text = "SCORE: " + score;
	}

	public void IncrementCubeCount ()
	{
		cubeCount++;
	}

	public void DecrementCubeCount ()
	{
		cubeCount--;
	}

	public void UpdateTime () 
	{
		var timeLeft = endTime - Time.time;

		if (timeLeft < 0) 
		{ 
			timeLeft = 0;
			Application.LoadLevel("Main");
			//GameOver ();
		}

		var minutes = Mathf.Floor(timeLeft / 60); //Divide the guiTime by sixty to get the minutes.
		var seconds = Mathf.Floor(timeLeft % 60);//Use the euclidean division for the seconds.
		var fraction = (timeLeft * 100) % 100;
		
		//update the label value
		//timerLabel.text = string.Format ("{0:00} : {1:00} : {2:000}", minutes, seconds, fraction);
		timerText.text = string.Format ("{0:0}:{1:00}", minutes, seconds);
	}

	public void Start () 
	{
		endTime = Time.time + 300;
	}

	public void Update ()
	{
		Debug.Log (cubeCount);
		UpdateTime ();
	}
}
