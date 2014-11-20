using UnityEngine;
using System.Collections;

public class Meteor : MonoBehaviour {
	public float lifespan;
	public Vector3 direction;
	public float speed;

	// Use this for initialization
	void Start () {

	}

	void Update() {
		lifespan -= Time.deltaTime;
		if (lifespan < 0.0f) {
			GameObject.Destroy(gameObject);
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 force = direction.normalized * speed * Time.deltaTime;
		rigidbody.AddForce(force);
	}
}
