using UnityEngine;
using System.Collections;

public class Moving : MonoBehaviour {
	private int horizontal;
	private int vertical;
	// Use this for initialization
	void Start () {
		horizontal = -1;
		vertical = -1;	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 position = transform.position;

#if UNITY_ANDROID
		transform.Translate (new Vector3(
			-Input.acceleration.x * 100 * Time.deltaTime * 1,
			0,
			-Input.acceleration.y * 100 * Time.deltaTime * 1));

#else
		transform.Translate (new Vector3(
			-(Input.GetAxis("Horizontal")) * Time.deltaTime * 1,
			0,
			-Input.GetAxis("Vertical") * Time.deltaTime * 1));
#endif

	}

	private void OnControllerColliderHit(ControllerColliderHit hit)
	{
		Rigidbody body = hit.collider.attachedRigidbody;
		
		if (body == null || body.isKinematic)
		{
			return;
		}
		horizontal += 1;
		vertical += 1;
	}
}
