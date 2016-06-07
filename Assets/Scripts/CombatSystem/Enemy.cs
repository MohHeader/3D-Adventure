using UnityEngine;
using System.Collections;

public abstract class Enemy : MonoBehaviour {
	// Abstract class for all Eenemy types to inherit from, Behaviour would be componenet-based
	void Awake(){
		Health health = GetComponent<Health> ();

		if (health != null) {
			health.OnDeath += delegate() {
				if(OnDeath != null)
					OnDeath();
			};
		}
	}

	public abstract void SetTarget (Player player);

	public event System.Action OnDeath;
}
