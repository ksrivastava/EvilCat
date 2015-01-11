using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
	
	Cat cat;

	// Use this for initialization
	void Start () {
		cat = GameObject.FindGameObjectWithTag ("Player").GetComponent<Cat> ();
	}

	// Update is called once per frame
	void Update () {

	}

	void LateUpdate() {

	}
}
