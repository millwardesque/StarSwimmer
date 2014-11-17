using UnityEngine;
using System.Collections;

public class PlayerSFX : MonoBehaviour {
	public AudioClip walkOnWater;
	public AudioClip walkOnLand;
	private AudioSource audioSource;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
		if (!audioSource) {
			Debug.LogError("Unable to initialize player SFX: No Audio Source attached.");
		}
		if (!walkOnWater) {
			Debug.LogWarning("Player has no walk-on-water sound FX.");
		}
		if (!walkOnLand) {
			Debug.LogWarning("Player has no walk-on-land sound FX.");
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnControllerColliderHit(ControllerColliderHit hit) {
		if (hit.collider.tag == "Water" && walkOnWater) {
			if (audioSource.clip != walkOnWater) {
				audioSource.clip = walkOnWater;
			}

			if (!audioSource.isPlaying) {
				audioSource.Play();
			}
		}
		else if (hit.collider.tag == "Land" && walkOnLand) {
			if (audioSource.clip != walkOnLand) {
				audioSource.clip = walkOnLand;
			}
			
			if (!audioSource.isPlaying) {
				audioSource.Play();
			}
		}
		else {
			if (audioSource.isPlaying) {
				audioSource.Stop();
			}
		}
	}
}
