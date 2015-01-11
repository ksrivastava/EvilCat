using UnityEngine;
using System.Collections;

public class LegCollider : MonoBehaviour {

	private GameObject Cat;
	private KeyboardMovement keyboardMovement;

	// Use this for initialization
	void Start () {
		Cat = GameObject.FindGameObjectWithTag ("Player") as GameObject;
		keyboardMovement = Cat.GetComponent<KeyboardMovement> (); 
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionStay () {
		keyboardMovement.grounded = true;    
	}
}
