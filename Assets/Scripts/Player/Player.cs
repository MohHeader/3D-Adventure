using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerInputController))]
[RequireComponent(typeof(PlayerMovement))]
public class Player : MonoBehaviour {

	PlayerInputController m_InputController;
	PlayerMovement m_PlayerMovement;

	// Use this for initialization
	void Start () {
		m_InputController = GetComponent<PlayerInputController> ();
		m_PlayerMovement = GetComponent<PlayerMovement> ();
		m_InputController.OnControllerUpdate += delegate() {
			m_PlayerMovement.Move(m_InputController.Move, m_InputController.Jump, m_InputController.Run );
		};
	}
}
