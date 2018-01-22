using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponComponent : MonoBehaviour {
	public Weapon currentWeapon;

	private Animator anim;
	private Animator fireAdditionalAnim;

	void Start () {
		anim = GetComponent<Animator> ();
		fireAdditionalAnim = transform.GetChild (0).GetComponent<Animator> ();
		fireAdditionalAnim.enabled = false;
		anim.enabled = false;
		GetComponent<SpriteRenderer> ().sprite = currentWeapon.mainSprite;
	}

	public void onFireEvent (int isFiring) {
		if (isFiring == 1) {
			anim.enabled = true;
	
			anim.SetTrigger (currentWeapon.fireAnimation.name);

			if (currentWeapon.fireAdditionalAnimation != null) {
				fireAdditionalAnim.enabled = true;
				fireAdditionalAnim.SetTrigger (currentWeapon.fireAdditionalAnimation.name);
			}
		} else {
			if (anim.enabled) {
				anim.enabled = false;
				fireAdditionalAnim.enabled = false;
			}
		}
		GetComponent<SpriteRenderer> ().sprite = currentWeapon.mainSprite;
	}

	public void onWeaponChangeEvent (int slotChange) {
		currentWeapon = InventoryManager.playerInventory [slotChange];
		GetComponent<SpriteRenderer> ().sprite = currentWeapon.mainSprite;
	}
}