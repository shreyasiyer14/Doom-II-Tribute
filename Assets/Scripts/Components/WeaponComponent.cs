using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponComponent : MonoBehaviour {
	public Weapon currentWeapon;

	private Animator anim;
	private Sprite weaponSprite;

	void Start () {
		anim = GetComponent<Animator> ();
		GetComponent<SpriteRenderer> ().sprite = currentWeapon.mainSprite;
		weaponSprite = currentWeapon.mainSprite;
	}

	public void onFireEvent (int isFiring) {
		if (isFiring == 1)
			anim.SetTrigger (currentWeapon.fireAnimation.name);
		else
			anim.ResetTrigger (currentWeapon.fireAnimation.name);
	}

	public void onWeaponChangeEvent (int slotChange) {
		currentWeapon = InventoryManager.playerInventory [slotChange];
		weaponSprite = currentWeapon.mainSprite;
	}
}