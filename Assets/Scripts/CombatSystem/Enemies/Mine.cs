using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Health))]
public class Mine : Enemy {
	public override void SetTarget(Player player){
		GetComponent<Health> ().Reset ();
	}
}
