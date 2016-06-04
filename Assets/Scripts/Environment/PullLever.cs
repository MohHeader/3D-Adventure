using UnityEngine;
using System.Collections;
using DG.Tweening;

public class PullLever : TriggerAction {
	bool 	m_isOpen;
	public string SetOnText;

	public override void SetOn(ActionTrigger trigger){
		if (!m_isOpen) {
			m_isOpen = true;
			HintUI.ClearText (gameObject.GetInstanceID());
			Destroy (GetComponent<HintTrigger> ());
			transform.DOLocalRotate (new Vector3 (150, transform.eulerAngles.y, transform.eulerAngles.z), 2).OnComplete(delegate() {
				if(SetOnText != ""){
					HintUI.SetText(SetOnText, gameObject.GetInstanceID ());
					Invoke("ClearHintText", 2);
				}
			});
		}
	}

	public override void SetOff(){
		
	}

	void ClearHintText(){
		HintUI.ClearText (gameObject.GetInstanceID ());
	}
}
