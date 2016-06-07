using UnityEngine;
using System.Collections;

public abstract class TriggerAction : MonoBehaviour {
	// Abstract class so all Actions that will be triggered by ActionTrigger to inherit from.

	public abstract void SetOn(ActionTrigger trigger);
	public abstract void SetOff();
}
