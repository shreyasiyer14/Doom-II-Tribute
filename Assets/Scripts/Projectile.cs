using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
	[SerializeField] private float damage;
	[SerializeField] private float speed;

	private Animator anim;

	void Awake () {
		anim = transform.GetChild (0).gameObject.GetComponent<Animator> ();
		Destroy (gameObject, 15f);
		InvokeRepeating ("ProjectileTranslation", 0.05f, 0.2f);
	}

	void ProjectileTranslation () {
		transform.GetChild (0).LookAt (Camera.main.transform);
		transform.Translate (Vector3.forward * speed * Time.fixedDeltaTime * speed/5.0f);
		if (Vector3.Distance (Camera.main.transform.position, transform.position) <= 10.0f) {
			anim.SetBool (anim.GetParameter(0).name, true);
			Destroy (gameObject, 2f);
		}
	}
}
