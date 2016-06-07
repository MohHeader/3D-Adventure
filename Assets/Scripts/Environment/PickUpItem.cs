using UnityEngine;
using System.Collections;

public class PickUpItem : MonoBehaviour {
	public InventoryItem Item;

	void OnTriggerEnter(Collider other){
		Inventory inventory = other.GetComponent<Inventory> ();
		if(inventory != null){
			if(inventory.AddItem(Item)){
				HintUI.Instance.SetText ("You got a new Item : " + Item.ItemName);
				Destroy(gameObject);
			}
		}
	}
}
