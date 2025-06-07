using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputReader : MonoBehaviour, IInputReader
{
	private PlayerControls controls;
	private void Awake()
	{
		controls = new PlayerControls();
		controls.Player.Enable();
	}

	public Vector2 ReadMovementInput()
	{
		return controls.Player.Move.ReadValue<Vector2>();
	}

	public Vector2 ReadMouseDirection(Vector3 playerWorldPos)
	{
        Vector2 mouseScreen = Mouse.current.position.ReadValue();
        Vector2 playerScreen = Camera.main.WorldToScreenPoint(playerWorldPos);
        return (mouseScreen - playerScreen).normalized;
	}
	public bool Skill1Triggered()
	{
		return controls.Player.Skill1.WasPressedThisFrame();
	}

	public bool Skill2Triggered()
	{
		return controls.Player.Skill2.WasPressedThisFrame();
	}

	private void OnDestroy()
	{
		controls.Player.Disable();
	}
}
