using UnityEngine;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {
	public int					Capacity;		// Maximun capacity the Inventory can hold.
	public List<InventoryItem>	Items;			// Items inide the Inventory

	public bool HasItem(string name){
		foreach (var item in Items) {
			if (item.ItemName == name)
				return true;
		}

		return false;
	}

	public bool AddItem(InventoryItem item){
		// Check if there are still a space in the Inventory to add new Item;
		if (Items.Count >= Capacity)
			return false;

		Items.Add (item);
		return true;
	}
}
