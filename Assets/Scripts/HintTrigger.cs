using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class HintTrigger : MonoBehaviour {
	public string HintMsg;

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("Player")) {
			HintUI.SetText (HintMsg, gameObject.GetInstanceID());
		}
	}

	void OnTriggerExit(Collider other){
		if (other.gameObject.CompareTag ("Player")) {
			HintUI.ClearText (gameObject.GetInstanceID());
		}
	}
}
