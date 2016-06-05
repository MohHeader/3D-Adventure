using UnityEngine;
using System.Collections;

public class WinMaster : MonoBehaviour {

	void Awake(){
		GameStateMaster.Instance.OnStateChange += delegate(GameState state) {
			if(state == GameState.Win){
				HintUI.SetText("You Won !! Perfect", gameObject.GetInstanceID());
			}
		};
	}
}
