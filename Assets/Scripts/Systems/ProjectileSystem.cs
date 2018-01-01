using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSystem : MonoBehaviour, EventSystem {
	private Transform player;
	// Use this for initialization
	void Start () {
		player = Camera.main.transform;
	}
	
	// Update is called once per frame
	void Update () {
		foreach (GameObject projectileEntity in EntityManager.getObjectsOfType<ProjectileComponent>()) {
			ProjectileComponent projectileComp = projectileEntity.GetComponent<ProjectileComponent> ();

			Transform sprite = projectileEntity.transform.GetChild (0);
			Animator anim = sprite.GetComponent<Animator> ();

			if (projectileComp.sprite == null)
				projectileComp.sprite = sprite;
			if (projectileComp.player == null)
				projectileComp.player = player;
			if (projectileComp.entity == null)
				projectileComp.entity = projectileEntity;

			if (!projectileComp.IsInvoking())
				projectileComp.InvokeRepeating ("ProjectileTranslation", 0.05f, 0.2f);

			ProximityCheck (projectileEntity, anim);
		}
	}

	void ProximityCheck (GameObject projectile, Animator anim) {
		if (Vector3.Distance (player.position, projectile.transform.position) <= 10.0f) {
			anim.SetBool (anim.GetParameter(0).name, true);

			GameObject playerParentObject = player.parent.gameObject;
			DamageAuthoritySystem.send (new DoDamageEvent(projectile, playerParentObject, playerParentObject.GetComponent<HealthComponent>()), projectile.GetComponent<ProjectileComponent>().damage);	

			Destroy (projectile, 0.5f);
		}
		return;
	}
}
