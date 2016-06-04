using UnityEngine;
using System.Collections;

public class PlayerInputController : MonoBehaviour {

	private Transform 	m_Cam;                  // A reference to the main camera in the scenes transform
	private Vector3 	m_CamForward;             // The current forward direction of the camera

	public Vector3 	Move { get; protected set; }
	public bool 	Jump { get; protected set; }
	public bool 	Run  { get; protected set; }

	// Use this for initialization
	void Start () {
		// get the transform of the main camera
		if (Camera.main != null) {
			m_Cam = Camera.main.transform;
		} else {
			Debug.LogWarning(
				"Warning: no main camera found. Third person character needs a Camera tagged \"MainCamera\", for camera-relative controls.");
			// we use self-relative controls in this case, which probably isn't what the user wants, but hey, we warned them!
		}
	}

	// Update is called once per frame
	void Update () {
		Jump	= Input.GetButtonDown("Jump");
		Run		= Input.GetKey(KeyCode.LeftShift);

		// read inputs
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");

		// calculate move direction to pass to character
		if (m_Cam != null) {
			// calculate camera relative direction to move:
			m_CamForward = Vector3.Scale(m_Cam.forward, new Vector3(1, 0, 1)).normalized;
			Move = v*m_CamForward + h*m_Cam.right;
		} else {
			// we use world-relative directions in the case of no main camera
			Move = v*Vector3.forward + h*Vector3.right;
		}

		if (OnControllerUpdate != null)
			OnControllerUpdate ();
	}

	public event System.Action OnControllerUpdate;
}
