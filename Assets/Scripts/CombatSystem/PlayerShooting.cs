using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
	public WeaponItem	Weapon;
	public Transform 	ShootPosition;

	float 			timer;                             // A timer to determine when to fire.
	float 			effectsDisplayTime = 0.2f;         // The proportion of the timeBetweenBullets that the effects will display for.
	int  			shootableMask;
	LineRenderer 	gunLine;                           // Reference to the line renderer.

	void Awake () {
		// Set up the references.
		gunLine = GetComponent <LineRenderer> ();
		shootableMask = LayerMask.GetMask ("Environment", "Shootable");
	}

	void Update () {
		// Add the time since Update was last called to the timer.
		timer += Time.deltaTime;

		if (Weapon == null) {
			gunLine.enabled = false;
			return;
		}
		
		if (Input.GetButtonDown ("Fire1")) {
			Vector3 Direction = Vector3.zero;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
			RaycastHit[] hits = Physics.RaycastAll (ray, 100);

			foreach(RaycastHit hit in hits){

				if (hit.transform.CompareTag ("Ground")) {
					Direction = hit.point - ShootPosition.transform.position;
					Direction.y = 0;
				}
			}

			if (Direction != Vector3.zero) {
				timer = 0;

				RaycastHit shootHit;
				gunLine.enabled = true;
				gunLine.SetPosition (0, ShootPosition.position);
				// Perform the raycast against gameobjects on the shootable layer and if it hits something...
				if(Physics.Raycast(ShootPosition.position, Direction, out shootHit, Weapon.Range, shootableMask)){
					// Try and find an EnemyHealth script on the gameobject hit.
					Health enemyHealth = shootHit.collider.GetComponent <Health> ();

					// If the EnemyHealth component exist...
					if (enemyHealth != null) {
						// ... the enemy should take damage.
						enemyHealth.TakeDamage (Weapon.DamageAmount);
					}

					// Set the second position of the line renderer to the point the raycast hit.
					gunLine.SetPosition (1, shootHit.point);
				}
				// If the raycast didn't hit anything on the shootable layer...
				else {
					// ... set the second position of the line renderer to the fullest extent of the gun's range.
					gunLine.SetPosition (1, ShootPosition.position + Direction * Weapon.Range);
				}
			}
		}
			
		// If the timer has exceeded the proportion of timeBetweenBullets that the effects should be displayed for...
		if (timer >= Weapon.CoolDownTime * effectsDisplayTime) {
			gunLine.enabled = false;
		}
	}
}