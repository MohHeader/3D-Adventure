using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Health))]
public class Mine : Enemy {
	// Mines are static bombs on ground, that will explode on touch

	public override void SetTarget(Player player){
		GetComponent<Health> ().Reset ();
	}
}
