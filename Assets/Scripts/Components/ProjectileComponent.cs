using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EntityComponent))]
public class ProjectileComponent : Component {
	public float damage;
	public float speed;

	[System.NonSerialized]
	public Transform player;
	[System.NonSerialized]
	public Transform sprite;
	[System.NonSerialized]
	public float divideFactor = 5.0f;

	void ProjectileTranslation () {
		sprite.LookAt (player);
		transform.Translate (Vector3.forward * speed * Time.fixedDeltaTime * speed/divideFactor);
		return;
	}
}
