using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponComponent : MonoBehaviour {
	public Weapon currentWeapon;

	private Animator anim;

	void Start () {
		anim = GetComponent<Animator> ();
		anim.enabled = false;
		GetComponent<SpriteRenderer> ().sprite = currentWeapon.mainSprite;
	}

	public void onFireEvent (int isFiring) {
		if (isFiring == 1) {
			anim.enabled = true;
			anim.SetTrigger (currentWeapon.fireAnimation.name);
		} else {
			if (anim.enabled)
				anim.enabled = false;
		}
		GetComponent<SpriteRenderer> ().sprite = currentWeapon.mainSprite;
	}

	public void onWeaponChangeEvent (int slotChange) {
		currentWeapon = InventoryManager.playerInventory [slotChange];
		GetComponent<SpriteRenderer> ().sprite = currentWeapon.mainSprite;
	}
}