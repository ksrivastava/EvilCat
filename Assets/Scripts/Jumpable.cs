using UnityEngine;
using System.Collections;

public class Jumpable : MonoBehaviour {

//	float deltaY = 0;
//	float deltaJump = 0.2f;
//	float jumpHeight = 4f;
//	float top_y;
	// Use this for initialization
	void Start () {
//		top_y = this.renderer.bounds.max.y;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

//	public void Jump(GameObject obj) {
//		print ("In Jump");
//		var pos = obj.transform.position;
//		if (pos.y < top_y) {
//			pos += (Camera.main.transform.forward * deltaJump);
//			pos.y = top_y + obj.renderer.bounds.size.y/2 + deltaY;
//		}
//		else print ("Already on top");
//		obj.transform.position = pos;
//	}
//
//	void OnCollisionEnter(Collision col) {
//		GameObject obj = col.gameObject;
//		if (obj.tag == "Player") {
//			KeyboardMovement keyboardMovement = obj.GetComponent<KeyboardMovement> ();
//			if (keyboardMovement.JumpableObj != this && obj.transform.position.y + jumpHeight > top_y) {
//				print ("Enter");
//				keyboardMovement.JumpableObj = this;
//			}
//		}
//	}
//
//	void OnCollisionExit(Collision col) {
//		GameObject obj = col.gameObject;
//		if (obj.tag == "Player") {
//			KeyboardMovement keyboardMovement = obj.GetComponent<KeyboardMovement> ();
//			if (keyboardMovement.JumpableObj == this) {
//				print ("Exit");
//				keyboardMovement.JumpableObj = null;
//			}
//		}
//	}
}
