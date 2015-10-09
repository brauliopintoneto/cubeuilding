using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreController : MonoBehaviour {

	public Text scoreText;
    public Text recordText;


	private long score;

     void Start()
    {
        UpdateRecord();
    }

	public void AddScore (long scoreToAdd) {
		score += scoreToAdd;
      
		UpdateScore ();
        if (getRecord() < score)
        {
            SaveRecord((int)score);
        }
       

    }

 
    private void SaveRecord(int score)
    {
        PlayerPrefs.SetInt("record", score);
        PlayerPrefs.Save();

    }

    private int getRecord()
    {
        return PlayerPrefs.GetInt("record"); 
    }
    public void UpdateRecord()
    {
        recordText.text = "RECORD: " + PlayerPrefs.GetInt("record");
    }


    public void UpdateScore () {
		scoreText.text = "SCORE: " + score;
	}

    public long getScore()
    {
        return score;
    }

}
