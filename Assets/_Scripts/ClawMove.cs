using UnityEngine;
using System.Collections;

public class ClawMove : MonoBehaviour {
    Rigidbody rigidboody;
   
    float directionX =-1;
    float directionZ = 0;
    // Use this for initialization
    void Start () {
       
        if (rigidboody == null)
        {
            rigidboody = GetComponent<Rigidbody>();
        }
       
    }
	
	// Update is called once per frame
	void Update () {
        rigidboody.velocity = new Vector3(directionX *  Time.deltaTime*200, 0, directionZ * Time.deltaTime * 200);
       
       

    }

    void OnTriggerEnter(Collider other)
    {

    


        directionX *= -1;

    }
}
