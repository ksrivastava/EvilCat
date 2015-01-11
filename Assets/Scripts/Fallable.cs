using UnityEngine;
using System.Collections;

public class Fallable : MonoBehaviour {

	public bool isActive = true;
	public float duration = 0.10f;
	public float switchBackDuration = 2f;
	public bool hasHitFloor = false;
	public bool wasCaught = false;
	public int points = 100;
	KeyboardMovement movement;
//	public AudioClip audio;

	Cat cat;
	Owner owner;
	SmoothFollow smoothFollow;
	Transform catTarget = null;
	
	// Use this for initialization
	void Start () {
		smoothFollow = Camera.main.GetComponent<SmoothFollow> ();
		cat = GameObject.FindGameObjectWithTag ("Player").GetComponent<Cat> ();
		movement = cat.GetComponent<KeyboardMovement> ();
		owner = GameObject.FindGameObjectWithTag ("Owner").GetComponent<Owner> ();
		catTarget = smoothFollow.target;
	}

	public void PerformFinalCameraSwitch(float duration) {
		if (wasCaught == false) {
			cat.Score += points;
		}
		else {
			cat.Caught();
		}
		isActive = false;
		Invoke("SwitchCameraBack", duration);
	}

	public void LookAtMe() {
		smoothFollow.target = this.transform;
		movement.isEnabled = false;
	}
	
	public void SwitchCameraBack() {
		if (smoothFollow.target == this.transform) {
			smoothFollow.target = catTarget;
			movement.isEnabled = true;
		}
	}
	
	void OnCollisionEnter(Collision col) {
		if (isActive) {
			if (col.gameObject.tag == "Floor") {
				if (hasHitFloor == false) {
					hasHitFloor = true;
					wasCaught = owner.canSeeCat;
					audio.Play();
				}
			}
			if (hasHitFloor == false && col.gameObject.tag == "Counter") {
				// Start timer here
				SwitchCameraBack();
			}
		}
	}
	
	void OnCollisionExit(Collision col) {
		if (isActive) {
			if (col.gameObject.tag == "Counter") {
				float to_y = col.gameObject.collider.bounds.max.y;
				if (collider.bounds.min.y <= (to_y - 0.1f)) {
					LookAtMe();
				}
			}
		}
	}
}
