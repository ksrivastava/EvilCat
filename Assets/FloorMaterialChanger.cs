using UnityEngine;
using System.Collections;

public class FloorMaterialChanger : MonoBehaviour {

	private GameObject Cat;
	float top_y;

	// Use this for initialization
	void Start () {
		Cat = GameObject.FindGameObjectWithTag ("Player") as GameObject;
		top_y = this.renderer.bounds.max.y;
	}
	
	// Update is called once per frame
	void Update () {
		if (Cat.transform.position.y > top_y) {
			collider.material.dynamicFriction = 10;		
			collider.material.staticFriction = 10;
		}
		else {
			collider.material.dynamicFriction = 0;
			collider.material.staticFriction = 0;
		}
	}
}
