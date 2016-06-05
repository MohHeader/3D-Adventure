using UnityEngine;
using System.Collections;

public class EquipWeaponAction : TriggerAction {
	public WeaponItem Weapon;
	public override void SetOn (ActionTrigger trigger) {
		GameObject.FindObjectOfType<PlayerShooting> ().Weapon = Weapon;
	}

	public override void SetOff () {
	}
}
