using UnityEngine;
using System.Collections;

public class Owner : MonoBehaviour {

	float speed = 5f;
	Cat cat;
	public bool canSeeCat = false;

	void Start () {
		cat = GameObject.FindGameObjectWithTag ("Player").GetComponent<Cat> ();
	}


	// Update is called once per frame
	void Update () {
		float localSpeed = speed;

		if (canSeeCat) {
			localSpeed = 2f;
		}

		var pos = transform.position;
		pos += transform.forward * localSpeed * Time.deltaTime;
		transform.position = pos;
	}

	public void Turn () {
		float localTurnSpeed = 1;
		
		if (canSeeCat) {
			localTurnSpeed = 0.2f;
		}

		transform.Rotate(0, localTurnSpeed, 0);
	}
	
}
