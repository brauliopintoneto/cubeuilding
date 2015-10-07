using UnityEngine;
using System.Collections;

public class ClawMove : MonoBehaviour {
    Rigidbody rigidboody;
   
    float directionX =-1;
    float directionZ = 0;
	bool started = false;

    // Use this for initialization
    void Start () {
		Invoke("MoveObject", 1);
        if (rigidboody == null)
        {
            rigidboody = GetComponent<Rigidbody>();
        }
       
    }
	
	// Update is called once per frame
	void FixedUpdate () {
		if (started) {
			MoveObject ();
		}
	}

	void MoveObject() {
		rigidboody.velocity = new Vector3(directionX *  Time.deltaTime * 200, 0, directionZ * Time.deltaTime * 200);
		started = true;
	}

    void OnTriggerEnter(Collider other)
    {
        directionX *= -1;
    }
}
