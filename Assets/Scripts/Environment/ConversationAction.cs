using UnityEngine;
using System.Collections;

public class ConversationAction : TriggerAction {
	public Conversation ConversationText;
	public override void SetOn (ActionTrigger trigger) {
		ConversationManager.Instance.StartConversation (ConversationText);
	}

	public override void SetOff () {
	}
}
