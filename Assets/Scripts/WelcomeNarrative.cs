using UnityEngine;
using System.Collections;

public class WelcomeNarrative : MonoBehaviour {
	public string WelcomeText;
	// Use this for initialization
	void Start () {
		HintUI.SetText (WelcomeText, gameObject.GetInstanceID ());
		Invoke ("ClearText", 3);
	}
	
	// Update is called once per frame
	void ClearText () {
		HintUI.ClearText (gameObject.GetInstanceID ());
	}
}
