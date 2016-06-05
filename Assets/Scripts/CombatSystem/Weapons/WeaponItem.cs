using UnityEngine;

[CreateAssetMenu()]
public class WeaponItem : InventoryItem {
	public float 	DamageAmount;		// The damage inflicted by each hit.
	public float 	Range;				// The distance the weapon can fire.
	public float	CoolDownTime;		// The time between each hit.
}
