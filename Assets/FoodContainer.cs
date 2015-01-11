using UnityEngine;
using System.Collections;

public class FoodContainer : MonoBehaviour {

	public GameObject foodPrefab;
	public Color foodPrefabColor;
	public GameObject topMarker;

	int numFoodInstantiated = 0;
	public int maxFoodInstantiated = 100;

	bool isActive = true;
	Fallable fallable;
	float deltaTime;
	float switchBackDuration = 2f;

	// Use this for initialization
	void Start () {
		fallable = this.GetComponent<Fallable> ();
		foodPrefab.renderer.material.color = foodPrefabColor;
	}
	
	// Update is called once per frame
	void Update () {
		if (isActive) {
			if (fallable.hasHitFloor && numFoodInstantiated < maxFoodInstantiated) {
				Vector3 pos = topMarker.transform.position;
				GameObject food = Instantiate (foodPrefab, pos, Quaternion.identity) as GameObject;
				food.renderer.material.color = foodPrefabColor;
				numFoodInstantiated = numFoodInstantiated + 1;
			}
			else if (numFoodInstantiated >= maxFoodInstantiated) {
				fallable.PerformFinalCameraSwitch(switchBackDuration);
				isActive = false;
			}
		}
	}	
}
