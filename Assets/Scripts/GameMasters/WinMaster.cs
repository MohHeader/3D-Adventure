using UnityEngine;
using System.Collections;

public class WinMaster : MonoBehaviour {

	void Awake(){
		GameStateMaster.Instance.OnStateChange += CheckWinState;
	}

	void OnDestroy(){
		if(GameStateMaster.Instance != null)
			GameStateMaster.Instance.OnStateChange -= CheckWinState;
	}

	void CheckWinState(GameState state){
		if(state == GameState.Win){
			HintUI.Instance.SetText("You Won !! Perfect", gameObject);
		}
	}
}
