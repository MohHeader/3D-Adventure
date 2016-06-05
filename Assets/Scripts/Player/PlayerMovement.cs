﻿using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	CharacterController m_CharacterController;

	public float WalkSpeed = 6.0F;
	public float RunSpeed = 12.0F;
	public float JumpSpeed = 8.0F;
	public float Gravity = 20.0F;
	private Vector3 moveDirection = Vector3.zero;

	void Awake(){
		m_CharacterController = GetComponent<CharacterController> ();
	}

	public void Move(Vector3 Move, bool Jump, bool Run, bool Crouch){
		if(!GameStateMaster.Instance.IsMovable() )
			return;
		
		if (m_CharacterController.isGrounded) {
			moveDirection = Move;
			moveDirection = transform.TransformDirection(Move);
			moveDirection *= Run ? RunSpeed : WalkSpeed;
			if (Jump)
				moveDirection.y = JumpSpeed;
		}
		moveDirection.y -= Gravity * Time.deltaTime;
		m_CharacterController.Move(moveDirection * Time.deltaTime);

		if (Crouch) {
			transform.localScale = new Vector3 (1,0.4f,1);
		} else {
			transform.localScale = new Vector3 (1,1,1);
		}
	}
}
