using UnityEngine;
using System.Collections;

public abstract class TriggerAction : MonoBehaviour {
	public abstract void SetOn(ActionTrigger trigger);
	public abstract void SetOff();
}
