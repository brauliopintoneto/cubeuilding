using UnityEngine;
using System.Collections;

public class LigthChange : MonoBehaviour {

	public Light light;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// Change ();
	}

	void Change() {
		float r = Random.Range (0f, 1f);
		float g = Random.Range (0f, 1f);
		float b = Random.Range (0f, 1f);
		// light.color = new Color(r, g, b);
	}
}
