using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponComponent : MonoBehaviour {
	public Weapon currentWeapon;
	private Animator anim;

	void Start () {
		anim = GetComponent<Animator> ();
		GetComponent<SpriteRenderer> ().sprite = currentWeapon.mainSprite;
	}

	public void onFireEvent (int isFiring) {
		if (isFiring == 1) {	
			anim.Play (currentWeapon.fireAnimation.name);
		}
		GetComponent<SpriteRenderer> ().sprite = currentWeapon.mainSprite;
	}

	public void onWeaponChangeEvent (int slotChange) {
		currentWeapon = InventoryManager.playerInventory [slotChange];
		GetComponent<SpriteRenderer> ().sprite = currentWeapon.mainSprite;
	}
}