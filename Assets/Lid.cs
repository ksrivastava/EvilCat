using UnityEngine;
using System.Collections;

public class Lid : MonoBehaviour {

	Fallable fallable;

	// Use this for initialization
	void Start () {
		fallable = this.transform.parent.GetComponent<Fallable> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (fallable.hasHitFloor) {
			collider.isTrigger = false;
			rigidbody.isKinematic = false;
		}
	}
}
