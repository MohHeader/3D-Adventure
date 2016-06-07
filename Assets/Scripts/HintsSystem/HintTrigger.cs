using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class HintTrigger : MonoBehaviour {
	public string HintMsg;					// The Message that will show it to the player.

	void OnTriggerEnter(Collider other){
		if (enabled && other.gameObject.CompareTag ("Player")) {
			HintUI.Instance.SetText (HintMsg, gameObject);
		}
	}

	void OnTriggerExit(Collider other){
		if (other.gameObject.CompareTag ("Player")) {
			HintUI.Instance.ClearText (gameObject);
		}
	}

	void OnDisable(){
		HintUI.Instance.ClearText (gameObject);
	}
}
