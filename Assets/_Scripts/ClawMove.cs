using UnityEngine;
using System.Collections;

public class ClawMove : MonoBehaviour {
    Rigidbody rigidboody;
   
    float directionX =-1;
    float directionZ = 0;
	bool started = false;

    // Use this for initialization
    void Start () {
		Invoke("MoveObject", 3);
        if (rigidboody == null)
        {
            rigidboody = GetComponent<Rigidbody>();
        }
       
    }
	
	// Update is called once per frame
	void Update () {
		if (started) {
			MoveObject ();
		}
        // rigidboody.velocity = new Vector3(directionX *  Time.deltaTime*200, 0, directionZ * Time.deltaTime * 200);
	}

	void MoveObject() {
		rigidboody.velocity = new Vector3(directionX *  Time.deltaTime * 100, 0, directionZ * Time.deltaTime * 100);
		started = true;
	}

    void OnTriggerEnter(Collider other)
    {
        directionX *= -1;
    }
}
