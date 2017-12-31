using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : Component {
	[SerializeField] private float damage;
	[SerializeField] private float speed;

	private bool explodedToPlayer = false;
	private Animator anim;
	private Transform player;
	private Transform sprite;

	void Awake () {
		anim = transform.GetChild (0).gameObject.GetComponent<Animator> ();
		player = Camera.main.transform;
		sprite = transform.GetChild (0);

		InvokeRepeating ("ProjectileTranslation", 0.05f, 0.2f);
		Destroy (gameObject, 15f);
	}

	void ProjectileTranslation () {
		sprite.LookAt (player);
		transform.Translate (Vector3.forward * speed * Time.fixedDeltaTime * speed/5.0f);
		ProximityCheck ();
		return;
	}

	void ProximityCheck () {
		if (Vector3.Distance (player.position, transform.position) <= 10.0f) {
			anim.SetBool (anim.GetParameter(0).name, true);
			explodedToPlayer = true;

			GameObject playerParentObject = player.parent.gameObject;
			DamageAuthoritySystem.send (new DoDamageEvent(gameObject, playerParentObject, playerParentObject.GetComponent<HealthComponent>()), damage);	

			Destroy (gameObject, 0.5f);
		}
		return;
	}
}
