using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ConversationUI : MonoBehaviour {
	public Text SpeakerName;
	public Text ConversationEntryText;

	void Awake(){
		SpeakerName.text = "";
		ConversationEntryText.text = "";
	}

	public void SetConversation(ConversationEntry entry){
		SpeakerName.text = entry.SpeakingCharacterName;
		ConversationEntryText.text = entry.ConversationText;
	}
}
