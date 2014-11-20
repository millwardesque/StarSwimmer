using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MeteorMaker : MonoBehaviour {
	public int maxMeteors = 1;
	public Vector3 frontBottomRight = new Vector3();
	public Vector3 backTopLeft = new Vector3();
	public int lifespan = 1;
	public GameObject meteorToClone;
	public float creationDelay = 1.0f;

	private List<Meteor> meteors;
	private float countdown = 0;

	// Use this for initialization
	void Start () {
		meteors = new List<Meteor>();
		if (!meteorToClone) {
			Debug.LogError("Unable to start MeteorMaker: The meteor to clone isn't set.");
		}
	}
	
	// Update is called once per frame
	void Update () {
		// Clean up any dead meteors.
		for (int i = 0; i < meteors.Count; ++i) {
			Meteor meteor = meteors[i];

			if (!meteor) {
				meteors.RemoveAt(i);
				i--;
			}
		}

		countdown -= Time.deltaTime;

		// Check if we can create a new meteor
		if (meteors.Count < maxMeteors && countdown <= float.Epsilon) {
			Vector3 boundingVector = GenerateBoundingVector();
			Vector3 position = new Vector3(frontBottomRight.x - boundingVector.x / 2.0f, frontBottomRight.y + boundingVector.y / 2.0f, frontBottomRight.z - boundingVector.z / 2.0f);

			GameObject newMeteor = (GameObject)GameObject.Instantiate(meteorToClone);
			Meteor meteor = newMeteor.GetComponent<Meteor>();
			meteor.lifespan = lifespan;
			meteor.direction = GenerateRandomDirection();
			newMeteor.transform.position = position;
			meteors.Add (meteor);

			countdown = creationDelay;
		}
	}

	/// <summary>
	/// Generates a Vector stretching from the frontBottomLeft corner of the bounding box to the backTopRight corner.
	/// </summary>
	/// <returns>The bounding vector.</returns>
	private Vector3 GenerateBoundingVector() {
		return new Vector3(Random.Range(frontBottomRight.x, backTopLeft.x), Random.Range(frontBottomRight.y, backTopLeft.y), Random.Range(frontBottomRight.z, backTopLeft.z));
	}

	private Vector3 GenerateRandomDirection() {
		Vector3 direction = GenerateBoundingVector();
		direction.Normalize();
		return direction;
	}
}
