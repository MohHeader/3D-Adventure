using UnityEngine;
using System.Collections;

public class StartNarrative : MonoBehaviour {
	public Conversation StartConversation;

	// Use this for initialization
	void Start () {
		ConversationManager.Instance.StartConversation (StartConversation);
	}
}
