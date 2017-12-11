using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class PlayerController : MonoBehaviour {
	[Header("Character Animator Parameters")]
	public int inputMagnitude;
	public int verticalMagnitude;
	public int horizontalMagnitude;
	public int walkStartAngle;
	public int walkStopAngle;
	public int shootIndex;
	public int isStopRU;
	public int isStopLU;
	public int horizAngle;
	public int vertAngle;
	public int isSprint;
	public int isVault;
	public int isReload;
	public int isSwitchWeapon;
	public int fireRateIndex;

//	[Header("Character Properties")]
//
//	public Transform playerCamera;
//
//	public float speed = 15f;
//	public float sensitivity = 1f;
//	public float yAimOffset;
//	public float xAimOffset;

	[Header("Character Action Status")]
	public bool isSprinting = false;
	public bool isReloading = false;

	private Animator anim;

	private bool walked = false;
	private bool walkedBack = false;
	private bool walkedLeft = false;
	private bool walkedRight = false;

	private bool isVaulting = false;

	void Start () {
		anim = GetComponent<Animator> ();
	}

	void OnApplicationFocus (bool focus) {

	}

	void Update () {
//		if (!GetComponent<Player> ().isDead) {
//			if (isCurrentApp)
//				yAimOffset += Input.GetAxis ("Vertical") * sensitivity;
//
//			if (Input.GetAxis ("Vertical") != previousYRot && !isSprinting && isCurrentApp) {
//				yAimOffset = Mathf.Clamp (yAimOffset, -50f, 50f);
//				anim.SetFloat (anim.GetParameter (vertAngle).nameHash, yAimOffset);
//				previousYRot = Input.GetAxis ("Vertical");
//			} 
//				
//			if (isCurrentApp && !isSprinting) {
//				Quaternion rotation = Quaternion.Euler (0f, playerCamera.GetComponent<PlayerCamera> ().currentX * sensitivity, 0);
//				transform.rotation = Quaternion.Lerp (transform.rotation, rotation, 0.3f);
//			} else if (isCurrentApp && isSprinting) {
//				transform.Rotate (0f, Input.GetAxis ("Horizontal") * sensitivity, 0f);
//			}
//			
		anim.SetFloat(anim.GetParameter(vertAngle).nameHash, 48.0f * Input.mousePosition.y/Screen.height);
			if (Input.GetKey (KeyCode.LeftShift) && !isVaulting) {
				anim.SetBool (anim.GetParameter (isSprint).nameHash, true);
				anim.SetFloat (anim.GetParameter (vertAngle).nameHash, 0.0f);
				isSprinting = true;
			} else if (!Input.GetKey (KeyCode.LeftShift) && isSprinting) {
				anim.SetBool (anim.GetParameter (isSprint).nameHash, false);
				isSprinting = false;
			}
			if (Input.GetKey (KeyCode.D) && !isSprinting && !isVaulting) {
				anim.SetFloat (anim.GetParameter (walkStartAngle).nameHash, 0.0f);
				anim.SetFloat (anim.GetParameter (inputMagnitude).nameHash, 1.0f);
				anim.SetFloat (anim.GetParameter (verticalMagnitude).nameHash, 1.0f);
				anim.SetBool (anim.GetParameter (isStopRU).nameHash, false);
				walked = true;
			} else if (!Input.GetKey (KeyCode.D) && walked) {
				if (!anim.GetCurrentAnimatorStateInfo (0).IsName ("Walking.WalkStops RU Blend Tree.Rifle_WalkFwdStart")) {
					anim.SetFloat (anim.GetParameter (walkStopAngle).nameHash, 0.0f);
					anim.SetFloat (anim.GetParameter (inputMagnitude).nameHash, 0.0f);
					if (!walkedBack && !walkedLeft && !walkedRight)
						anim.SetBool (anim.GetParameter (isStopRU).nameHash, true);			
					anim.SetFloat (anim.GetParameter (verticalMagnitude).nameHash, 0.0f);
					walked = false;
				}
			}

			if (Input.GetKey (KeyCode.A) && !isSprinting) {
				anim.SetFloat (anim.GetParameter (walkStartAngle).nameHash, 180.0f);
				anim.SetFloat (anim.GetParameter (inputMagnitude).nameHash, 1.0f);
				anim.SetFloat (anim.GetParameter (verticalMagnitude).nameHash, -1.0f);
				anim.SetBool (anim.GetParameter (isStopRU).nameHash, false);
				walkedBack = true;
			} else if (!Input.GetKey (KeyCode.A) && walkedBack) {
				if (!anim.GetCurrentAnimatorStateInfo (0).IsName ("Walking.WalkStops RU Blend Tree.Rifle_WalkBwdStart")) {
					anim.SetFloat (anim.GetParameter (walkStopAngle).nameHash, 180.0f);
					anim.SetFloat (anim.GetParameter (inputMagnitude).nameHash, 0.0f);
					if (!walked && !walkedLeft && !walkedRight)
						anim.SetBool (anim.GetParameter (isStopRU).nameHash, true);			
					anim.SetFloat (anim.GetParameter (verticalMagnitude).nameHash, 0.0f);
					walkedBack = false;
				}
			}

			if (Input.GetKey (KeyCode.S) && !isSprinting) {
				anim.SetFloat (anim.GetParameter (inputMagnitude).nameHash, 1.0f);
				anim.SetFloat (anim.GetParameter (horizontalMagnitude).nameHash, 1.0f);
				anim.SetFloat (anim.GetParameter (walkStartAngle).nameHash, 90.0f);
				anim.SetBool (anim.GetParameter (isStopRU).nameHash, false);			
				walkedRight = true;
			} else if (!Input.GetKey (KeyCode.S) && walkedRight) {
				if (!anim.GetCurrentAnimatorStateInfo (0).IsName ("Base Layer.Walking")) {
					anim.SetFloat (anim.GetParameter (walkStopAngle).nameHash, 90.0f);
					anim.SetFloat (anim.GetParameter (inputMagnitude).nameHash, 0.0f);
					if (!walkedBack && !walkedLeft && !walked) {
						anim.SetBool (anim.GetParameter (isStopRU).nameHash, true);		
					}
					anim.SetFloat (anim.GetParameter (horizontalMagnitude).nameHash, 0.0f);
					walkedRight = false;
				}
			}

			if (Input.GetKey (KeyCode.W) && !isSprinting) {
				anim.SetFloat (anim.GetParameter (inputMagnitude).nameHash, 1.0f);
				anim.SetFloat (anim.GetParameter (horizontalMagnitude).nameHash, -1.0f);
				anim.SetFloat (anim.GetParameter (walkStartAngle).nameHash, -90.0f);
				anim.SetBool (anim.GetParameter (isStopRU).nameHash, false);			
				walkedLeft = true;
			} else if (!Input.GetKey (KeyCode.W) && walkedLeft) {
				if (!anim.GetCurrentAnimatorStateInfo (0).IsName ("Walking.WalkStops RU Blend Tree.StopWalkLt.Rifle_StrafeLeftStop_RU")) {
					anim.SetFloat (anim.GetParameter (walkStopAngle).nameHash, -90.0f);
					anim.SetFloat (anim.GetParameter (inputMagnitude).nameHash, 0.0f);
					if (!walkedBack && !walked && !walkedRight) {
						anim.SetBool (anim.GetParameter (isStopRU).nameHash, true);		
					}
					anim.SetFloat (anim.GetParameter (horizontalMagnitude).nameHash, 0.0f);
					walkedLeft = false;
				}
			}

//			if (Input.GetKey (KeyCode.Q) && !anim.GetBool (anim.GetParameter (isSwitchWeapon).nameHash)) {
//				hasSwitched = true;
//				GetComponent<Player> ().primaryWeaponIndex++;
//				GetComponent<Player> ().secondaryWeaponIndex++;
//
//				if (GetComponent<Player> ().primaryWeaponIndex >= GetComponent<Player> ().primaryWeaponHolder.childCount)
//					GetComponent<Player> ().primaryWeaponIndex = 0;
//				if (GetComponent<Player> ().secondaryWeaponIndex >= GetComponent<Player> ().secondaryWeaponHolder.childCount)
//					GetComponent<Player> ().secondaryWeaponIndex = 0;
//				if (isLocalPlayer)
//					GetComponent<Player> ().CmdSwitchWeaponOnClients (GetComponent<Player> ().primaryWeaponIndex, GetComponent<Player> ().secondaryWeaponIndex);
//			} else if (!Input.GetKey (KeyCode.Q) && hasSwitched) {
//				hasSwitched = false;
//			}
//
//			if (Input.GetMouseButton (0) && !isSprinting && !isReloading) {
//				anim.SetBool (anim.GetParameter (shootIndex).nameHash, true);
//				anim.SetFloat (anim.GetParameter (fireRateIndex).nameHash, GetComponent<Player> ().getCurrentWeapon ().GetComponent<Weapon> ().rateOfFire * 1.5f / 13f);
//			} else {
//				anim.SetBool (anim.GetParameter (shootIndex).nameHash, false);
//			}
//
//			if (Input.GetMouseButton (1) && !isSprinting) {
//				playerCamera.GetComponent<PlayerCamera> ().xDistance = 0.5f;
//				playerCamera.GetComponent<PlayerCamera> ().distance = 1.0f;
//			} else {
//				playerCamera.GetComponent<PlayerCamera> ().xDistance = 1.0f;
//				playerCamera.GetComponent<PlayerCamera> ().distance = 2.5f;
//			}
//
//			if ((Input.GetKeyDown (KeyCode.R) || GetComponent<Player> ().isReloading) && GetComponent<Player> ().getCurrentWeapon ().GetComponent<Weapon> ().ammoClip < GetComponent<Player> ().getCurrentWeapon ().GetComponent<Weapon> ().maxMagazineSize && GetComponent<Player> ().getCurrentWeapon ().GetComponent<Weapon> ().totalAmmo > 0) {
//				isReloading = true;
//				GetComponent<Player> ().isReloading = true;
//				anim.SetBool (anim.GetParameter (isReload).nameHash, true);
//
//				StartCoroutine ("WaitBeforeReload");
//
//				int currentClipAmmo = Mathf.Clamp (GetComponent<Player> ().getCurrentWeapon ().GetComponent<Weapon> ().ammoClip, 0, GetComponent<Player> ().getCurrentWeapon ().GetComponent<Weapon> ().maxMagazineSize);
//				GetComponent<Player> ().getCurrentWeapon ().GetComponent<Weapon> ().ammoClip = GetComponent<Player> ().getCurrentWeapon ().GetComponent<Weapon> ().totalAmmo + currentClipAmmo >= GetComponent<Player> ().getCurrentWeapon ().GetComponent<Weapon> ().maxMagazineSize ? GetComponent<Player> ().getCurrentWeapon ().GetComponent<Weapon> ().maxMagazineSize : GetComponent<Player> ().getCurrentWeapon ().GetComponent<Weapon> ().totalAmmo + currentClipAmmo;
//				GetComponent<Player> ().getCurrentWeapon ().GetComponent<Weapon> ().totalAmmo -= (GetComponent<Player> ().getCurrentWeapon ().GetComponent<Weapon> ().ammoClip - currentClipAmmo);
//
//			}
//		}
	}
		
	void OnCollisionEnter (Collision col) {
		if (col.gameObject.tag == "Vaultable" && anim.GetParameter (isVault) != null && !anim.GetBool(anim.GetParameter (isVault).nameHash) && !isVaulting) {
			anim.SetBool (anim.GetParameter (isVault).nameHash, true);	
			isVaulting = true;
			StartCoroutine (WaitBeforeStopVault ());
		}
	}

//	IEnumerator WaitBeforeReload () {
//		yield return new WaitForSeconds (2f);
//		anim.SetBool (anim.GetParameter (isReload).nameHash, false);
//
//		GetComponent<Player> ().isReloading = false;
//		isReloading = false;
//	}

	IEnumerator WaitBeforeStopVault () {
		yield return new WaitForSeconds (0.15f);
		anim.SetBool (anim.GetParameter (isVault).nameHash, false);	
		yield return new WaitForSeconds (1f);
		isVaulting = false;
	}

	IEnumerator WaitBeforeStopWalk () {
		yield return null;
		anim.SetFloat (anim.GetParameter (walkStopAngle).nameHash, 90.0f);
		anim.SetFloat (anim.GetParameter (inputMagnitude).nameHash, 0.0f);
		if (!walkedBack && !walkedLeft && !walked) {
			anim.SetBool (anim.GetParameter (isStopRU).nameHash, true);		
		}
		anim.SetFloat (anim.GetParameter (horizontalMagnitude).nameHash, 0.0f);
		while (anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 0.95f)
		{
			yield return null;
		}
	}
}