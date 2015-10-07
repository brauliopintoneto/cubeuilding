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
		//transform.
//		position.x += 1;
//		position.z += 1;
		//transform.position=position;

		transform.Translate (new Vector3(
			-(Input.GetAxis("Horizontal")) * Time.deltaTime * 1,
			0,
			-Input.GetAxis("Vertical") * Time.deltaTime * 1));
	}

	private void OnControllerColliderHit(ControllerColliderHit hit)
	{
		Rigidbody body = hit.collider.attachedRigidbody;
		//dont move the rigidbody if the character is on top of it
//		if (m_CollisionFlags == CollisionFlags.Below)
//		{
//			return;
//		}
		
		if (body == null || body.isKinematic)
		{
			return;
		}
		horizontal += 1;
		vertical += 1;
		// body.AddForceAtPosition(m_CharacterController.velocity*0.1f, hit.point, ForceMode.Impulse);
	}
}
