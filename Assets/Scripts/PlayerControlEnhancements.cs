using UnityEngine;
using System.Collections;

public class PlayerControlEnhancements : MonoBehaviour {
	CharacterMotor motor;

	// Use this for initialization
	void Start () {
		motor = GetComponent<CharacterMotor>();
		if (!motor) {
			Debug.LogError("Failed to start PlayerControlEnhancements: No motor is attached");
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.LeftShift)) {
			motor.movement.maxForwardSpeed *= 2.0f;
		}
		else if (Input.GetKeyUp (KeyCode.LeftShift)) {
			motor.movement.maxForwardSpeed /= 2.0f;
		}

	}
}
