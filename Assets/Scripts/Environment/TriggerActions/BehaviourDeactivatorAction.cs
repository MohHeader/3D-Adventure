using UnityEngine;
using System.Collections;

public class BehaviourDeactivatorAction : TriggerAction {
	// As some Behaviours are temporary needed, ( Like some Hint messages ) we may need to Disable them after their main usage.
	// Here we are disabling them and not destroying them, as we may need to re-enable them later

	public MonoBehaviour[] Behaviours; // List of Behaviours to set enabled = false || true

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
