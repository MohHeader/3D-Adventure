using UnityEngine;
using System.Collections;

public class ConversationAction : TriggerAction {
	public Conversation ConversationText;
	public NodeEditorFramework.NodeCanvas ConversationCanvas;

	public override void SetOn (ActionTrigger trigger) {
		#if UNITY_EDITOR
		if (ConversationCanvas != null) {

			string testpath = "Assets/Plugins/Node_Editor/Resources/Saves/" + ConversationCanvas.name + ".asset";
			Debug.Log (testpath);
			Debug.Log (NodeEditorFramework.Utilities.ResourceManager.PreparePath (testpath));

			NodeEditorFramework.NodeCanvas x = NodeEditorFramework.NodeEditorSaveManager.LoadNodeCanvas(testpath);

			NodeEditorFramework.NodeEditor.RecalculateAll (x);

			ConversationManager.Instance.StartConversation (x);
			return;
		}
		#endif
		ConversationManager.Instance.StartConversation (ConversationText);

	}

	public override void SetOff () {
	}
}
