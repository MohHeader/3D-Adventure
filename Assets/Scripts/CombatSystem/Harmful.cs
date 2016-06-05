using UnityEngine;
using System.Collections;

/// <summary>
/// This mean, that the attached to GameObject would Harm either the PlayerShip or the EnemyShip ( based on EnemyTag )
/// </summary>

public class Harmful : MonoBehaviour {
	// The Amount of health the other ship will lose on Collide
	public float Amount;

	// Destroy Self when harm the other ship ( useful for Bullets & some ships like the Kamikaze )
	// Could be turned off/false for Boss ships or ships with Strong Armor
	public bool SelfDestroy;

	// Either ( "Player" or "Enemy" )
	public string EnemyTag;

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.CompareTag (EnemyTag) == false)
			return;

		Health health = other.gameObject.GetComponent<Health> ();
		if (health != null) {

			health.TakeDamage (Amount);

			if (SelfDestroy) {
				health = gameObject.GetComponent<Health> ();
				if (health != null) {
					health.TakeDamage (health.MaxHealth);
				} else {
					SimplePool.Despawn (gameObject);
				}
			}
		} else {
			Debug.LogError ("No Health Script attached !");
		}
	}
}