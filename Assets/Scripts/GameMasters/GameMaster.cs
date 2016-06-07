using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public static class GameMaster {
	public static Player CurrentPlayer;			// Reference to Current Player

	public static void Restart(){
		GameStateMaster.Instance.Reset();
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
	}
}
