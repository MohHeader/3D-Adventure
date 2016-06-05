using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : TriggerAction {
	public Transform[]		SpawnPositions;
	public Enemy			EnemyPrefab;
	public List<Enemy>	Enemies;
	public int				MaxConcurrentEmenies;

	bool m_IsOn;

	public override void SetOn (ActionTrigger trigger) {
		m_IsOn = true;
		StartCoroutine ("Spawn");
	}

	public override void SetOff () {
		m_IsOn = false;

		foreach (var enemy in Enemies) {
			if (enemy != null)
				SimplePool.Despawn (enemy.gameObject);
		}
	}

	IEnumerator Spawn(){
		while (m_IsOn) {
			if(MaxConcurrentEmenies <= 0 || Enemies.Count < MaxConcurrentEmenies){
				Vector3 pos = SpawnPositions [Random.Range (0, SpawnPositions.Length)].position;
				GameObject GO = SimplePool.Spawn (EnemyPrefab.gameObject, pos, Quaternion.identity);
				Enemy enemy = GO.GetComponent<Enemy> ();

				enemy.SetTarget (GameMaster.Instance.CurrentPlayer);

				Enemies.Add (enemy);

				enemy.OnDeath += delegate() {
					if(Enemies.Contains(enemy))
						Enemies.Remove(enemy);
				};
			}
			yield return new WaitForSeconds (Random.Range (1f, 2.5f));
		}
	}
}
