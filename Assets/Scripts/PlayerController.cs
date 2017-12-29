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
		if (Input.GetKey (KeyCode.LeftArrow))
			transform.Rotate (new Vector3(0f, -Time.fixedDeltaTime * 50f, 0f));
		if (Input.GetKey (KeyCode.RightArrow))
			transform.Rotate (new Vector3(0f, Time.fixedDeltaTime * 50f, 0f));
		
		if (Input.GetKey (KeyCode.W)) {
			transform.Translate (Vector3.forward * stepSize * Time.fixedDeltaTime);
		}

		if (Input.GetKey (KeyCode.S)) {
			transform.Translate (-Vector3.forward * stepSize * Time.fixedDeltaTime);
		}

		if (Input.GetKey (KeyCode.D)) {
			transform.Translate (Vector3.right * stepSize * Time.fixedDeltaTime);
		}

		if (Input.GetKey (KeyCode.A)) {
			transform.Translate (-Vector3.right * stepSize * Time.fixedDeltaTime);
		}
	}
}
