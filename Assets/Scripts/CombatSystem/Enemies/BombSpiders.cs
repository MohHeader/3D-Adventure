using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(MoveToward))]
public class BombSpiders : Enemy {
	// BombSpiders will attack the Player by moving toward him & explode on contact

	public override void SetTarget(Player player){
		GetComponent<MoveToward> ().Target = player.transform;
		GetComponent<Health> ().Reset ();
	}
}
