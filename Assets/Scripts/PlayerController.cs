using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	[Header("Player Physical Attributes")]
	[SerializeField] private float eyeHeight;
	[SerializeField] private float horizontalBob;
	[SerializeField] private float verticalBob;
	[SerializeField] private float stepSize;

	private GameObject playerCamera;

	void Start () {
		playerCamera = transform.GetChild (0).gameObject;
		playerCamera.transform.position += new Vector3 (0f, eyeHeight,0f);
	}
	
	void Update () {
		
	}
}
