using UnityEngine;
using System.Collections;

public class MoveToward : MonoBehaviour {
	public Transform 	Target;
	public float 		Speed = 5;
	
	// Update is called once per frame
	void Update () {
		if (Target == null)
			return;

		transform.position += (Target.position - transform.position).normalized * Speed * Time.deltaTime;
	}
}
