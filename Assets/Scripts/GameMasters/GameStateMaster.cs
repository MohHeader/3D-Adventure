using UnityEngine;
using System.Collections;

public enum GameState{
	Normal,
	Conversation,
	Fight,
	Win
}

public class GameStateMaster : Singleton<GameStateMaster> {
	public GameState State { get; protected set; }

	//Guarantee this will always be a singleton only – 
	//can't use the constructor!
	protected GameStateMaster(){}

	void Awake(){
		Reset ();
	}

	public void Reset(){
		SetState(GameState.Normal);
	}

	public void SetState(GameState state){
		State = state;
		if (OnStateChange != null)
			OnStateChange (state);
	}

	public bool IsPlayable(){
		// Check what States the game is playable ( i.e. the user can interact with it, and move the characcter for example )
		return State == GameState.Fight || State == GameState.Normal;
	}

	public event System.Action<GameState> OnStateChange;
}
