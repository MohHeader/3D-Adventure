﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : TriggerAction {
	public Transform[]		SpawnPositions;
	public Enemy			EnemyPrefab;
	public int				MaxConcurrentEmenies;	// if Set to <= 0, will be treated as unlimited/Infinity

	bool			m_IsOn;
	List<Enemy>		m_CurrentEnemies;

	public override void SetOn (ActionTrigger trigger) {
		m_IsOn = true;
		StartCoroutine ("Spawn");
	}

	public override void SetOff () {
		m_IsOn = false;

		foreach (var enemy in m_CurrentEnemies) {
			if (enemy != null)
				SimplePool.Despawn (enemy.gameObject);
		}
	}

	IEnumerator Spawn(){
		while (m_IsOn) {
			// Check if we have sapce to spawn new enemy based on MaxConcurrentEmenies
			if(MaxConcurrentEmenies <= 0 || m_CurrentEnemies.Count < MaxConcurrentEmenies){
				
				Vector3 pos = SpawnPositions [Random.Range (0, SpawnPositions.Length)].position; // Select Random position
				GameObject GO = SimplePool.Spawn (EnemyPrefab.gameObject, pos, Quaternion.identity); // Spawn from Object Pool
				Enemy enemy = GO.GetComponent<Enemy> ();

				enemy.SetTarget (GameMaster.CurrentPlayer);

				m_CurrentEnemies.Add (enemy);

				enemy.OnDeath += delegate() {
					if(m_CurrentEnemies.Contains(enemy))
						m_CurrentEnemies.Remove(enemy);
				};
			}
			yield return new WaitForSeconds (Random.Range (1f, 2.5f));
		}
	}
}
