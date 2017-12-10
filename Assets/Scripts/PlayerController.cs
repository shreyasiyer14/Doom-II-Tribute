using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour {

	[SerializeField] private int vertAngleIndex;

	private Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetFloat (anim.GetParameter(vertAngleIndex).nameHash, 48.0f * Input.mousePosition.y/Screen.height);
	}
}
