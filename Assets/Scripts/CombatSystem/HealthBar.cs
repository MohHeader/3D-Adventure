using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthBar : MonoBehaviour {
	public Image	HealthImageUI;
	public Health	PlayerHealth;

	// Use this for initialization
	void Awake () {
		if (PlayerHealth == null) {
			Debug.LogError ("Player Health is not assigned !");
			return;
		}

		PlayerHealth.OnHealthChange += UpdateHealth;
		GameStateMaster.Instance.OnStateChange += CheckState;

		CheckState (GameStateMaster.Instance.State);
	}

	void OnDestroy(){
		if(GameStateMaster.Instance != null)
			GameStateMaster.Instance.OnStateChange -= CheckState;
	}

	// Update is called once per frame
	void UpdateHealth () {
		if (PlayerHealth.MaxHealth == 0) {
			HealthImageUI.fillAmount = 0;
			Debug.LogError ("Player's Max Health is set to Zero !");
			return;
		}
		HealthImageUI.fillAmount = PlayerHealth.CurrentHealth / PlayerHealth.MaxHealth;
	}

	void CheckState(GameState state){
		if(state == GameState.Fight){
			gameObject.SetActive(true);
		}else{
			gameObject.SetActive(false);
		}
	}
}
