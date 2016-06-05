using UnityEngine;
using System.Collections;

public class BehaviourDeactivatorAction : TriggerAction {
	public MonoBehaviour[] Behaviours;
	public override void SetOn (ActionTrigger trigger) {
		foreach (var behaviour in Behaviours) {
			behaviour.enabled = false;
		}
	}

	public override void SetOff () {
		foreach (var behaviour in Behaviours) {
			behaviour.enabled = true;
		}
	}
}
