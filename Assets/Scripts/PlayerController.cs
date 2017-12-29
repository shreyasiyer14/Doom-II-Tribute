using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	[Header("Player Physical Attributes")]
	[SerializeField] private float eyeHeight;
	[SerializeField] private float horizontalBob;
	[SerializeField] private float verticalBob;
	[SerializeField] private float stepSize;

	public Transform testObj;

	private GameObject playerCamera;

	void Start () {
		playerCamera = transform.GetChild (0).gameObject;
		playerCamera.transform.position += new Vector3 (0f, eyeHeight,0f);
	}
	
	void Update () {
		transform.LookAt (testObj);
		transform.RotateAround (testObj.position, Vector3.up, 10f * Time.fixedDeltaTime);
		if (Input.GetKey (KeyCode.W)) {
			transform.Translate (transform.forward * stepSize * Time.fixedDeltaTime);
		}

		if (Input.GetKey (KeyCode.S)) {
			transform.Translate (-transform.forward * stepSize * Time.fixedDeltaTime);
		}

		if (Input.GetKey (KeyCode.D)) {
			transform.Translate (transform.right * stepSize * Time.fixedDeltaTime);
		}

		if (Input.GetKey (KeyCode.A)) {
			transform.Translate (-transform.right * stepSize * Time.fixedDeltaTime);
		}
	}
}
