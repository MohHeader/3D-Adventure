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
		SetConversation (entry.SpeakingCharacterName, entry.ConversationText);
	}

	public void SetConversation(string name, string value){
		SpeakerName.text = name;
		ConversationEntryText.text = value;
	}
}
