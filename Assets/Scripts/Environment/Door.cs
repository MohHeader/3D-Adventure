﻿using UnityEngine;
using System.Collections;
using DG.Tweening;

[RequireComponent(typeof(BoxCollider))]
public class Door : TriggerAction {
	bool 		m_isOn;
	bool 		m_isAnimating;

	public float	YSize = 4.94f;
	public string	KeyName;

	public override void SetOn(ActionTrigger trigger){
		if (KeyName != "") {
			if (!GameMaster.Instance.CurrentPlayer.Inventory.HasItem (KeyName)) {
				HintUI.SetText("You need a Key : "+KeyName);
				return;
			}
		}

		if (!m_isOn && !m_isAnimating) {
			m_isAnimating = true;
			transform.DOMoveY (0.1f - YSize, 1).OnComplete(delegate() {
				m_isOn = true;
				m_isAnimating = false;

				trigger.OnAnimationComplete(this);
			});
		}
	}

	public override void SetOff(){
		if (m_isOn) {
			m_isAnimating = true;
			transform.DOMoveY (0f, 1).OnComplete(delegate() {
				m_isOn = false;
				m_isAnimating = false;
			});
		}
	}
}
