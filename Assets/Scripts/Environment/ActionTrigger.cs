using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider))]
public class ActionTrigger : MonoBehaviour {
	public TriggerAction[]	Actions;		// List of actions that will be triggered
	public bool 			AutoSetOn;		// If Auto-ON, will trigger the ON action with OnTriggerEnter
	public bool 			AutoSetOff;		// If Auto-OFF, will trigger the OFF action with OnTriggerExit
	public bool 			OneUse;			// Should ( ON action be of one use only )
	public KeyCode 			InputKeyCode;	// Input KeyCode that will trigger the action

	bool m_IsPlayerOnTriggerZone;			// Check if Player is in TriggerZone, used to align with Key Press
	bool m_IsUsed;							// Check if actions already triggered,used to align with OneUse

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("Player")) {
			m_IsPlayerOnTriggerZone = true;
			if (AutoSetOn) {
				TriggerOn ();
			}
		}
	}

	void OnTriggerExit(Collider other){
		if (other.gameObject.CompareTag ("Player")) {
			m_IsPlayerOnTriggerZone = false;
			if (AutoSetOff) {
				foreach (var action in Actions)
					action.SetOff ();
			}
		}
	}

	void Update(){
		if (m_IsPlayerOnTriggerZone && Input.GetKeyDown (InputKeyCode)) {
			TriggerOn ();
		}
	}

	void TriggerOn(){
		if(OneUse && m_IsUsed)
			return;

		m_IsUsed = true;
		foreach (var action in Actions) {
			action.SetOn (this);
		}
	}

	// Some Actions would need to TriggerOff it self, if AutoSetOff == true && Player is outside the TriggerZone;
	public void OnSetOnAnimationComplete(TriggerAction action){
		if(AutoSetOff && !m_IsPlayerOnTriggerZone)
			action.SetOff();
	}
}
