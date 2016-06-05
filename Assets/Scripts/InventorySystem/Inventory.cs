using UnityEngine;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {
	public int					Capacity;
	public List<InventoryItem>	Items;

	public bool HasItem(string name){
		foreach (var item in Items) {
			if (item.ItemName == name)
				return true;
		}

		return false;
	}

	public bool AddItem(InventoryItem item){
		if (Items.Count >= Capacity)
			return false;

		Items.Add (item);
		return true;
	}
}
