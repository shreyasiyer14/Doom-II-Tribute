using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ImpSystem : NPCSystem {
	private Transform player;

	void Start () {
		player = Camera.main.transform;
	}
	// Update is called once per frame
	void Update () {
		foreach (GameObject impEntity in EntityManager.getObjectsOfType<ImpComponent>()) {
			ImpComponent impComponent = impEntity.GetComponent<ImpComponent> ();

			if (impComponent.sprite == null)
				impComponent.sprite = impEntity.transform.GetChild (0);
			impComponent.sprite.LookAt (player);

			Animator anim = impComponent.sprite.GetComponent<Animator> ();
			float sign = GetRotateDirection (impEntity, player);
			float transAng = AngleBetweenTransforms (impEntity, player);

			impComponent.spriteCode = ChangeSpriteCode (sign, transAng);
			ResetAllParams (anim, impComponent.spriteCode);

			if (impComponent.spriteCode == NPCComponent.Direction.BackwardRight || impComponent.spriteCode == NPCComponent.Direction.ForwardRight || impComponent.spriteCode == NPCComponent.Direction.Right) {
				if (DistanceWithPlayer (impEntity, player) <= impComponent.searchRadius) {
					anim.SetBool (anim.GetParameter (Array.IndexOf (Enum.GetValues (impComponent.spriteCode.GetType ()), impComponent.spriteCode) + 7).name, true);
					anim.SetBool (anim.GetParameter (Array.IndexOf (Enum.GetValues (impComponent.spriteCode.GetType ()), impComponent.spriteCode) - 1).name, false);
					impEntity.transform.rotation = impComponent.sprite.rotation;
					if (!impComponent.IsInvoking())
						impComponent.InvokeRepeating ("GenerateProjectile", 0f, 1f);
				} else {
					anim.SetBool (anim.GetParameter (Array.IndexOf (Enum.GetValues (impComponent.spriteCode.GetType ()), impComponent.spriteCode) - 1).name, true);
					anim.SetBool (anim.GetParameter (Array.IndexOf (Enum.GetValues (impComponent.spriteCode.GetType ()), impComponent.spriteCode) + 7).name, false);
					impComponent.CancelInvoke ();
				}
				impComponent.sprite.GetComponent<SpriteRenderer> ().flipX = true;
			} else {
				if (DistanceWithPlayer (impEntity, player) <= impComponent.searchRadius) {
					anim.SetBool (anim.GetParameter (Array.IndexOf (Enum.GetValues (impComponent.spriteCode.GetType ()), impComponent.spriteCode) + 8).name, true);
					anim.SetBool (anim.GetParameter (Array.IndexOf (Enum.GetValues (impComponent.spriteCode.GetType ()), impComponent.spriteCode)).name, false);
					impEntity.transform.rotation = impComponent.sprite.rotation;
					if (!impComponent.IsInvoking())
						impComponent.InvokeRepeating ("GenerateProjectile", 0f, 1f);
				} else {
					anim.SetBool (anim.GetParameter (Array.IndexOf (Enum.GetValues (impComponent.spriteCode.GetType ()), impComponent.spriteCode)).name, true);
					anim.SetBool (anim.GetParameter (Array.IndexOf (Enum.GetValues (impComponent.spriteCode.GetType ()), impComponent.spriteCode) + 8).name, false);
					impComponent.CancelInvoke ();
				}
				impComponent.sprite.GetComponent<SpriteRenderer> ().flipX = false;
			}
		}
	}

	private static void ResetAllParams (Animator anim, NPCComponent.Direction spriteCode) {
		foreach (NPCComponent.Direction param in NPCComponent.parameterList) {
			if (param != spriteCode) {
				anim.SetBool (anim.GetParameter (Array.IndexOf (Enum.GetValues (param.GetType ()), param)).name, false);
				anim.SetBool (anim.GetParameter (Array.IndexOf (Enum.GetValues (param.GetType ()), param) + 8).name, false);
			}
		}
		return;
	}
}
