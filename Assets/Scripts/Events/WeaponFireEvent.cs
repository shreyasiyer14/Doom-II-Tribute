using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFireEvent : AbstractIntEvent {
	public WeaponComponent weaponComp;

	public WeaponFireEvent (WeaponComponent weaponComp) {
		this.weaponComp = weaponComp;

		this.AddListener (weaponComp.onFireEvent);
	}
}
