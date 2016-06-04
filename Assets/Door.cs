using UnityEngine;
using System.Collections;
using DG.Tweening;

[RequireComponent(typeof(BoxCollider))]
public class Door : MonoBehaviour {
	bool 		m_isPlayerOnTriggerZone;
	bool 		m_isOpen;
	bool 		m_isAnimating;
	BoxCollider m_TriggerZone;

	void Awake(){
		m_TriggerZone = GetComponent<BoxCollider> ();
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("Player")) {
			m_isPlayerOnTriggerZone = true;
		}
	}

	void OnTriggerExit(Collider other){
		if (other.gameObject.CompareTag ("Player")) {
			m_isPlayerOnTriggerZone = false;
			CloseDoor ();
		}
	}

	void Update(){
		if (m_isPlayerOnTriggerZone && Input.GetKeyDown (KeyCode.O)) {
			OpenDoor ();
		}
	}

	void OpenDoor(){
		if (!m_isOpen && !m_isAnimating) {
			HintUI.ClearText (gameObject.GetInstanceID());
			m_isAnimating = true;
			transform.DOMoveY (0.1f - m_TriggerZone.size.y, 1).OnComplete(delegate() {
				m_isOpen = true;
				m_isAnimating = false;

				if(!m_isPlayerOnTriggerZone)
					CloseDoor();
			});
		}
	}

	void CloseDoor(){
		if (m_isOpen) {
			m_isAnimating = true;
			transform.DOMoveY (0f, 1).OnComplete(delegate() {
				m_isOpen = false;
				m_isAnimating = false;
			});
		}
	}
}
