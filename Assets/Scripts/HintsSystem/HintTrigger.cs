using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class HintTrigger : MonoBehaviour {
	public string HintMsg;
	public KeyCode key;

	void OnTriggerEnter(Collider other){
		if (enabled && other.gameObject.CompareTag ("Player")) {
			HintUI.SetText (HintMsg, gameObject.GetInstanceID());
		}
	}

	void OnTriggerExit(Collider other){
		if (other.gameObject.CompareTag ("Player")) {
			HintUI.ClearText (gameObject.GetInstanceID());
		}
	}

	void Update(){
		if (Input.GetKeyDown (key)) {
			HintUI.ClearText (gameObject.GetInstanceID());
		}
	}
}
