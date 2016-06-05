using UnityEngine;
using System.Collections;

public class WelcomeNarrative : MonoBehaviour {
	public Conversation WelcomeConversation;

	// Use this for initialization
	void Start () {
		ConversationManager.Instance.StartConversation (WelcomeConversation);
	}
}
