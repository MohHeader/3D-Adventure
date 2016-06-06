using UnityEngine;
using System.Collections;
using NodeEditorFramework;
using NodeEditorFramework.Utilities;

[System.Serializable]
[Node (false, "Standard/Conversation/Entry")]
public class EntryNode : Node 
{
	public string Name;
	public string Value;

	public const string ID = "entryNode";
	public override string GetID { get { return ID; } }

	public override Node Create (Vector2 pos) 
	{ // This function has to be registered in Node_Editor.ContextCallback
		EntryNode node = CreateInstance <EntryNode> ();

		node.name = "Conversation Entry";
		node.rect = new Rect (pos.x, pos.y, 250, 100);;

		NodeOutput.Create (node, "OutPut", "Flow", NodeSide.Bottom, 125);
		NodeInput.Create  (node, "InPut", "Flow", NodeSide.Top, 125);

		return node;
	}

	protected internal override void NodeGUI () 
	{
		Name = RTEditorGUI.TextField (new GUIContent ("Name"), Name);
		Value = RTEditorGUI.TextField (new GUIContent ("Value"), Value);

		if (GUI.changed)
			NodeEditor.RecalculateFrom (this);
	}

	public override bool Calculate () {
		return true;
	}
}