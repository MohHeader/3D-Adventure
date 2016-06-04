using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	public float MaxHealth;

	float m_CurrentHealth;

	// Use this for initialization
	void Awake () {
		Reset ();
	}

	public void TakeDamage(float amount){
		m_CurrentHealth -= amount;

		if (m_CurrentHealth <= 0)
			Death ();
	}

	public void Reset(){
		m_CurrentHealth = MaxHealth;
	}

	void Death(){
		Destroy (gameObject);
	}
}
