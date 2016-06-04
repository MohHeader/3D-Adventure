using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HintUI : MonoBehaviour {
	static HintUI Instance;

	Text m_TextUI;
	int m_ActiveInstanceID = -1;

	// Use this for initialization
	void Awake () {
		Instance = this;
		m_TextUI = GetComponent<Text> ();
	}

	public static void SetText(string text, int id){
		Instance.Internal_SetText (text, id);
	}

	void Internal_SetText(string text, int id){
		m_TextUI.text = text;
		m_ActiveInstanceID = id;
	}

	public static void ClearText(int id){
		Instance.Internal_ClearText (id);
	}

	void Internal_ClearText(int id){
		if (id == m_ActiveInstanceID) {
			Internal_SetText ("", -1);
		}
	}
}
