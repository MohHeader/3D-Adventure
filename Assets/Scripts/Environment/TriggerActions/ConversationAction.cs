using UnityEngine;
using System.Collections;

public class ConversationAction : TriggerAction {
	public Conversation ConversationText;
	public NodeEditorFramework.NodeCanvas ConversationCanvas;

	// Starts a Conversation Dialog
	public override void SetOn (ActionTrigger trigger) {
		#if UNITY_EDITOR
		if (ConversationCanvas != null) {
			string assetPath = "Assets/Plugins/Node_Editor/Resources/Saves/" + ConversationCanvas.name + ".asset";
			NodeEditorFramework.NodeCanvas nodeCanvas = NodeEditorFramework.NodeEditorSaveManager.LoadNodeCanvas(assetPath);
			NodeEditorFramework.NodeEditor.RecalculateAll (nodeCanvas);

			ConversationManager.Instance.StartConversation (nodeCanvas);
			return;
		}
		#endif
		ConversationManager.Instance.StartConversation (ConversationText);

	}

	public override void SetOff () {
	}
}
