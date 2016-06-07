using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public Transform target;            // The transform that that camera will be following.
	public float CamSpeed = 5f;        	// The speed with which the camera will be following.

	Vector3 m_Offset;                     // The initial offset from the target.

	void Start () {
		// Calculate the initial offset.
		m_Offset = transform.position - target.position;
	}

	void FixedUpdate () {
		if (target == null)
			return;
		
		// Create a postion the camera is aiming for based on the offset from the target.
		Vector3 targetCamPos = target.position + m_Offset;

		// Smoothly interpolate between the camera's current position and it's target position.
		transform.position = Vector3.Lerp (transform.position, targetCamPos, CamSpeed * Time.deltaTime);
	}
}
