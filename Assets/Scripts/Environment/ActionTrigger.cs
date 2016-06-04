using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider))]
public class ActionTrigger : MonoBehaviour {
	public TriggerAction[] actions;
	public bool AutoSetOn;
	public bool AutoSetOff;
	public bool OneUse;
	public KeyCode key;

	bool m_IsPlayerOnTriggerZone;


	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("Player")) {
			m_IsPlayerOnTriggerZone = true;
			if (AutoSetOn) {
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
		if (m_IsPlayerOnTriggerZone && Input.GetKeyDown (key)) {
			foreach (var action in actions) {
				action.SetOn (this);

				if (OneUse) {
					HintTrigger hint = action.gameObject.GetComponent<HintTrigger> ();
					if (hint != null) {
						HintUI.ClearText (action.gameObject.GetInstanceID ());
						Destroy (hint);
					}
				}
			}
		}
	}

	public void OnAnimationComplete(TriggerAction action){
		if(AutoSetOff && !m_IsPlayerOnTriggerZone)
			action.SetOff();
	}
}
