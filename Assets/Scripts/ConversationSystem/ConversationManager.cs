using System.Collections;
using UnityEngine;

public class ConversationManager : Singleton<ConversationManager> {
	ConversationEntry	m_CurrentConversationLine;	//The current line of text being displayed
	ConversationUI		m_ConversationUI;			// The ConversationUI ( the GUI part )

	//Guarantee this will always be a singleton only – 
	//can't use the constructor!
	protected ConversationManager () {} 

	void Awake(){
		LoadConversationUI();
	}

	void LoadConversationUI(){
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
		if(m_ConversationUI == null){
			LoadConversationUI ();
		}

		if(GameStateMaster.Instance.State == GameState.Conversation){
			return;
		}

		StartCoroutine (DisplayConversation(conversation));
	}

	IEnumerator DisplayConversation(Conversation conversation){
		GameState oldState = GameStateMaster.Instance.State;
		GameStateMaster.Instance.SetState (GameState.Conversation);
		m_ConversationUI.gameObject.SetActive (true);
		foreach (var conversationLine in conversation.ConversationLines) {
			m_ConversationUI.SetConversation (conversationLine);
			yield return new WaitForSeconds(conversationLine.Duration);
		}
		m_ConversationUI.gameObject.SetActive (false);
		GameStateMaster.Instance.SetState (oldState);
	}


	public void StartConversation(NodeEditorFramework.NodeCanvas conversation){
		if(m_ConversationUI == null){
			LoadConversationUI ();
		}

		if(GameStateMaster.Instance.State == GameState.Conversation){
			return;
		}
		EntryNode CurrentNode = GetFirst (conversation);

		if (CurrentNode == null) {
			Debug.LogError ("No EntryNode connected to StartNode !");
			return;
		}

		StartCoroutine (DisplayConversation(CurrentNode));
	}

	IEnumerator DisplayConversation(EntryNode CurrentNode){
		GameState oldState = GameStateMaster.Instance.State;
		GameStateMaster.Instance.SetState (GameState.Conversation);
		m_ConversationUI.gameObject.SetActive (true);

		while (CurrentNode != null) {
			m_ConversationUI.SetConversation (CurrentNode.Name, CurrentNode.Value);
			yield return new WaitForSeconds(Mathf.Max(2,(CurrentNode.Value.Length * 0.06f)));
			CurrentNode = GetNext(CurrentNode);
		}

		m_ConversationUI.gameObject.SetActive (false);
		GameStateMaster.Instance.SetState (oldState);
	}

	EntryNode GetFirst(NodeEditorFramework.NodeCanvas canvas){
		foreach (var node in canvas.nodes) {
			if (node is StartNode) {
				return GetNext (node);
			}
		}
		Debug.LogError ("No StartNode exist !");
		return null;
	}

	EntryNode GetNext(NodeEditorFramework.Node node){
		print ("node.Outputs.Count : " + node.Outputs.Count);
		if (node.Outputs.Count > 0) {
			print ("node.Outputs[0].connections.Count : " + node.Outputs[0].connections.Count);
			if(node.Outputs [0].connections.Count > 0)
				return node.Outputs [0].connections [Random.Range (0, node.Outputs [0].connections.Count)].body as EntryNode;
		}
		return null;
	}
}