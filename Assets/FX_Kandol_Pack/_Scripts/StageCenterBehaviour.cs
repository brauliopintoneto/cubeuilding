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
                    " col.gameObject.layer: " + col.gameObject.tag);
        
        gameObject.tag = "cubfixed";
             
        if (!col.gameObject.tag.Equals("floordestruction"))
        {
            if (!countValue)
            {
                countValue = true;
                scoreController.AddScore(1);
                
            }
        }
        else
        {
            DestroyCube(gameObject);
        }
     
          
      
	}

        void DestroyCube(GameObject _gameObject) 
	{
		if (!_gameObject.layer.Equals ("floor")) 
		{
			
            Destroy (_gameObject);
            Application.LoadLevel(0);

        }
	}
	// Update is called once per frame
	void Update () {
     
    }
}
