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
		ChangeHealthBy (-amount);

		if (CurrentHealth <= 0)
			Death ();
	}

	public void Heal(float amount){
		ChangeHealthBy (amount);	
	}

	void ChangeHealthBy(float amount){
		CurrentHealth += amount;

		CurrentHealth = Mathf.Clamp (CurrentHealth, 0, MaxHealth);

		if (OnHealthChange != null)
			OnHealthChange ();
	}

	public void Reset(){
		CurrentHealth = MaxHealth;
	}

	void Death(){
		if (OnDeath != null)
			OnDeath ();
		SimplePool.Despawn (gameObject);
	}

	public event System.Action OnHealthChange;
	public event System.Action OnDeath;
}
