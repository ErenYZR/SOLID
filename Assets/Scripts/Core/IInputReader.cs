using UnityEngine;

public interface IInputReader
{
	Vector2 ReadMovementInput();
	Vector2 ReadMouseDirection(Vector3 playerWorldPosition);
	bool Skill1Triggered();
	bool Skill2Triggered();
}
