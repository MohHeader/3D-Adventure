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

	public static void SetText(string text, int id = -1){
		Instance.Internal_SetText (text, id);
	}

	void Internal_SetText(string text, int id){
		m_TextUI.text = text;
		m_ActiveInstanceID = id;

		if (id == -1) {
			Invoke ("Internal_ClearText", 2);				// Self Clear Text if not assigned to ID
		}
	}

	public static void ClearText(int id){
		Instance.Internal_ClearText (id);
	}

	void Internal_ClearText(int id){
		if (id == m_ActiveInstanceID) {
			m_TextUI.text = "";
			m_ActiveInstanceID = -1;
		}
	}

	void Internal_ClearText(){
		m_TextUI.text = "";
		m_ActiveInstanceID = -1;
	}
}
