using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider))]
public class ActionTrigger : MonoBehaviour {
	public TriggerAction[]	actions;
	public bool 			AutoSetOn;
	public bool 			AutoSetOff;
	public bool 			OneUse;
	public KeyCode 			key;

	bool m_IsPlayerOnTriggerZone;
	bool m_IsUsed;

	void OnTriggerEnter(Collider other){
		if(OneUse && m_IsUsed)
			return;
		
		if (other.gameObject.CompareTag ("Player")) {
			m_IsPlayerOnTriggerZone = true;
			if (AutoSetOn) {
				m_IsUsed = true;
				foreach (var action in actions)
					action.SetOn (this);
			}
		}
	}

	void OnTriggerExit(Collider other){
		if (other.gameObject.CompareTag ("Player")) {
			m_IsPlayerOnTriggerZone = false;
			if (AutoSetOff) {
				foreach (var action in actions)
					action.SetOff ();
			}
		}
	}

	void Update(){
		if(OneUse && m_IsUsed)
			return;
		
		if (m_IsPlayerOnTriggerZone && Input.GetKeyDown (key)) {
			m_IsUsed = true;
			foreach (var action in actions) {
				action.SetOn (this);
			}
		}
	}

	public void OnAnimationComplete(TriggerAction action){
		if(AutoSetOff && !m_IsPlayerOnTriggerZone)
			action.SetOff();
	}
}
