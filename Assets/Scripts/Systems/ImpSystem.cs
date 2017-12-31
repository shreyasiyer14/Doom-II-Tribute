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
		foreach (GameObject impEntity in EntityManager.instance.getObjectsOfType<ImpComponent>()) {
			if (impEntity.GetComponent<ImpComponent> ().sprite == null)
				impEntity.GetComponent<ImpComponent> ().sprite = impEntity.transform.GetChild (0);
			impEntity.GetComponent<ImpComponent> ().sprite.LookAt (player);

			Animator anim = impEntity.GetComponent<ImpComponent> ().sprite.GetComponent<Animator> ();
			float sign = GetRotateDirection (impEntity, player);
			float transAng = AngleBetweenTransforms (impEntity, player);

			impEntity.GetComponent<ImpComponent> ().spriteCode = ChangeSpriteCode (sign, transAng);
			ResetAllParams (anim, impEntity.GetComponent<ImpComponent> ().spriteCode);

			if (impEntity.GetComponent<ImpComponent>().spriteCode == NPCComponent.Direction.BackwardRight || impEntity.GetComponent<ImpComponent>().spriteCode == NPCComponent.Direction.ForwardRight || impEntity.GetComponent<ImpComponent>().spriteCode == NPCComponent.Direction.Right) {
				if (DistanceWithPlayer (impEntity, player) <= impEntity.GetComponent<ImpComponent>().searchRadius) {
					anim.SetBool (anim.GetParameter (Array.IndexOf (Enum.GetValues (impEntity.GetComponent<ImpComponent>().spriteCode.GetType ()), impEntity.GetComponent<ImpComponent>().spriteCode) + 7).name, true);
					anim.SetBool (anim.GetParameter (Array.IndexOf (Enum.GetValues (impEntity.GetComponent<ImpComponent>().spriteCode.GetType ()), impEntity.GetComponent<ImpComponent>().spriteCode) - 1).name, false);
					impEntity.transform.rotation = impEntity.GetComponent<ImpComponent>().sprite.rotation;
					if (!impEntity.GetComponent<ImpComponent>().IsInvoking())
						impEntity.GetComponent<ImpComponent>().InvokeRepeating ("AttackEntity", 0f, 1f);
				} else {
					anim.SetBool (anim.GetParameter (Array.IndexOf (Enum.GetValues (impEntity.GetComponent<ImpComponent>().spriteCode.GetType ()), impEntity.GetComponent<ImpComponent>().spriteCode) - 1).name, true);
					anim.SetBool (anim.GetParameter (Array.IndexOf (Enum.GetValues (impEntity.GetComponent<ImpComponent>().spriteCode.GetType ()), impEntity.GetComponent<ImpComponent>().spriteCode) + 7).name, false);
					impEntity.GetComponent<ImpComponent>().CancelInvoke ();
				}
				impEntity.GetComponent<ImpComponent>().sprite.GetComponent<SpriteRenderer> ().flipX = true;
			} else {
				if (DistanceWithPlayer (impEntity, player) <= impEntity.GetComponent<ImpComponent>().searchRadius) {
					anim.SetBool (anim.GetParameter (Array.IndexOf (Enum.GetValues (impEntity.GetComponent<ImpComponent>().spriteCode.GetType ()), impEntity.GetComponent<ImpComponent>().spriteCode) + 8).name, true);
					anim.SetBool (anim.GetParameter (Array.IndexOf (Enum.GetValues (impEntity.GetComponent<ImpComponent>().spriteCode.GetType ()), impEntity.GetComponent<ImpComponent>().spriteCode)).name, false);
					impEntity.transform.rotation = impEntity.GetComponent<ImpComponent>().sprite.rotation;
					if (!impEntity.GetComponent<ImpComponent>().IsInvoking())
						impEntity.GetComponent<ImpComponent>().InvokeRepeating ("AttackEntity", 0f, 1f);
				} else {
					anim.SetBool (anim.GetParameter (Array.IndexOf (Enum.GetValues (impEntity.GetComponent<ImpComponent>().spriteCode.GetType ()), impEntity.GetComponent<ImpComponent>().spriteCode)).name, true);
					anim.SetBool (anim.GetParameter (Array.IndexOf (Enum.GetValues (impEntity.GetComponent<ImpComponent>().spriteCode.GetType ()), impEntity.GetComponent<ImpComponent>().spriteCode) + 8).name, false);
					impEntity.GetComponent<ImpComponent>().CancelInvoke ();
				}
				impEntity.GetComponent<ImpComponent>().sprite.GetComponent<SpriteRenderer> ().flipX = false;
			}
		}
	}

	private void ResetAllParams (Animator anim, NPCComponent.Direction spriteCode) {
		foreach (NPCComponent.Direction param in NPCComponent.parameterList) {
			if (param != spriteCode) {
				anim.SetBool (anim.GetParameter (Array.IndexOf (Enum.GetValues (param.GetType ()), param)).name, false);
				anim.SetBool (anim.GetParameter (Array.IndexOf (Enum.GetValues (param.GetType ()), param) + 8).name, false);
			}
		}
		return;
	}
}
