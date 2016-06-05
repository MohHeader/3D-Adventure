using UnityEngine;
using System.Collections;

public class WinMaster : MonoBehaviour {

	void Awake(){
		GameStateMaster.Instance.OnStateChange += CheckState;
	}

	void OnDestroy(){
		if(GameStateMaster.Instance != null)
			GameStateMaster.Instance.OnStateChange -= CheckState;
	}

	void CheckState(GameState state){
		if(state == GameState.Win){
			HintUI.SetText("You Won !! Perfect", gameObject.GetInstanceID());
		}
	}
}
