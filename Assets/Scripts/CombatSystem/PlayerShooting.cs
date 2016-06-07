using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
	public WeaponItem	Weapon;
	public Transform 	ShootPosition;

	float 			m_Timer;							// A timer to determine when to fire.
	float 			m_EffectsDisplayTime = 0.2f;		// The proportion of the timeBetweenBullets that the effects will display for.
	int  			m_ShootableMask;					// Physics layer that would receive bullets ( example : walls, enemies, etc.. )
	LineRenderer 	m_gunLine;							// Reference to the line renderer.
	Plane 			m_ZeroYPlane;						// A plane on the Y-level of ShootingPosition, to calculate shooting direction

	void Awake () {
		// Set up the references.
		m_gunLine = GetComponent <LineRenderer> ();
		m_ShootableMask = LayerMask.GetMask ("Environment", "Shootable");

		m_ZeroYPlane = new Plane (Vector3.up, ShootPosition.position);
	}

	void Update () {
		// Add the time since Update was last called to the timer.
		m_Timer += Time.deltaTime;

		if (Weapon == null) {
			m_gunLine.enabled = false;
			return;
		}
		
		if (Input.GetButtonDown ("Fire1")) {
			Vector3 Direction = Vector3.zero;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 

			// Find where the user clicked based on the zeroYPlane
			float _hitDistance;
			m_ZeroYPlane.Raycast(ray, out _hitDistance);
			Vector3 MousePosition = ray.GetPoint(_hitDistance);

			// Shooting Direction
			Direction = MousePosition - ShootPosition.position;

			if (Direction != Vector3.zero) {
				m_Timer = 0;

				m_gunLine.enabled = true;
				m_gunLine.SetPosition (0, ShootPosition.position);

				RaycastHit shootHit;
				if(Physics.Raycast(ShootPosition.position, Direction, out shootHit, Weapon.Range, m_ShootableMask)){
					Health enemyHealth = shootHit.collider.GetComponent <Health> ();

					if (enemyHealth != null) {
						enemyHealth.TakeDamage (Weapon.DamageAmount);
						m_gunLine.SetPosition (1, enemyHealth.transform.position);
					} else {
						m_gunLine.SetPosition (1, shootHit.point);
					}
				}
				// If the raycast didn't hit anything on the shootable layer
				else {
					//set the second position of the line renderer to the fullest extent of the gun's range.
					m_gunLine.SetPosition (1, ShootPosition.position + Direction * Weapon.Range);
				}
			}
		}
			
		// If the timer has exceeded the proportion of Weapon.CoolDownTime that the effects should be displayed for
		if (m_Timer >= Weapon.CoolDownTime * m_EffectsDisplayTime) {
			m_gunLine.enabled = false;
		}
	}
}