using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : TriggerAction {
	public Transform[] SpawnPositions;
	public GameObject EnemyPrefab;
	public List<GameObject> Enemies;

	bool m_IsOn;

	public override void SetOn (ActionTrigger trigger) {
		m_IsOn = true;
		StartCoroutine ("Spawn");
	}

	public override void SetOff () {
		m_IsOn = false;

		foreach (var enemy in Enemies) {
			if (enemy != null)
				Destroy (enemy);
		}
	}

	IEnumerator Spawn(){
		while (m_IsOn) {
			Vector3 pos = SpawnPositions [Random.Range (0, SpawnPositions.Length)].position;
			GameObject GO = Instantiate (EnemyPrefab, pos, Quaternion.identity) as GameObject;
			GO.GetComponent<MoveToward> ().Target = GameObject.FindGameObjectWithTag ("Player").transform;
			Enemies.Add (GO);
			yield return new WaitForSeconds (Random.Range (1f, 2.5f));
		}
	}
}
