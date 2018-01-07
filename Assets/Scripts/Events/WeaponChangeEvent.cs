using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponChangeEvent : AbstractIntEvent {
	public WeaponComponent weaponComp;

	public WeaponChangeEvent (WeaponComponent weaponComp) {
		this.weaponComp = weaponComp;

		this.AddListener (weaponComp.onWeaponChangeEvent);
	}
}
