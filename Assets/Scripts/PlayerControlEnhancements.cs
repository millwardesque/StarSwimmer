using UnityEngine;
using System.Collections;

[RequireComponent (typeof (CharacterMotor))]

public class PlayerControlEnhancements : MonoBehaviour {
	CharacterMotor motor;

	void Awake() {
		motor = GetComponent<CharacterMotor>();
	}

	public void useWalkSpeed() {
		motor.movement.maxForwardSpeed /= 2.0f;
	}

	public void useRunSpeed() {
		motor.movement.maxForwardSpeed *= 2.0f;
	}
}
