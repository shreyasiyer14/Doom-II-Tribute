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
			transform.Rotate (new Vector3(0f, -Time.fixedDeltaTime * 100f, 0f));
		if (Input.GetKey (KeyCode.RightArrow))
			transform.Rotate (new Vector3(0f, Time.fixedDeltaTime * 100f, 0f));
		
		if (Input.GetKey (KeyCode.W)) {
			transform.Translate (Vector3.forward * stepSize * Time.fixedDeltaTime);
			transform.position = new Vector3 (transform.position.x, eyeHeight + Mathf.Sin(Time.time * verticalBob), transform.position.z);
		}

		if (Input.GetKey (KeyCode.S)) {
			transform.Translate (-Vector3.forward * stepSize * Time.fixedDeltaTime);
			transform.position = new Vector3 (transform.position.x, eyeHeight + Mathf.Sin(Time.time * verticalBob), transform.position.z);
		}

		if (Input.GetKey (KeyCode.D)) {
			transform.Translate (Vector3.right * stepSize * Time.fixedDeltaTime);
			transform.position = new Vector3 (transform.position.x, eyeHeight + Mathf.Sin(Time.time * verticalBob), transform.position.z);
		}

		if (Input.GetKey (KeyCode.A)) {
			transform.Translate (-Vector3.right * stepSize * Time.fixedDeltaTime);
			transform.position = new Vector3 (transform.position.x, eyeHeight + Mathf.Sin(Time.time * verticalBob), transform.position.z);
		}

		transform.position = new Vector3(transform.position.x, Mathf.Lerp (transform.position.y, eyeHeight, Time.deltaTime), transform.position.z);
	}
}
