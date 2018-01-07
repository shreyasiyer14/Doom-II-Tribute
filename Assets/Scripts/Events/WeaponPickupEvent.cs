using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickupEvent : AbstractEntityEvent {
	public WeaponComponent weaponComp;

	public WeaponPickupEvent (GameObject entity, WeaponComponent weaponComp) {
		this.weaponComp = weaponComp;

		//this.AddListener (weaponComp.onFireEvent);
	}
}
