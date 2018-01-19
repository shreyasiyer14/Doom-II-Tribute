﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EntityComponent))]
public class PlayerComponent : Component {
	[Header("Player Physical Attributes")]
	[SerializeField] private float eyeHeight;
	[SerializeField] private float horizontalBob;
	[SerializeField] private float verticalBob;
	[SerializeField] private float stepSize;
	[SerializeField] private float turningFactor;
	public float sensitivity;

	private GameObject playerCamera;
	private Transform weaponTransform;
	private float mousePosX = 0.0f;
	private WeaponComponent weaponComp;

	void Start () {
		playerCamera = transform.GetChild (0).gameObject;
		playerCamera.transform.position += new Vector3 (0f, eyeHeight,0f);
		weaponTransform = playerCamera.transform.GetChild (0);
		weaponComp = transform.GetChild(0).GetChild(0).gameObject.GetComponent<WeaponComponent>();
	}
	
	void Update () {
		#region User-Mouse/Keyboard handling : For player/character's rotation.
		if (Input.GetAxis("Horizontal") != 0.0f) {
			mousePosX += Input.GetAxis("Horizontal");
			Quaternion rotation = Quaternion.Euler(0f, mousePosX * sensitivity, 0f);
			transform.rotation = rotation;
		}
		if (Input.GetKey (KeyCode.LeftArrow))
			transform.Rotate (new Vector3(0f, -Time.fixedDeltaTime * turningFactor, 0f));
		if (Input.GetKey (KeyCode.RightArrow))
			transform.Rotate (new Vector3(0f, Time.fixedDeltaTime * turningFactor, 0f));
		#endregion

		#region User-Keyboard handling : For player/character's translatory movement.
		if (Input.GetKey (KeyCode.W)) {
			transform.Translate (Vector3.forward * stepSize * Time.fixedDeltaTime);
			transform.position = new Vector3 (transform.position.x, eyeHeight + 0.5f * Mathf.Sin(Time.time * verticalBob), transform.position.z);
			weaponTransform.localPosition = new Vector3 (0.0f + 0.3f * Mathf.Sin(Time.time * horizontalBob/2f), -0.875f + 0.15f * Mathf.Cos(Time.time * horizontalBob), weaponTransform.localPosition.z);
		}

		if (Input.GetKey (KeyCode.S)) {
			transform.Translate (-Vector3.forward * stepSize * Time.fixedDeltaTime);
			transform.position = new Vector3 (transform.position.x, eyeHeight + 0.5f * Mathf.Sin(Time.time * verticalBob), transform.position.z);
			weaponTransform.localPosition = new Vector3 (0.0f + 0.3f * Mathf.Sin(Time.time * horizontalBob/2f), -0.875f + 0.15f * Mathf.Cos(Time.time * horizontalBob), weaponTransform.localPosition.z);
		}

		if (Input.GetKey (KeyCode.D)) {
			transform.Translate (Vector3.right * stepSize * Time.fixedDeltaTime);
			transform.position = new Vector3 (transform.position.x, eyeHeight + 0.5f * Mathf.Sin(Time.time * verticalBob), transform.position.z);
			weaponTransform.localPosition = new Vector3 (0.0f + 0.3f * Mathf.Sin(Time.time * horizontalBob/2f), -0.875f + 0.15f * Mathf.Cos(Time.time * horizontalBob), weaponTransform.localPosition.z);
		}

		if (Input.GetKey (KeyCode.A)) {
			transform.Translate (-Vector3.right * stepSize * Time.fixedDeltaTime);
			transform.position = new Vector3 (transform.position.x, eyeHeight + 0.5f * Mathf.Sin(Time.time * verticalBob), transform.position.z);
			weaponTransform.localPosition = new Vector3 (0.0f + 0.3f * Mathf.Sin(Time.time * horizontalBob/2f), -0.875f + 0.15f * Mathf.Cos(Time.time * horizontalBob), weaponTransform.localPosition.z);
		}

		if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D)) {
			transform.position = new Vector3(transform.position.x, Mathf.Lerp (transform.position.y, eyeHeight, 0.5f), transform.position.z);
			weaponTransform.localPosition = new Vector3 (Mathf.Lerp(weaponTransform.localPosition.x, 0.0f, 0.5f), Mathf.Lerp(weaponTransform.localPosition.y, -0.85f, 0.5f), weaponTransform.localPosition.z);
		}
		#endregion

		#region User-Mouse click events : For shooting/firing the weapon.
		if (Input.GetMouseButton (0)) {
			GeneralEventSystem.send (new WeaponFireEvent(weaponComp), 1);
		} else {
			GeneralEventSystem.send (new WeaponFireEvent(weaponComp), 0);
		}
		#endregion
	}
}
