﻿using UnityEngine;
using System.Collections;

public enum GameState{
	Move,
	Conversation,
	Fight
}

public class GameStateMaster : Singleton<GameStateMaster> {
	public GameState State { get; protected set; }

	//Guarantee this will always be a singleton only – 
	//can't use the constructor!
	protected GameStateMaster(){}

	public void SetState(GameState state){
		State = state;
		if (OnStateChange != null)
			OnStateChange (state);
	}

	public bool IsMovable(){
		return State == GameState.Fight || State == GameState.Move;
	}

	public event System.Action<GameState> OnStateChange;
}
