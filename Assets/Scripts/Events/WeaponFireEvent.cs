using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFireEvent : AbstractEntityEvent {
	public WeaponComponent weaponComp;

	public WeaponFireEvent (GameObject entity, WeaponComponent weaponComp) {
		this.entity = entity;
		this.weaponComp = weaponComp;

		this.AddListener (weaponComp.onFireEvent);
	}
}
