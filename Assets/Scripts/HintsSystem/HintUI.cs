﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HintUI : MonoBehaviour {
	Text	m_TextUI;							// Reference for Unity UI Text component.
	int		m_ActiveInstanceID = -1;			// InstanceID for the last gameobject called HintUI to show a text.

	public static HintUI Instance;

	// Use this for initialization
	void Awake () {
		Instance = this;
		m_TextUI = GetComponent<Text> ();
	}

	public void SetText(string text, GameObject caller = null){
		m_TextUI.text = text;

		if (caller == null) {
			Invoke ("ClearText", 2);						// Self-Clear Text if no gameobject was assigned
		} else {
			m_ActiveInstanceID = caller.GetInstanceID();	// Save InstanceID for caller gameObject
		}
	}

	public void ClearText(GameObject caller){
		if (caller.GetInstanceID() == m_ActiveInstanceID) {
			ClearText ();
		}
	}

	private void ClearText(){
		m_TextUI.text = "";
		m_ActiveInstanceID = -1;
	}
}
