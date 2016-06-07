using UnityEngine;
using System.Collections;

// This mean, that when attached to a GameObject it would Harm the other the Player or the Enemy ( based on EnemyTag ) on TriggerEnter
public class Harmful : MonoBehaviour {
	// The Amount of health the other entity will lose on Collide
	public float Amount;

	// Destroy Self when harm the other entity ( useful for Bullets & Mines )
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