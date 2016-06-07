using UnityEngine;
using System.Collections;

public class EquipWeaponAction : TriggerAction {
	public WeaponItem Weapon;

	public override void SetOn (ActionTrigger trigger) {
		GameMaster.CurrentPlayer.EquipWeapon (Weapon);
		HintUI.Instance.SetText ("Weapon equipped : " + Weapon.ItemName);
	}

	public override void SetOff () {
	}
}
