using UnityEngine;
using System.Collections;

public class ToggleOwnerCamera : MonoBehaviour {
	
	SmoothFollow smoothFollow;
	bool isMiniMapView = true;
	Vector3 miniMapTransformPosition, miniMapTransformScale;
	Quaternion miniMapTransformRotation;

	// Use this for initialization
	void Start () {
		smoothFollow = GetComponent<SmoothFollow>();

		miniMapTransformPosition = camera.transform.position;
		miniMapTransformRotation = camera.transform.rotation;
		miniMapTransformScale = camera.transform.localScale;

		SwitchToMiniMapView ();

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.T)) {
			if (isMiniMapView) {
				SwitchToOwnerView();
			}
			else {
				SwitchToMiniMapView();
			}
		}
	}

	void SwitchToMiniMapView() {
		isMiniMapView = true;
		camera.transform.position = miniMapTransformPosition;
		camera.transform.rotation = miniMapTransformRotation;
		camera.transform.localScale = miniMapTransformScale;
		smoothFollow.enabled = false;
		camera.isOrthoGraphic = true;
		camera.cullingMask |= 1 << LayerMask.NameToLayer("Person Camera");

	}

	void SwitchToOwnerView() {
		isMiniMapView = false;
		smoothFollow.enabled = true;
		camera.isOrthoGraphic = false;
		// camera.cullingMask &=  ~(1 << LayerMask.NameToLayer("Person Camera"));
	}
}
