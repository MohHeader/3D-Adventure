using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameMaster : Singleton<GameMaster> {

	protected GameMaster(){}

	public void Restart(){
		GameStateMaster.Instance.SetState (GameState.Normal);
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
	}
}
