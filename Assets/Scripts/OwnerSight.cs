using UnityEngine;
using System.Collections;

public class OwnerSight : MonoBehaviour {

	Mesh mesh;
	private float width = 0.6f;
	private float depth = 3f;
	Owner person;
	Cat cat;

	void Awake() {
		cat = GameObject.FindGameObjectWithTag ("Player").GetComponent<Cat> ();
		person = transform.parent.gameObject.GetComponent<Owner> ();

		gameObject.AddComponent("MeshFilter");
		gameObject.AddComponent("MeshRenderer");
		gameObject.AddComponent("MeshCollider");
		MeshFilter meshFilter = GetComponent<MeshFilter>();

		float hyp = Mathf.Sqrt (width * width + depth * depth);

		Vector3 p0 = new Vector3(0,0,0);
		Vector3 p1 = new Vector3 (-width, 0, hyp);
		Vector3 p2 = new Vector3 (width, 0, hyp);
		Vector3 p3 = new Vector3(0, 1f, depth);

//		Vector3 p0 = new Vector3(-1,0,0);
//		Vector3 p1 = new Vector3 (1, 0, 0);
//		Vector3 p2 = new Vector3 (0, 0, 1);
//		Vector3 p3 = new Vector3(0, 1, 0);
		
		mesh = meshFilter.mesh;
		mesh.Clear();

		mesh.vertices = new Vector3[]{
			p0,p1,p2,
			p0,p2,p3,
			p2,p1,p3,
			p0,p3,p1
		};
		mesh.triangles = new int[]{
			0,1,2,
			3,4,5,
			6,7,8,
			9,10,11
		};
		
		mesh.RecalculateNormals();
		mesh.RecalculateBounds();
		mesh.Optimize();

		MeshCollider collider = GetComponent<MeshCollider> ();
		collider.sharedMesh = mesh;
		collider.convex = true;

		collider.isTrigger = true;
		rigidbody.isKinematic = true;
		rigidbody.useGravity = false;

		renderer.material.color = Color.yellow;
	}

	void Update() {
		var pos = transform.position;
		pos.y = cat.transform.position.y;
		transform.position = pos;
	}

	void OnTriggerStay(Collider col) {
		if (col.gameObject.tag == "Wall") {
			person.Turn();
		}
		if (col.gameObject.tag == "Player") {
			person.canSeeCat = true;
			renderer.material.color = Color.red;
			if (audio.isPlaying == false) {
				audio.Play();
			}
		}
	}

	void OnTriggerExit(Collider col) {
		if (col.gameObject.tag == "Player") {
			person.canSeeCat = false;
			renderer.material.color = Color.yellow;
			if (audio.isPlaying) {
				audio.Stop();
			}
		}
	}
}
