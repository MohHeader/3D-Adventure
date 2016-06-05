using UnityEngine;
using System.Collections;

public abstract class Enemy : MonoBehaviour {
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
