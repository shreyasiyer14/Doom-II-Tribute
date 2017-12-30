using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
	[SerializeField] private float damage;
	[SerializeField] private float speed;

	void Awake () {
		Destroy (gameObject, 50f);
		InvokeRepeating ("ProjectileTranslation", 0.05f, 0.2f);
	}

	void ProjectileTranslation () {
		transform.GetChild (0).LookAt (Camera.main.transform);
		transform.Translate (Vector3.forward * speed * Time.fixedDeltaTime * speed/5.0f);		
	}
}
