using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(Collider))]
public class HealingArea : MonoBehaviour {
	public float HealingSpeed = 1;

	List<Health> m_HealthInsideArea;

	void Awake(){
		m_HealthInsideArea = new List<Health> ();
	}

	void OnTriggerEnter(Collider other){
		Health health = other.gameObject.GetComponent<Health> ();
		if (health != null) {
			m_HealthInsideArea.Add (health);
		}
	}

	void OnTriggerExit(Collider other){
		Health health = other.gameObject.GetComponent<Health> ();
		if (health != null) {
			m_HealthInsideArea.Remove (health);
		}
	}

	void Update(){
		foreach (var health in m_HealthInsideArea) {
			health.Heal (HealingSpeed * Time.deltaTime);
		}
	}
}
