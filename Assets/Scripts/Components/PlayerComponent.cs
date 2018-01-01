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
	private float mousePosX = 0.0f;

	void Start () {
		playerCamera = transform.GetChild (0).gameObject;
		playerCamera.transform.position += new Vector3 (0f, eyeHeight,0f);
	}
	
	void Update () {
		#region User-Mouse/Keyboard handling : For player/character's rotation.
		mousePosX += Input.GetAxis("Horizontal");
		Quaternion rotation = Quaternion.Euler(0f, mousePosX * sensitivity, 0f);
		transform.rotation = rotation;

		if (Input.GetKey (KeyCode.LeftArrow))
			transform.Rotate (new Vector3(0f, -Time.fixedDeltaTime * turningFactor, 0f));
		if (Input.GetKey (KeyCode.RightArrow))
			transform.Rotate (new Vector3(0f, Time.fixedDeltaTime * turningFactor, 0f));
		#endregion

		#region User-Keyboard handling : For player/character's translatory movement.
		if (Input.GetKey (KeyCode.W)) {
			transform.Translate (Vector3.forward * stepSize * Time.fixedDeltaTime);
			transform.position = new Vector3 (transform.position.x, eyeHeight + 0.5f * Mathf.Sin(Time.time * verticalBob), transform.position.z);
		}

		if (Input.GetKey (KeyCode.S)) {
			transform.Translate (-Vector3.forward * stepSize * Time.fixedDeltaTime);
			transform.position = new Vector3 (transform.position.x, eyeHeight + 0.5f * Mathf.Sin(Time.time * verticalBob), transform.position.z);
		}

		if (Input.GetKey (KeyCode.D)) {
			transform.Translate (Vector3.right * stepSize * Time.fixedDeltaTime);
			transform.position = new Vector3 (transform.position.x, eyeHeight + 0.5f * Mathf.Sin(Time.time * verticalBob), transform.position.z);
		}

		if (Input.GetKey (KeyCode.A)) {
			transform.Translate (-Vector3.right * stepSize * Time.fixedDeltaTime);
			transform.position = new Vector3 (transform.position.x, eyeHeight + 0.5f * Mathf.Sin(Time.time * verticalBob), transform.position.z);
		}

		if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
			transform.position = new Vector3(transform.position.x, Mathf.Lerp (transform.position.y, eyeHeight, 0.5f), transform.position.z);
		#endregion
	}
}