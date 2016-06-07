using UnityEngine;
using System.Collections;
using DG.Tweening;

public class PullLever : TriggerAction {
	bool 	m_isOpen;		// State of the Pull Lever

	public override void SetOn(ActionTrigger trigger){
		if (!m_isOpen) {
			m_isOpen = true;
			transform.DOLocalRotate (new Vector3 (150, transform.eulerAngles.y, transform.eulerAngles.z), 2);
		}
	}

	public override void SetOff(){
	}
}
