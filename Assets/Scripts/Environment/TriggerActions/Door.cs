using UnityEngine;
using System.Collections;
using DG.Tweening;

[RequireComponent(typeof(BoxCollider))]
public class Door : TriggerAction {
	bool 		m_isOpen;			// The State of the Door.
	bool 		m_isAnimating;		// If it is currently Animating ( Opening / Closing )
	float		m_YSize;			// The Door's hieght, to correctly animate it

	public string	KeyName;		// Some doors are locked, and need a key to open them

	void Awake(){
		m_YSize = GetComponent<BoxCollider> ().size.y;
	}

	public override void SetOn(ActionTrigger trigger){
		if (KeyName != "") {
			if (!GameMaster.CurrentPlayer.Inventory.HasItem (KeyName)) {
				HintUI.Instance.SetText("You need a Key : "+KeyName);
				return;
			}
		}

		if (!m_isOpen && !m_isAnimating) {
			m_isAnimating = true;
			transform.DOMoveY (0.05f - m_YSize, 1).OnComplete(delegate() { // 0.05 offset, it to keep the door visible on the floor
				m_isOpen = true;
				m_isAnimating = false;

				trigger.OnSetOnAnimationComplete(this);
			});
		}
	}

	public override void SetOff(){
		if (m_isOpen) {
			m_isAnimating = true;
			transform.DOMoveY (0f, 1).OnComplete(delegate() {
				m_isOpen = false;
				m_isAnimating = false;
			});
		}
	}
}
