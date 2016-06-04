using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
	public Transform 	Gun;
	public int 			damagePerShot = 2;                 // The damage inflicted by each bullet.
	public float 		timeBetweenBullets = 0.15f;        // The time between each shot.
	public float 		range = 100f;                      // The distance the gun can fire.

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

		Vector3 Direction = Vector3.zero;
		if (Input.GetButtonDown ("Fire1")) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
			RaycastHit[] hits = Physics.RaycastAll (ray, 100);

			foreach(RaycastHit hit in hits){

				if (hit.transform.CompareTag ("Ground")) {
					Direction = hit.point - Gun.transform.position;
					Direction.y = 0;
				}
			}

			if (Direction != Vector3.zero) {
				timer = 0;

				RaycastHit shootHit;
				gunLine.enabled = true;
				gunLine.SetPosition (0, Gun.position);
				// Perform the raycast against gameobjects on the shootable layer and if it hits something...
				if(Physics.Raycast(Gun.position, Direction, out shootHit, range, shootableMask)){
					// Try and find an EnemyHealth script on the gameobject hit.
					Health enemyHealth = shootHit.collider.GetComponent <Health> ();

					// If the EnemyHealth component exist...
					if (enemyHealth != null) {
						// ... the enemy should take damage.
						enemyHealth.TakeDamage (damagePerShot);
					}

					// Set the second position of the line renderer to the point the raycast hit.
					gunLine.SetPosition (1, shootHit.point);
				}
				// If the raycast didn't hit anything on the shootable layer...
				else {
					// ... set the second position of the line renderer to the fullest extent of the gun's range.
					gunLine.SetPosition (1, Gun.position + Direction * range);
				}
			}
		}

		// If the timer has exceeded the proportion of timeBetweenBullets that the effects should be displayed for...
		if (timer >= timeBetweenBullets * effectsDisplayTime) {
			// ... disable the effects.
			gunLine.enabled = false;
		}
	}
}