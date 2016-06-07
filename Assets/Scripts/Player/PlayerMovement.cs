using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	CharacterController	m_CharacterController;
	Vector3				m_MoveDirection = Vector3.zero;
	int 				m_EnvLayerMask;

	public float WalkSpeed = 6.0F;
	public float RunSpeed = 12.0F;
	public float JumpSpeed = 8.0F;
	public float Gravity = 20.0F;

	void Awake(){
		m_CharacterController = GetComponent<CharacterController> ();
		m_EnvLayerMask = LayerMask.GetMask ("Environment");
	}

	public void Move(Vector3 Move, bool Jump, bool Run){
		if(!GameStateMaster.Instance.IsPlayable() )
			return;
		
		if (m_CharacterController.isGrounded) {
			m_MoveDirection = Move;
			m_MoveDirection = transform.TransformDirection(Move);
			m_MoveDirection *= Run ? RunSpeed : WalkSpeed;
			if (Jump)
				m_MoveDirection.y = JumpSpeed;
		}
		m_MoveDirection.y -= Gravity * Time.deltaTime;
		m_CharacterController.Move(m_MoveDirection * Time.deltaTime);
	}

	public void Crouch(bool Crouch){
		// prevent standing up in crouch-only zones
		if (!Crouch) {
			Ray crouchRay = new Ray(m_CharacterController.bounds.center, Vector3.up);
			if (Physics.SphereCast(crouchRay, m_CharacterController.radius * 0.5f, m_CharacterController.bounds.size.y, m_EnvLayerMask)) {
				Crouch = true;
			}
		}

		if (Crouch) {
			transform.localScale = new Vector3 (1,0.4f,1);
		} else {
			transform.localScale = new Vector3 (1,1,1);
		}
	}
}
