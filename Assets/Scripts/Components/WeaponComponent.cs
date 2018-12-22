using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponComponent : MonoBehaviour {
	public Weapon currentWeapon;
	private Animator anim;
	public enum WeaponIndex {
		PISTOL,
		SHOTGUN,
		CHAINSAW
	};

	public WeaponIndex currentWeaponIndex;

	void Start () {
		anim = GetComponent<Animator> ();
		GetComponent<SpriteRenderer> ().sprite = currentWeapon.mainSprite;
		currentWeaponIndex = WeaponIndex.PISTOL;
	}

	public void onFireEvent (int isFiring) {
		if (isFiring == 1) {	
			anim.Play (currentWeapon.fireAnimation.name);
		} else {
			anim.SetInteger("CurrentWeaponIndex", (int)currentWeaponIndex);
		}
		GetComponent<SpriteRenderer> ().sprite = currentWeapon.mainSprite;
	}

	public void onWeaponChangeEvent (int slotChange) {
		currentWeapon = InventoryManager.playerInventory [slotChange];
		WeaponIndex[] weaponIndices = (WeaponIndex[]) System.Enum.GetValues(currentWeaponIndex.GetType());
		currentWeaponIndex = weaponIndices[slotChange];
		GetComponent<SpriteRenderer> ().sprite = currentWeapon.mainSprite;
	}
}