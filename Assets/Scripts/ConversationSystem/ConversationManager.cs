using System.Collections;
using UnityEngine;

public class ConversationManager : Singleton<ConversationManager >
{
	//Is there a conversation going on
	bool m_Talking = false;

	//The current line of text being displayed
	ConversationEntry m_CurrentConversationLine;

	ConversationUI m_ConversationUI;

	//Guarantee this will always be a singleton only – 
	//can't use the constructor!
	protected ConversationManager () {} 

	void Awake(){
		// Add Conversation Dialog UI
		GameObject conversationUIGO = Instantiate(Resources.Load<GameObject>("ConversationCanvas")) as GameObject;

		if (conversationUIGO == null) {
			Debug.LogError ("Resources/ConversationCanvas Doesn't exist !");
			return;
		}

		m_ConversationUI = conversationUIGO.GetComponentInChildren<ConversationUI> ();

		if (m_ConversationUI == null) {
			Debug.LogError ("Resources/ConversationCanvas Doesn't contain ConversationUI in it's children !");
		}
	}

	public void StartConversation(Conversation conversation){
		StartCoroutine (DisplayConversation(conversation));
	}

	IEnumerator DisplayConversation(Conversation conversation){
		m_ConversationUI.gameObject.SetActive (true);
		foreach (var conversationLine in conversation.ConversationLines) {
			m_ConversationUI.SetConversation (conversationLine);
			yield return new WaitForSeconds(conversationLine.Duration);
		}
		m_ConversationUI.gameObject.SetActive (false);
	}
}