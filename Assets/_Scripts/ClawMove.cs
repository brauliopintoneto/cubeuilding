using UnityEngine;
using System.Collections;

public class ClawMove : MonoBehaviour {
    Rigidbody rigidboody;
   
    public int  speed;
    float direction =-1;

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
		rigidboody.velocity = new Vector3(direction * Input.GetAxis("Horizontal") *  Time.deltaTime * speed, 0, direction*Input.GetAxis("Vertical") * Time.deltaTime * speed);
		started = true;
	}


}
