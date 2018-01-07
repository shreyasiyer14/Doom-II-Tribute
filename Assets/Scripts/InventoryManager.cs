using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventoryManager : EventSystem {
	public static List<Weapon> playerInventory = new List <Weapon> ();
	public static int currentWeaponSlot = 0;

	public static void send (AbstractIntEvent incomingEvent, int newSlot) {
		currentWeaponSlot = newSlot;
		incomingEvent.Invoke (newSlot);
	}
}
