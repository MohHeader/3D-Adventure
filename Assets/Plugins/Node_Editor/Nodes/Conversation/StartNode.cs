using UnityEngine;
using System.Collections;
using NodeEditorFramework;
using NodeEditorFramework.Utilities;

[System.Serializable]
[Node (false, "Standard/Conversation/Start")]
public class StartNode : Node 
{
	public const string ID = "startNode";
	public override string GetID { get { return ID; } }

	public override Node Create (Vector2 pos) 
	{ // This function has to be registered in Node_Editor.ContextCallback
		StartNode node = CreateInstance <StartNode> ();

		node.name = "Start Conversation";
		node.rect = new Rect (pos.x, pos.y, 50, 50);;

		NodeOutput.Create (node, "OutPut", "Flow", NodeSide.Bottom, 25);

		return node;
	}

	protected internal override void NodeGUI () 
	{
	}

	public override bool Calculate () 
	{
		return true;
	}
}