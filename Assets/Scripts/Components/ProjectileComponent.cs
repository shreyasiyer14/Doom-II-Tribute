using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileComponent : Component {
	public float damage;
	public float speed;

	[System.NonSerialized]
	public Transform player;
	[System.NonSerialized]
	public Transform sprite;

	void ProjectileTranslation () {
		sprite.LookAt (player);
		transform.Translate (Vector3.forward * speed * Time.fixedDeltaTime * speed/5.0f);
		return;
	}
}
