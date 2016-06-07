using UnityEngine;
using System.Collections;

public class SetGameStateAction : TriggerAction {
	public GameState State;

	public override void SetOn (ActionTrigger trigger){
		GameStateMaster.Instance.SetState (State);
	}

	public override void SetOff (){
	}
}
