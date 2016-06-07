using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerInputController))]
[RequireComponent(typeof(PlayerMovement))]
public class Player : MonoBehaviour {

	PlayerInputController	m_InputController;
	PlayerMovement			m_PlayerMovement;
	Health					m_PlayerHealth;
	PlayerShooting			m_PlayerShooting;

	public Inventory		Inventory { get; protected set; }

	// Use this for initialization
	void Start () {
		m_InputController	= GetComponent<PlayerInputController> ();
		m_PlayerMovement	= GetComponent<PlayerMovement> ();
		m_PlayerHealth		= GetComponent<Health> ();
		m_PlayerShooting	= GetComponent<PlayerShooting> ();

		Inventory			= GetComponent<Inventory> ();

		m_InputController.OnControllerUpdate += delegate() {
			m_PlayerMovement.Move( m_InputController.Move, m_InputController.Jump, m_InputController.Run );
			m_PlayerMovement.Crouch( m_InputController.Crouch );
		};

		m_PlayerHealth.OnDeath += delegate() {
			GameMaster.Restart();
		};

		GameMaster.CurrentPlayer = this;
	}

	public void EquipWeapon(WeaponItem weapon){
		m_PlayerShooting.Weapon = weapon;
	}
}
