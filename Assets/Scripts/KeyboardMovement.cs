using UnityEngine;
using System.Collections;

public class KeyboardMovement : MonoBehaviour {

	float moveSpeed = 10f;
	float runSpeed = 8f;
	float gravity = 14.0f;
	float jumpSpeed = 10f;
	float rotationSpeed = 100f;

	bool onFloor = true;
	public bool isEnabled = true;
	public bool grounded = false;
	SmoothFollow smoothFollow;


	void Awake () {
		rigidbody.freezeRotation = true;
		rigidbody.useGravity = false;
	}

	// Use this for initialization
	void Start () {
		smoothFollow = Camera.main.GetComponent<SmoothFollow> ();
	}

	// Update is called once per frame
	void FixedUpdate () {
		// rigidbody.velocity = new Vector3 (0f, rigidbody.velocity.y, 0f);
		float speed = moveSpeed;

		if (Input.GetKey (KeyCode.M)) {
			if (audio.isPlaying == false) audio.Play();
		}

		if (isEnabled) {

			float newHeight = smoothFollow.height + (Input.GetAxis ("Mouse ScrollWheel"));
			if (newHeight > -2 && newHeight < 18) {
				smoothFollow.height =  newHeight;
			}

			if (Input.GetKeyDown (KeyCode.Space) && grounded) {
				rigidbody.velocity = new Vector3(0f, jumpSpeed, 0f);
			}

			float rotSpeed = Input.GetAxisRaw ("Horizontal") * Time.deltaTime * rotationSpeed;
			transform.Rotate(0, 0, -rotSpeed);

			float vertical = Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;
			transform.Translate(0, vertical, 0);
		}

		rigidbody.AddForce(new Vector3 (0, - gravity * rigidbody.mass, 0));
		onFloor = false;
	}

	void OnCollisionStay(Collision col) {
		if (col.gameObject.tag == "Floor") {
			grounded = true;
			onFloor = true;
		}
		else {				
			float top_y = col.gameObject.renderer.bounds.max.y;
			if (transform.renderer.bounds.min.y >= top_y) {
				grounded = true;
			}
		}

	}

	void OnCollisionExit(Collision col) {
		grounded = false;
	}
}
