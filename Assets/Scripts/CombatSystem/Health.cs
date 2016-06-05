using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	public float MaxHealth;
	public float CurrentHealth { get; protected set; }

	// Use this for initialization
	void Awake () {
		Reset ();
	}

	public void TakeDamage(float amount){
		CurrentHealth -= amount;

		if (OnHealthChange != null)
			OnHealthChange ();

		if (CurrentHealth <= 0)
			Death ();
	}

	public void Reset(){
		CurrentHealth = MaxHealth;
	}

	void Death(){
		Destroy (gameObject);
	}

	public event System.Action OnHealthChange;
}
