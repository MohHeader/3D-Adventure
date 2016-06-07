using UnityEngine;
using System.Collections;

public class MoveToward : MonoBehaviour {
	
	public Transform 	Target;			// The transform that that our object will be moving toward it.
	public float 		Speed = 5;
	
	// Update is called once per frame
	void Update () {
		if (Target == null)
			return;

		Vector3 direction = (Target.position - transform.position).normalized;
		transform.position +=  direction * Speed * Time.deltaTime;
	}
}
